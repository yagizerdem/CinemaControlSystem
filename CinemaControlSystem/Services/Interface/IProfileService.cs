using CinemaControlSystem.Models.DTO;
using CinemaControlSystem.Models.Entity;
using CinemaControlSystem.Models;

namespace CinemaControlSystem.Services.Interface
{
    public interface IProfileService<T> where T : class
    {

        public Task<T> FetchProfileByUserId(string userId);
        public Task<T>  FetchProfileByProfileId(int profileId);

        public Task<ServiceResponse<ClientProfile?>> UpsertClientProfile(ClientProfileUpdateDTO dto);
    }
}
