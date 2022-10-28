using Domain.Core.Models;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class UsersInfoRepository : BaseRepository<UserInfo>, IUsersInfoRepository
    {
        public UsersInfoRepository(RepositoryContext context)
            : base(context)
        {
        }

        public async Task CreateUserInfoAsync(UserInfo userInfo) => await CreateAsync(userInfo);

        public void DeleteUserInfo(UserInfo userInfo) => Delete(userInfo);

        public async Task<UserInfo> GetUserInfoByUserIdAsync(Guid userId, bool trackChanges) =>
            await GetByCondition(e => e.UserId.Equals(userId), trackChanges)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<UserInfo>> GetUsersInfoAsync() =>
            await GetAll(false)
            .ToListAsync();

        public void UpdateUserInfo(UserInfo userInfo) => Update(userInfo);
    }
}
