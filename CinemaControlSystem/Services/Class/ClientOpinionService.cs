using CinemaControlSystem.DataAccess;
using CinemaControlSystem.Exceptions;
using CinemaControlSystem.Migrations;
using CinemaControlSystem.Models;
using CinemaControlSystem.Models.DTO;
using CinemaControlSystem.Models.Entity;
using CinemaControlSystem.Services.Interface;
using CinemaControlSystem.Utils.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace CinemaControlSystem.Services.Class
{
    public class ClientOpinionService : IClientOpinionService
    {
        IProfileService<ClientProfile> profileService;
        private readonly AppDbContext _dbContext;
        private readonly DbSet<ClientOpinion> _dbSet;
        public ClientOpinionService(IProfileService<ClientProfile> profileService, AppDbContext dbContext)
        {
            this.profileService = profileService;
            this._dbContext = dbContext;
            this._dbSet = this._dbContext.Set<ClientOpinion>(); 
        }

        public async Task<ServiceResponse<bool>> Add(ClientOpinionDTO dto)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                var validationContext = new ValidationContext(dto, serviceProvider: null, items: null);
                bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, validateAllProperties: true);

                if (!isValid)
                {
                    throw new AppException(false, new() { "header shuld be more than 3 characters ..." });
                }

                ClientOpinion newOpinion = new ClientOpinion();
                newOpinion.Body = dto.Body; 
                newOpinion.Header = dto.Header;


                ClientProfile? profile = await this.profileService.FetchProfileByProfileId(dto.profileId);

                newOpinion.ClientProfileId = profile.Id;
                newOpinion.ClientProfile = profile; 

                if(profile == null)
                {
                    throw new AppException(false , new(){ "profile not found"});
                }

                // insert data to database 
                EntityEntry<ClientOpinion> result = await _dbSet.AddAsync(newOpinion);
                int changes = await this._dbContext.SaveChangesAsync();

                if (changes == 0)
                {
                    throw new AppException(false, new() { "Error occured while adding client opinion"});
                }

                return ServiceResponse<bool>.Success(true, "opinion added successfully");
            }
            catch(Exception ex)
            {
                if(ex is AppException)
                {
                    AppException appEx = ex as AppException;
                    if (!appEx.IsCritical)
                    {
                        return ServiceResponse<bool>.Fail(false , appEx.Errors);
                    }
                }
                return ServiceResponse<bool>.Fail(false, "internal server error");
            }


        }
 
        public async Task<ServiceResponse<List<ClientOpinion>>> FetchClientOpinions(int limit , int page)
        {
            try
            {
                var result = await this._dbSet
            .Where(x => x.CreatedDate!= null) // Ensure non-null CreatedDate
            .OrderByDescending(x => x.CreatedDate)
            .Skip(page * limit)
            .Take(limit)
            .Include(x => x.ClientProfile)
            .ThenInclude(x => x.AppUser)
            .ToListAsync();


                return ServiceResponse<List<ClientOpinion>>.Success(result, "data fetched successfully");
            }
            catch(Exception ex)
            {
                return ServiceResponse<List<ClientOpinion>>.Fail(null, ["internal server error"]);
            }
        }

        public async Task<ServiceResponse<List<ClientOpinion>>> FetchClientOpinionsByProfileId(int limit, int page , int ProfileId)
        {
            try
            {
                var result = await this._dbSet
            .Where(x => x.CreatedDate != null) // Ensure non-null CreatedDate
            .Where(x => x.ClientProfileId == ProfileId)
            .OrderByDescending(x => x.CreatedDate)
            .Skip(page * limit)
            .Take(limit)
            .Include(x => x.ClientProfile)
            .ThenInclude(x => x.AppUser)
            .ToListAsync();


                return ServiceResponse<List<ClientOpinion>>.Success(result, "data fetched successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<ClientOpinion>>.Fail(null, ["internal server error"]);
            }
        }

        public async Task<ServiceResponse<ClientOpinion>> DeletOpinion(int id)
        {
            try
            {
                var entity = _dbSet.Find(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                }
                await this._dbContext.SaveChangesAsync();
                return ServiceResponse<ClientOpinion>.Success(entity, "opinion deleted successfully");
            }
            catch (Exception ex)
            {
                return ServiceResponse<ClientOpinion>.Fail(null, ["internal server error"]);
            }
        }
    }
}
