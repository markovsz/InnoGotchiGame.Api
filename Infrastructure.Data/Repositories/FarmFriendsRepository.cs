using Domain.Core.Models;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class FarmFriendsRepository : BaseRepository<FarmFriend>, IFarmFriendsRepository
    {
        public FarmFriendsRepository(RepositoryContext context)
            : base(context)
        {
        }

        public Task CreateFarmFriendAsync(FarmFriend farmFriend) => CreateAsync(farmFriend);

        public void DeleteFarmFriend(FarmFriend farmFriend) => Delete(farmFriend);

        public async Task<FarmFriend> GetFarmFriendByIdAsync(Guid farmFriendId, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(farmFriendId), trackChanges)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<FarmFriend>> GetFarmFriendsAsync() =>
            await GetAll(false)
            .ToListAsync();

        public async Task<IEnumerable<FarmFriend>> GetFarmFriendsByFarmIdAsync(Guid farmId) =>
            await GetByCondition(e => e.FarmId.Equals(farmId), false)
            .ToListAsync();

        public async Task<IEnumerable<FarmFriend>> GetFarmFriendsByUserIdAsync(Guid userId) =>
            await GetByCondition(e => e.UserInfo.Equals(userId), false)
            .ToListAsync();

        public void UpdateFarmFriend(FarmFriend farmFriend) => Update(farmFriend);
    }
}
