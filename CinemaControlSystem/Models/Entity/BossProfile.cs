using CinemaControlSystem.Models.Abstract;
using CinemaControlSystem.Models.Interface;
using System.ComponentModel.DataAnnotations;

namespace CinemaControlSystem.Models.Entity
{
    public class BossProfile : BaseEmployeeProfile, IEntityTimestamps ,  IBaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
