using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Services.Exceptions;
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

        public async Task<Guid> CreateFarmFriendAsync(FarmFriendCreatingDto farmFriendDto, Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByUserIdAsync(userId, false);
            if (farm.Id != farmFriendDto.FarmId)
                throw new AccessException("you can't invite friends to a other's farm");
            var farmFriend = _mapper.Map<FarmFriendCreatingDto, FarmFriend>(farmFriendDto);
            await _repositoryManager.FarmFriends.CreateFarmFriendAsync(farmFriend);
            await _repositoryManager.SaveChangeAsync();
            return farmFriend.Id;
        }

        public async Task DeleteFarmFriendByIdAsync(Guid farmFriendId, Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByUserIdAsync(userId, false);
            var farmFriend = await _repositoryManager.FarmFriends.GetFarmFriendByIdAsync(farmFriendId, false);
            if (farm.Id != farmFriend.FarmId)
                throw new AccessException("you can't delete friends from an other's farm");
            _repositoryManager.FarmFriends.DeleteFarmFriend(farmFriend);
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task<IEnumerable<FarmFriendReadingDto>> GetUserFarmFriendsAsync(Guid userId)
        {
            var farmFriends = await _repositoryManager.FarmFriends.GetFarmFriendsByUserIdAsync(userId);
            var farmFriendsDto = _mapper.Map<IEnumerable<FarmFriend>, IEnumerable<FarmFriendReadingDto>>(farmFriends);
            return farmFriendsDto;
        }
    }
}
