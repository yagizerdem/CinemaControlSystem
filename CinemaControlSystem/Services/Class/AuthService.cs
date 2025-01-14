using CinemaControlSystem.Exceptions;
using CinemaControlSystem.Models;
using CinemaControlSystem.Models.DTO;
using CinemaControlSystem.Models.Entity;
using CinemaControlSystem.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using UUIDNext;

namespace CinemaControlSystem.Services.Class
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthService(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<ServiceResponse<AppUser>> Register(RegisterDTO dto)
        {
            try
            {
                AppUser newUser = new AppUser();
                newUser.Email = dto.Email;
                newUser.FirstName = dto.FirstName;
                newUser.LastName = dto.LastName;
                newUser.UserName = Uuid.NewDatabaseFriendly(Database.SqlServer).ToString(); // generate unique user name

                var result = await _userManager.CreateAsync(newUser, dto.Password);


                if (result.Succeeded)
                {
                    return ServiceResponse<AppUser>.Success(newUser, "new user created successfully");
                }
                else
                {
                    List<string> errorMessages = result.Errors.Select(x => x.Description).ToList();
                    throw new AppException(false, errorMessages);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                if (ex is AppException)
                {
                    AppException exception = (AppException)ex;
                    if (!exception.IsCritical)
                    {
                        return ServiceResponse<AppUser>.Fail(null, exception.Errors, exception.Message);
                    }
                }
                return ServiceResponse<AppUser>.Fail(null, null, "internal server error");
            }
        }

    }
}
