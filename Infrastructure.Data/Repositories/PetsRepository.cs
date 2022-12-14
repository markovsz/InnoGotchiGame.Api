using Domain.Core.Models;
using Domain.Interfaces.Repositories;
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

        public async Task<Pet> GetPetByIdAsync(Guid petId, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(petId), trackChanges)
            .Include(e => e.Body)
            .Include(e => e.Eyes)
            .Include(e => e.Mouth)
            .Include(e => e.Nose)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Pet>> GetPetsAsync(long now) =>
            await GetAll(false)
            .Where(e => e.DeathDate > now)
            .Select(e => new Pet(e){ 
                HappinessDaysCount = e.HappinessDaysCount + (int)((now - now % (60 * 60 * 24) - e.LastPetDetailsUpdatingTime + e.LastPetDetailsUpdatingTime % (60 * 60 * 24)) / (60 * 60 * 24))
            })
            .OrderByDescending(e => e.HappinessDaysCount)
            .ToListAsync();

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

        public async Task<int> GetFarmDeadPetsCountAsync(Guid farmId) =>
            await GetByCondition(e => e.FarmId.Equals(farmId), false)
            .Where(e => !e.IsAlive)
            .CountAsync();

        public async Task<int> GetFarmAlivePetsCountAsync(Guid farmId) =>
            await GetByCondition(e => e.FarmId.Equals(farmId), false)
            .Where(e => e.IsAlive)
            .CountAsync();

        public async Task<double> GetFarmAverageHappinessDaysCountAsync(Guid farmId, long now) =>
            await GetByCondition(e => e.FarmId.Equals(farmId), false)
            .Where(e => e.IsAlive)
            .Select(e => e.HappinessDaysCount + (int)(((now - now % (60 * 60 * 24)) - e.LastPetDetailsUpdatingTime + e.LastPetDetailsUpdatingTime % (60 * 60 * 24)) / (60 * 60 * 24)))
            .AverageAsync();

        public async Task<double> GetFarmAveragePetsAgeAsync(Guid farmId, long now) =>
            await GetByCondition(e => e.FarmId.Equals(farmId), false)
            .Select(e => (now - e.BirthDate) / (60 * 60 * 24 * 365))
            .AverageAsync();

        public void UpdatePet(Pet pet) => Update(pet);
    }
}
