using Domain.Core.Models;
using Domain.Interfaces.RequestParameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IPetsRepository
    {
        Task CreatePetAsync(Pet pet);
        Task<Pet> GetPetByIdAsync(Guid petId, bool trackChanges);
        Task<IEnumerable<Pet>> GetUserPetsAsync(Guid userId, long now);
        Task<IEnumerable<Pet>> GetPetsAsync(PetParameters parameters, long now);
        Task<int> GetPetsCountAsync(long now);
        Task<int> GetFarmDeadPetsCountAsync(Guid farmId);
        Task<int> GetFarmAlivePetsCountAsync(Guid farmId);
        Task<double> GetFarmAverageHappinessDaysCountAsync(Guid farmId, long now);
        Task<double> GetFarmAveragePetsAgeAsync(Guid farmId, long now);
        void UpdatePet(Pet pet);
        void DeletePet(Pet pet);
    }
}
