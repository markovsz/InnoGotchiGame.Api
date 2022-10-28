using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IPetsRepository
    {
        Task CreatePetAsync(Pet pet);
        Task<Pet> GetPetByIdAsync(Guid petId, bool trackChanges);
        Task<IEnumerable<Pet>> GetUserPetsAsync(Guid userId);
        Task<IEnumerable<Pet>> GetPetsAsync();
        void UpdatePet(Pet pet);
        void DeletePet(Pet pet);
    }
}
