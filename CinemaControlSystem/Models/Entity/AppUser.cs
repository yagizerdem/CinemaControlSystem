using CinemaControlSystem.Models.Interface;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace CinemaControlSystem.Models.Entity
{
    public class AppUser : IdentityUser , IEntityTimestamps , IBaseEntity
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }
        
        
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    } 
}
