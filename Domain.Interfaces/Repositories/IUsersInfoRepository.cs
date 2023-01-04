using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUsersInfoRepository
    {
        Task CreateUserInfoAsync(UserInfo userInfo);
        Task<UserInfo> GetUserInfoByUserIdAsync(Guid userId, bool trackChanges);
        Task<IEnumerable<UserInfo>> GetUsersInfoAsync();
        void UpdateUserInfo(UserInfo userInfo);
        void DeleteUserInfo(UserInfo userInfo);
    }
}
