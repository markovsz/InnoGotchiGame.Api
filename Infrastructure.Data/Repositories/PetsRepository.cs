using Domain.Core.Models;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.RequestParameters;
using Infrastructure.Data.ParameterHandlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class PetsRepository : BaseRepository<Pet>, IPetsRepository
    {
        public PetsRepository(RepositoryContext context)
            : base(context)
        {
        }

        public async Task CreatePetAsync(Pet pet) => await CreateAsync(pet);

        public void DeletePet(Pet pet) => Delete(pet);

        public async Task<Pet> GetTrackablePetByIdAsync(Guid petId, long now) =>
            await GetByCondition(e => e.Id.Equals(petId), true)
            .Include(e => e.Body)
            .Include(e => e.Eyes)
            .Include(e => e.Mouth)
            .Include(e => e.Nose)
            .Include(e => e.Farm)
                .ThenInclude(e => e.FarmFriends)
            .FirstOrDefaultAsync();

        public async Task<Pet> GetUntrackablePetByIdAsync(Guid petId, long now) =>
            await GetByCondition(e => e.Id.Equals(petId), false)
            .Include(e => e.Body)
            .Include(e => e.Eyes)
            .Include(e => e.Mouth)
            .Include(e => e.Nose)
            .Include(e => e.Farm)
                .ThenInclude(e => e.FarmFriends)
            .Select(e => new Pet(e)
            {
                HappinessDaysCount = e.HappinessDaysCount + (int)((now - now % (60 * 60 * 24) - e.LastPetDetailsUpdatingTime + e.LastPetDetailsUpdatingTime % (60 * 60 * 24)) / (60 * 60 * 24))
            })
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Pet>> GetPetsAsync(PetParameters parameters, long now) =>
            await GetAll(false)
            .Where(e => e.DeathDate > now)
            .Select(e => new Pet(e){ 
                HappinessDaysCount = e.HappinessDaysCount + (int)((now - now % (60 * 60 * 24) - e.LastPetDetailsUpdatingTime + e.LastPetDetailsUpdatingTime % (60 * 60 * 24)) / (60 * 60 * 24))
            })
            .OrderByDescending(e => e.HappinessDaysCount)
            .PetParametersHandler(parameters)
            .ToListAsync();

        public async Task<IEnumerable<Pet>> GetFarmPetsAsync(Guid farmId, bool trackChanges) =>
            await GetByCondition(e => e.FarmId.Equals(farmId), trackChanges)
            .ToListAsync();

        public async Task<int> GetPetsCountAsync(long now) =>
            await GetAll(false)
            .Where(e => e.DeathDate > now)
            .CountAsync();

        public async Task<IEnumerable<Pet>> GetUserPetsAsync(Guid userId, long now) =>
            await GetAll(false)
            .Include(e => e.Farm)
            .Where(e => e.Farm.UserId.Equals(userId))
            .Select(e => new Pet(e)
            {
                HappinessDaysCount = e.HappinessDaysCount + (int)((now - now % (60 * 60 * 24) - e.LastPetDetailsUpdatingTime + e.LastPetDetailsUpdatingTime % (60 * 60 * 24)) / (60 * 60 * 24))
            })
            .OrderByDescending(e => e.HappinessDaysCount)
            .ToListAsync();

        public async Task<int> GetFarmDeadPetsCountAsync(Guid farmId, long now) =>
            await GetByCondition(e => e.FarmId.Equals(farmId), false)
            .Where(e => e.DeathDate < now)
            .CountAsync();

        public async Task<int> GetFarmAlivePetsCountAsync(Guid farmId, long now) =>
            await GetByCondition(e => e.FarmId.Equals(farmId), false)
            .Where(e => e.DeathDate > now)
            .CountAsync();

        public async Task<double> GetFarmAverageHappinessDaysCountAsync(Guid farmId, long now) =>
            await GetByCondition(e => e.FarmId.Equals(farmId), false)
            .Where(e => e.DeathDate > now)
            .Select(e => e.HappinessDaysCount + (int)(((now - now % (60 * 60 * 24)) - e.LastPetDetailsUpdatingTime + e.LastPetDetailsUpdatingTime % (60 * 60 * 24)) / (60 * 60 * 24)))
            .DefaultIfEmpty()
            .AverageAsync();

        public async Task<double> GetFarmAveragePetsAgeAsync(Guid farmId, long now) =>
            await GetByCondition(e => e.FarmId.Equals(farmId), false)
            .Select(e => e.DeathDate > now ? (now - e.BirthDate) / (60 * 60 * 24 * 365) : (e.DeathDate - e.BirthDate) / (60 * 60 * 24 * 365))
            .DefaultIfEmpty()
            .AverageAsync();

        public void UpdatePet(Pet pet) => Update(pet);
    }
}
