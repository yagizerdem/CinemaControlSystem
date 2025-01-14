using CinemaControlSystem.DataAccess;
using CinemaControlSystem.Exceptions;
using CinemaControlSystem.Models;
using CinemaControlSystem.Models.DTO;
using CinemaControlSystem.Models.Entity;
using CinemaControlSystem.Services.Interface;
using CinemaControlSystem.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using UUIDNext;

namespace CinemaControlSystem.Services.Class
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _dbContext;
        public AuthService(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }
        public async Task<ServiceResponse<AppUser>> Register(RegisterDTO dto)
        {
            try
            {

                using var transaction = await _dbContext.Database.BeginTransactionAsync(); // Begin a transaction

                AppUser newUser = new AppUser();
                newUser.Email = dto.Email;
                newUser.FirstName = dto.FirstName;
                newUser.LastName = dto.LastName;
                newUser.UserName = Uuid.NewDatabaseFriendly(Database.SqlServer).ToString(); // generate unique user name

                var result = await _userManager.CreateAsync(newUser, dto.Password);


                if (!result.Succeeded)
                {
                    List<string> errorMessages = result.Errors.Select(x => x.Description).ToList();
                    throw new AppException(false, errorMessages);
                }


                result = await _userManager.AddToRoleAsync(newUser, Roles.Client);


                if (!result.Succeeded)
                {
                    List<string> errorMessages = result.Errors.Select(x => x.Description).ToList();
                    throw new AppException(false, errorMessages);
                }

                await transaction.CommitAsync(); // Commit if successful
                return ServiceResponse<AppUser>.Success(newUser, "new user created successfully");
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
