using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CinemaControlSystem.Models.DTO
{
    public class ClientProfileUpdateDTO
    {

        public bool rememberLogIn { get; set; } = false;

        public bool showEmail { get; set; } = true;

        public string preferancesCsv { get; set; } = string.Empty;
        public string openAddress { get; set; } = string.Empty;
        public string profileImgUrl { get; set; } = string.Empty;

        public byte[] fileContent { get; set; }

        public string AppUserId { get; set; }

    }
}
