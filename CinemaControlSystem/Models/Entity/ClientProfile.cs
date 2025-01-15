using CinemaControlSystem.Models.Abstract;
using CinemaControlSystem.Models.Interface;
using System.ComponentModel.DataAnnotations;

namespace CinemaControlSystem.Models.Entity
{
    public class ClientProfile  : BaseProfile , IEntityTimestamps, IBaseEntity
    {
        [Required]
        public bool isVip { get; set; } = false;

        [Required]
        public DateTime lastFreeMovieWatchedDate { get; set; }

        [Required]
        public bool rememberLogIn { get; set; } = false;

        [Required]
        public bool showEmail { get; set; } = true;

        public string preferancesCsv { get; set; } = string.Empty;
        public string openAddress { get; set; } = string.Empty;
        public string profileImgUrl { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<ClientOpinion> Comments { get; set; }

    }
}
