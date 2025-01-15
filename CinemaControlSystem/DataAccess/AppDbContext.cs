using CinemaControlSystem.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CinemaControlSystem.DataAccess
{
    public class AppDbContext : IdentityDbContext<AppUser , IdentityRole , string> 
    {
        DbSet<BossProfile> BossProfiles { get; set; }
        DbSet<Report> Reports { get; set; }
        DbSet<ClientProfile> ClientProfiles { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
