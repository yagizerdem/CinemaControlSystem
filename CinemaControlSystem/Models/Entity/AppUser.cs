using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace CinemaControlSystem.Models.Entity
{
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }
        
        
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    } 
}
