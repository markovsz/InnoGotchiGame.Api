using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Helpers;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Infrastructure.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services.Services
{
    public class FarmsService : IFarmsService
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;
        private IDateTimeConverter _dateTimeConverter;

        public FarmsService(IRepositoryManager repositoryManager, IMapper mapper, IDateTimeConverter dateTimeConverter)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _dateTimeConverter = dateTimeConverter;
        }

        public async Task<Guid> CreateFarmAsync(Guid userId, FarmCreatingDto farmDto)
        {
            var farm = _mapper.Map<FarmCreatingDto, Farm>(farmDto);
            farm.UserId = userId;
            await _repositoryManager.Farms.CreateFarmAsync(farm);
            await _repositoryManager.SaveChangeAsync();
            return farm.Id;
        }

        public async Task DeleteFarmByIdAsync(Guid farmId, Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByIdAsync(farmId, false);
            if (farm is null)
                throw new EntityNotFoundException("farm was't found");
            if (farm.UserId != userId)
                throw new AccessException("you can't delete this farm");
            _repositoryManager.Farms.DeleteFarm(farm);
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task DeleteFarmByUserIdAsync(Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByUserIdAsync(userId, false);
            if (farm is null)
                throw new EntityNotFoundException("farm was't found");
            _repositoryManager.Farms.DeleteFarm(farm);
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task<FarmReadingDto> GetFarmByUserIdAsync(Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByUserIdAsync(userId, false);
            if (farm is null)
                throw new EntityNotFoundException("farm was't found");
            var farmDto = _mapper.Map<FarmReadingDto>(farm);
            return farmDto;
        }

        public async Task<FarmMinReadingDto> GetMinFarmByUserIdAsync(Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByUserIdAsync(userId, false);
            if (farm is null)
                throw new EntityNotFoundException("farm was't found");
            var farmDto = _mapper.Map<FarmMinReadingDto>(farm);
            return farmDto;
        }

        public async Task<FarmReadingDto> GetFarmByIdAsync(Guid farmId, Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByIdAsync(farmId, false);
            if (farm is null)
                throw new EntityNotFoundException("farm was't found");
            if (!IsUserFriendOfFarm(farm, userId) && farm.UserId != userId)
                throw new AccessException("you can't get this farm");
            var farmDto = _mapper.Map<FarmReadingDto>(farm);
            return farmDto;
        }

        public async Task<FarmMinReadingDto> GetMinFarmByIdAsync(Guid farmId, Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByIdAsync(farmId, false);
            if (farm is null)
                throw new EntityNotFoundException("farm was't found");
            if (!IsUserFriendOfFarm(farm, userId) && farm.UserId != userId)
                throw new AccessException("you can't get this farm");
            var farmDto = _mapper.Map<FarmMinReadingDto>(farm);
            return farmDto;
        }

        public async Task<IEnumerable<FarmMinReadingDto>> GetFriendFarmsAsync(Guid userId)
        {
            var farms = await _repositoryManager.Farms.GetFriendFarmsAsync(userId);
            var farmsDto = _mapper.Map<IEnumerable<FarmMinReadingDto>>(farms);
            return farmsDto;
        }

        public async Task<IEnumerable<FarmMinReadingDto>> GetFriendFarmAsync(Guid userId, Guid friendId)
        {
            var farms = await _repositoryManager.Farms.GetFriendFarmAsync(userId, friendId);
            var farmsDto = _mapper.Map<IEnumerable<FarmMinReadingDto>>(farms);
            return farmsDto;
        }

        public async Task<IEnumerable<FarmMinReadingDto>> GetFarmsAsync()
        {
            var farms = await _repositoryManager.Farms.GetFarmsAsync();
            var farmsDto = _mapper.Map<IEnumerable<FarmMinReadingDto>>(farms);
            return farmsDto;
        }

        public async Task UpdateFarmAsync(FarmUpdatingDto farmDto, Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByIdAsync(farmDto.Id, false);
            if (farm is null)
                throw new EntityNotFoundException("farm was't found");
            if (farm.UserId != userId)
                throw new AccessException("you can't update this farm");
            var farmForUpdating = _mapper.Map<Farm>(farmDto);
            _repositoryManager.Farms.UpdateFarm(farmForUpdating);
            await _repositoryManager.SaveChangeAsync();
        }

        private bool IsUserFriendOfFarm(Farm farm, Guid userId)
        {
            if (farm.FarmFriends is null)
                return false;
            var containsUser = farm.FarmFriends
                .Where(e => e.UserId.Equals(userId))
                .Any();
            return containsUser;
        }
    }
}
