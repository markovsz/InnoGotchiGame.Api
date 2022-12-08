using Domain.Core.Models;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class FarmsRepository : BaseRepository<Farm>, IFarmsRepository
    {
        private RepositoryContext _context;

        public FarmsRepository(RepositoryContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task CreateFarmAsync(Farm farm) => await CreateAsync(farm);

        public void DeleteFarm(Farm farm) => Delete(farm);

        public async Task<Farm> GetFarmByIdAsync(Guid farmId, bool trackChanges) => 
            await GetByCondition(e => e.Id.Equals(farmId), trackChanges)
            .Include(e => e.Pets)
            .Include(e => e.FarmFriends)
                .ThenInclude(e => e.UserInfo)
            .FirstOrDefaultAsync();
        
        public async Task<Farm> GetFarmByUserIdAsync(Guid userId, bool trackChanges) =>
            await GetByCondition(e => e.UserId.Equals(userId), trackChanges)
            .Include(e => e.Pets)
            .Include(e => e.FarmFriends)
                .ThenInclude(e => e.UserInfo)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Farm>> GetFarmsAsync() => 
            await GetAll(false)
            .ToListAsync();

        public async Task<IEnumerable<Farm>> GetFriendFarmsAsync(Guid userId) =>
            await _context.FarmFriends
            .Include(e => e.Farm)
                .ThenInclude(e => e.Pets)
            .Where(e => e.UserId.Equals(userId))
            .Select(e => e.Farm)
            .ToListAsync();


        public void UpdateFarm(Farm farm) => Update(farm);
    }
}
