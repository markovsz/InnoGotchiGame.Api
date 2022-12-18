using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IFarmsRepository
    {
        Task CreateFarmAsync(Farm farm);
        Task<Farm> GetFarmByIdAsync(Guid farmId, bool trackChanges);
        Task<Farm> GetFarmByUserIdAsync(Guid userId, bool trackChanges);
        Task<Farm> GetFriendFarmAsync(Guid userId, Guid friendId);
        Task<IEnumerable<Farm>> GetFriendFarmsAsync(Guid userId);
        Task<IEnumerable<Farm>> GetFarmsAsync();
        void UpdateFarm(Farm farm);
        void DeleteFarm(Farm farm);
    }
}
