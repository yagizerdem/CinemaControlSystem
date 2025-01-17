global using Microsoft.AspNetCore.Components.Authorization;

using CinemaControlSystem.DataAccess;
using CinemaControlSystem.Models.Entity;
using CinemaControlSystem.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CinemaControlSystem.Services.Interface;
using CinemaControlSystem.Services.Class;
using CinemaControlSystem.Utils.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Blazored.LocalStorage;
using CinemaControlSystem.Models.Abstract;
using MudBlazor.Services;

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

                options.User.RequireUniqueEmail = true; // Allow duplicate emails if required
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddPasswordValidator<CustomPasswordValidator<AppUser>>();

            // Add custom email validator
            services.AddScoped<IUserValidator<AppUser>, EmailRegexUserValidator<AppUser>>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddScoped<ToastService>();
            services.AddScoped<IFileService , FileService>();
            services.AddScoped<IProfileService<ClientProfile> , ProfileService<ClientProfile>>();
            builder.Services.AddMudServices();

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration["BaseAddress"] ?? "https://localhost/")
            });




            // Configure JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = SD.jwtissuer,
                        ValidAudience = SD.jwtaudiance,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["jwt"]))
                    };
                });

            // Add services to the container
            services.AddControllers(); // Enable controllers
            services.AddEndpointsApiExplorer();


            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddHttpContextAccessor();

            // Add Blazored.LocalStorage
            services.AddBlazoredLocalStorage();


            services.AddAuthorization();
           


            services.AddRazorPages();
            services.AddServerSideBlazor();

        }
    }
}
