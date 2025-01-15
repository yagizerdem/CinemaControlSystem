using CinemaControlSystem.Components;
using CinemaControlSystem.DataAccess;
using CinemaControlSystem.Utils;

namespace CinemaControlSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // initilize services
            StartUp.Configure(builder);


            var app = builder.Build();

            // seed
            await Seeder.SeedRoles(app.Services);


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
            app.MapControllers(); // Map controller routes

            // jwt middleware
            app.Use(async (context, next) =>
            {
                var token = context.Request.Cookies["AuthToken"];
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Authorization = $"Bearer {token}";
                }

                await next.Invoke();
            });


            app.Run();
        }
    }
}
