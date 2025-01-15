using CinemaControlSystem.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace CinemaControlSystem.Models.Abstract
{
    public class BaseProfile
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string AppUserId { get; set; }

        [Required]
        public AppUser AppUser { get; set; }
    }
}
