using CinemaControlSystem.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaControlSystem.DataAccess
{
    public class AppDbContext : IdentityDbContext<AppUser , IdentityRole , string> 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
    }
}
