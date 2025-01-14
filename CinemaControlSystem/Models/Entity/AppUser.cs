using Microsoft.AspNetCore.Identity;

namespace CinemaControlSystem.Models.Entity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
