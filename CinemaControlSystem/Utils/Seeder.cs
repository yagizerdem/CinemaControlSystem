using CinemaControlSystem.Components;
using CinemaControlSystem.DataAccess;
using CinemaControlSystem.Exceptions;
using CinemaControlSystem.Models.Entity;
using CinemaControlSystem.Services.Class;
using CinemaControlSystem.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using UUIDNext;

namespace CinemaControlSystem.Utils
{
    public class Seeder
    {

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string[] roles = new[] { Roles.Client, Roles.Boss, Roles.DepartmentManager, Roles.DepartmentManager, Roles.IT };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }

        }


        public static async Task SeedBossUser(IServiceProvider serviceProvider)
        {
            try
            {


                using (var scope = serviceProvider.CreateScope())
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var flag = (await userManager.FindByEmailAsync(SD.bossEmail));
                    if(flag != null)
                    {
                        return;
                    }


                    using var transaction = await dbContext.Database.BeginTransactionAsync(); // Begin a transaction


                    AppUser user = new AppUser();
                    user.FirstName = SD.bossFirstName;
                    user.LastName = SD.bossLastName;
                    user.Email = SD.bossEmail;
                    user.UserName = Uuid.NewDatabaseFriendly(Database.SqlServer).ToString(); // generate unique user name

                    var result = await userManager.CreateAsync(user, "12345aA!");

                    if (!result.Succeeded)
                    {
                        List<string> errorMessages = result.Errors.Select(x => x.Description).ToList();
                        throw new AppException(false, errorMessages);
                    }

                    result = await userManager.AddToRoleAsync(user, Roles.Boss);

                    if (!result.Succeeded)
                    {
                        List<string> errorMessages = result.Errors.Select(x => x.Description).ToList();
                        throw new AppException(false, errorMessages);
                    }

                    // add profile 

                    BossProfile bossProfile = new BossProfile();
                    bossProfile.AppUser = user;
                    bossProfile.AppUserId = user.Id;
                    bossProfile.Salary = 10000;
                    bossProfile.Birth = new DateTime(1990, 4, 21);
                    bossProfile.CreatedDate = DateTime.UtcNow;
                    bossProfile.UpdatedDate = DateTime.UtcNow;
                   

                    var result_ = await dbContext.AddAsync(bossProfile);

                    await dbContext.SaveChangesAsync();
                    await transaction.CommitAsync(); // Commit if successful

                }

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                Console.WriteLine(error);
                System.Environment.Exit(1);
            }


        }
    }
}
