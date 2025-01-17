using CinemaControlSystem.Models;
using CinemaControlSystem.Models.DTO;
using CinemaControlSystem.Models.Entity;

namespace CinemaControlSystem.Services.Interface
{
    public interface IClientOpinionService
    {
        public Task<ServiceResponse<bool>> Add(ClientOpinionDTO dto);

        public Task<ServiceResponse<List<ClientOpinion>>> FetchClientOpinions(int limit, int page);
    }
}
