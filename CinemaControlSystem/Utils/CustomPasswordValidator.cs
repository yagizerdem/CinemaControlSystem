using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;

/*
 
(?=.*[a-z]): At least one lowercase letter.
(?=.*[A-Z]): At least one uppercase letter.
(?=.*\d): At least one digit.
.{8,}: Minimum 8 characters.

 */

namespace CinemaControlSystem.Utils
{
    public class CustomPasswordValidator<TUser> : IPasswordValidator<TUser>
        where TUser : class
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            // Define your regex pattern
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");

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
