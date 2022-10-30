using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public interface IFarmFriendsService
    {
        Task<Guid> CreateFarmFriendAsync(FarmFriendCreatingDto farmFriendDto);
        Task<IEnumerable<FarmFriendReadingDto>> GetUserFarmFriendsAsync(Guid userId);
        Task DeleteFarmFriendByIdAsync(Guid farmFriendId);
    }
}
