using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace CinemaControlSystem.Utils
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>(SD.authTokenName);
            if (string.IsNullOrWhiteSpace(token))
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            var claims = ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }


        public void MarkUserAsAuthenticated(string token)
        {
            var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(
                new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];

            // Adjust Base64Url encoding to Base64
            payload = payload.Replace('-', '+').Replace('_', '/');

            // Ensure the payload is properly padded
            switch (payload.Length % 4)
            {
                case 2: payload += "=="; break;
                case 3: payload += "="; break;
            }

            var jsonBytes = Convert.FromBase64String(payload);

            // Deserialize the payload into a dictionary
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            // Convert the dictionary into claims
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }
    }
}
