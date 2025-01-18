using CinemaControlSystem.Models.Abstract;
using CinemaControlSystem.Models.Interface;

namespace CinemaControlSystem.Models.Entity
{
    public class DepartmentManagerProfile : BaseEmployeeProfile, IEntityTimestamps, IBaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
