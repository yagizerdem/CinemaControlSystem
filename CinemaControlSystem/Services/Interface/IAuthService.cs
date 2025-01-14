using CinemaControlSystem.Models;
using CinemaControlSystem.Models.DTO;
using CinemaControlSystem.Models.Entity;

namespace CinemaControlSystem.Services.Interface
{
    public interface IAuthService
    {
        public Task<ServiceResponse<AppUser>> Register(RegisterDTO dto);

    }
}
