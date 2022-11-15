using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.Services
{
    public class FarmFriendsService : IFarmFriendsService
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public FarmFriendsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Guid> CreateFarmFriendAsync(FarmFriendCreatingDto farmFriendDto)
        {
            var farmFriend = _mapper.Map<FarmFriend>(farmFriendDto);
            await _repositoryManager.FarmFriends.CreateFarmFriendAsync(farmFriend);
            await _repositoryManager.SaveChangeAsync();
            return farmFriend.Id;
        }

        public async Task DeleteFarmFriendByIdAsync(Guid farmFriendId)
        {
            var farmFriend = await _repositoryManager.FarmFriends.GetFarmFriendByIdAsync(farmFriendId, false);
            _repositoryManager.FarmFriends.DeleteFarmFriend(farmFriend);
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task<IEnumerable<FarmFriendReadingDto>> GetUserFarmFriendsAsync(Guid userId)
        {
            var farmFriends = await _repositoryManager.FarmFriends.GetFarmFriendsByUserIdAsync(userId);
            var farmFriendsDto = _mapper.Map<IEnumerable<FarmFriendReadingDto>>(farmFriends);
            return farmFriendsDto;
        }
    }
}
