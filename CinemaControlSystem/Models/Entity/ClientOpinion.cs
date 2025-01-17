using CinemaControlSystem.Models.Interface;
using System.ComponentModel.DataAnnotations;

namespace CinemaControlSystem.Models.Entity
{
    public class ClientOpinion : IEntityTimestamps, IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        
        public int ClientProfileId { get; set; }    
        public ClientProfile ClientProfile { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Header {  get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
