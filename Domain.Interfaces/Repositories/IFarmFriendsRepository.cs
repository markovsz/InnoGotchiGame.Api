using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IFarmFriendsRepository
    {
        Task CreateFarmFriendAsync(FarmFriend farmFriend);
        Task<FarmFriend> GetFarmFriendByIdAsync(Guid farmFriendId, bool trackChanges);
        Task<IEnumerable<FarmFriend>> GetFarmFriendsByFarmIdAsync(Guid farmId);
        Task<IEnumerable<FarmFriend>> GetFarmFriendsByUserIdAsync(Guid userId);
        void UpdateFarmFriend(FarmFriend farmFriend);
        void DeleteFarmFriend(FarmFriend farmFriend);
    }
}
