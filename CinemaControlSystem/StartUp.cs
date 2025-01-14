using CinemaControlSystem.DataAccess;
using CinemaControlSystem.Models.Entity;
using CinemaControlSystem.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CinemaControlSystem.Services.Interface;
using CinemaControlSystem.Services.Class;

namespace CinemaControlSystem
{
    public class StartUp
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            IServiceCollection services = builder.Services;

            services.AddRazorComponents()
                .AddInteractiveServerComponents();


            services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("AppDatabase")));

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddPasswordValidator<CustomPasswordValidator<AppUser>>();


            services.AddTransient<IAuthService, AuthService>();
            services.AddScoped<ToastService>();


            services.AddAuthorization();
            services.AddAuthentication()
                .AddCookie();


            services.AddRazorPages();
            services.AddServerSideBlazor();

        }
    }
}
