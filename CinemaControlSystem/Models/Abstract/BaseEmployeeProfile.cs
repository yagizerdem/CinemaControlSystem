using System.ComponentModel.DataAnnotations;

namespace CinemaControlSystem.Models.Abstract
{
    public class BaseEmployeeProfile :BaseProfile
    {

        [Required]
        public double Salary { get; set; }
        
        [Required]
        public DateTime Birth {  get; set; }

    }
}
