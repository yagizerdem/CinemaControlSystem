using System.ComponentModel.DataAnnotations;

namespace CinemaControlSystem.Models.Entity
{
    public class Report
    {
        [Key]
        public int Id { get; set; } 
    
        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }
        
        [Required]
        public string AppUserId { get; set; } 
        
        [Required]
        public AppUser From { get; set; }

        public DateTime CreatedAt => DateTime.Now;

        [Required]
        public bool hasChecked { get; set; } = false;

        [Required]
        public bool hasStared { get; set; } = false;
    }
}
