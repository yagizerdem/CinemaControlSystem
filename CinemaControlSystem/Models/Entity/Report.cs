using CinemaControlSystem.Models.Interface;
using System.ComponentModel.DataAnnotations;

namespace CinemaControlSystem.Models.Entity
{
    public class Report : IEntityTimestamps, IBaseEntity
    { 
        [Key]
        public int Id { get; set; } 
    
        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }
        
        [Required]
        public int ClientProfileId { get; set; } 
        
        [Required]
        public ClientProfile From { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool hasChecked { get; set; } = false;

        [Required]
        public bool hasStared { get; set; } = false;
    }
}
