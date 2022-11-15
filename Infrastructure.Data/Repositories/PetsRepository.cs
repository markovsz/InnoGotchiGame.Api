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
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Pet>> GetPetsAsync() =>
            await GetAll(false)
            .Where(e => e.DeathDate > DateTime.Now)
            .Select(e => new Pet(e){ HappinessDaysCount = e.HappinessDaysCount + EF.Functions.DateDiffDay(EF.Functions.DateFromParts(e.LastPetDetailsUpdatingTime.Year, e.LastPetDetailsUpdatingTime.Month, e.LastPetDetailsUpdatingTime.Day), EF.Functions.DateFromParts(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)) })
            .OrderByDescending(e => e.HappinessDaysCount)
            .ToListAsync();

        public async Task<IEnumerable<Pet>> GetUserPetsAsync(Guid userId) =>
            await GetAll(false)
            .Include(e => e.Farm)
            .Where(e => e.Farm.UserId.Equals(userId))
            .ToListAsync();

        public async Task<int> GetFarmDeadPetsCountAsync(Guid farmId) =>
            await GetByCondition(e => e.FarmId.Equals(farmId), false)
            .Where(e => !e.IsAlive)
            .CountAsync();

        public async Task<int> GetFarmAlivePetsCountAsync(Guid farmId) =>
            await GetByCondition(e => e.FarmId.Equals(farmId), false)
            .Where(e => e.IsAlive)
            .CountAsync();

        public async Task<double> GetFarmAverageHappinessDaysCountAsync(Guid farmId) =>
            await GetByCondition(e => e.FarmId.Equals(farmId), false)
            .Select(e => e.HappinessDaysCount)
            .AverageAsync();

        public void UpdatePet(Pet pet) => Update(pet);
    }
}
