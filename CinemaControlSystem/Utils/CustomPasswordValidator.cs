using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;


namespace CinemaControlSystem.Utils
{
    public class CustomPasswordValidator<TUser> : IPasswordValidator<TUser>
        where TUser : class
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            // Define your regex pattern
            var regex = new Regex(SD.StrongPasswordRegex);

            if (!regex.IsMatch(password))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "PasswordRegexValidationFailed",
                    Description = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, and one digit."
                }));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
