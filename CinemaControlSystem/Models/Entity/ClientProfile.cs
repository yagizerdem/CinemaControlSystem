using CinemaControlSystem.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace CinemaControlSystem.Models.Entity
{
    public class ClientProfile  : BaseProfile
    {
        [Required]
        public bool isVip { get; set; } = false;

        [Required]
        public DateTime lastFreeMovieWatchedDate { get; set; }  

    }
}
