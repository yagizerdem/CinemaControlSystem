using CinemaControlSystem.Components;
using CinemaControlSystem.Components.Pages.Areas.Client;
using CinemaControlSystem.DataAccess;
using CinemaControlSystem.Exceptions;
using CinemaControlSystem.Models;
using CinemaControlSystem.Models.Abstract;
using CinemaControlSystem.Models.DTO;
using CinemaControlSystem.Models.Entity;
using CinemaControlSystem.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CinemaControlSystem.Services.Class
{
    public class ProfileService<T> : IProfileService<T> where T : BaseProfile
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _dbContext;

        private readonly DbSet<T> _dbSet;
        public ProfileService(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();   
        }

        public async Task<T?> FetchProfileByUserId(string userId)
        {
            T? profile = await  this._dbSet.FirstOrDefaultAsync(x => x.AppUserId == userId);
            return profile;
        }

        public async Task<T?> FetchProfileByProfileId(int profileId)
        {
            T? profile = await this._dbSet.FirstOrDefaultAsync(x => x.Id == profileId);
            return profile;
        }

        public async Task<ServiceResponse<ClientProfile?>> UpsertClientProfile(ClientProfileUpdateDTO dto)
        {
            try
            {
                T profile = await this._dbSet.FirstOrDefaultAsync(x => x.AppUserId == dto.AppUserId);
                if (profile != null)
                {
                    ClientProfile clientProfile = (profile as ClientProfile);
                    clientProfile.preferancesCsv = dto.preferancesCsv;
                    clientProfile.openAddress = dto.openAddress;
                    clientProfile.UpdatedDate = DateTime.UtcNow;
                    clientProfile.showEmail = dto.showEmail;
                    clientProfile.rememberLogIn = dto.rememberLogIn;

                    this._dbContext.Update(clientProfile);
                    await this._dbContext.SaveChangesAsync();

                    return ServiceResponse<ClientProfile>.Success(clientProfile , "profile updated successfully");

                }
                else
                {
                    ClientProfile clientProfile = new();
                    clientProfile.preferancesCsv = dto.preferancesCsv;
                    clientProfile.openAddress = dto.openAddress;
                    clientProfile.UpdatedDate = DateTime.UtcNow;
                    clientProfile.showEmail = dto.showEmail;
                    clientProfile.rememberLogIn = dto.rememberLogIn;
                    clientProfile.AppUserId = dto.AppUserId;

                    this._dbContext.Add(clientProfile);
                    await this._dbContext.SaveChangesAsync();

                    return ServiceResponse<ClientProfile>.Success(clientProfile, "profile inserted successflly");
                }
            }catch (Exception ex)
            {
                if(ex is AppException)
                {
                    AppException appEx = ex as AppException;
                    if(!appEx.IsCritical) return ServiceResponse<ClientProfile?>.Fail(null , [String.Join("\n",appEx.Errors)]);
                }
                return ServiceResponse<ClientProfile?>.Fail(null, ["internal server error"]);
            }

        }

    }
}
