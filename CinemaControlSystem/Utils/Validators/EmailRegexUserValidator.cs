using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace CinemaControlSystem.Utils.Validators
{
    public class EmailRegexUserValidator<TUser> : IUserValidator<TUser> where TUser : IdentityUser
    {
        private readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
        {
            var errors = new List<IdentityError>();

            // Validate email format
            if (!string.IsNullOrEmpty(user.Email) && !_emailRegex.IsMatch(user.Email))
            {
                errors.Add(new IdentityError
                {
                    Code = "InvalidEmailFormat",
                    Description = "The email address is not in a valid format."
                });
            }

            return errors.Any()
                ? Task.FromResult(IdentityResult.Failed(errors.ToArray()))
                : Task.FromResult(IdentityResult.Success);
        }
    }
}