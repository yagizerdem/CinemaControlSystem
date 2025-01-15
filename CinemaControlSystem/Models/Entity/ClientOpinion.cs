using CinemaControlSystem.Models.Interface;
using System.ComponentModel.DataAnnotations;

namespace CinemaControlSystem.Models.Entity
{
    public class ClientOpinion : IEntityTimestamps, IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        
        public int ClientProfileId { get; set; }    
        public required ClientProfile ClientProfile { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
