using CinemaControlSystem.Models.Entity;
using CinemaControlSystem.Models.Interface;
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

        DbSet<ClientOpinion> ClientOpinions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }


        public override int SaveChanges()
        {
            SetCreatedDates();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetCreatedDates();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void SetCreatedDates()
        {
            var entries = ChangeTracker.Entries<IEntityTimestamps>()
                .Where(e => e.State == EntityState.Added);

            foreach (var entry in entries)
            {
                entry.Entity.CreatedDate = DateTime.UtcNow;
            }
        }

    }
}
