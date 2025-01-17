using System.ComponentModel.DataAnnotations;

namespace CinemaControlSystem.Models.DTO
{
    public class ClientOpinionDTO
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Header { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public int profileId { get; set; }  


    }
}
