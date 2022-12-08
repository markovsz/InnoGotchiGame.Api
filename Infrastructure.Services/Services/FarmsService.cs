using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Helpers;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
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
            var farm = _mapper.Map<Farm>(farmDto);
            farm.UserId = userId;
            await _repositoryManager.Farms.CreateFarmAsync(farm);
            await _repositoryManager.SaveChangeAsync();
            return farm.Id;
        }

        public async Task DeleteFarmByIdAsync(Guid farmId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByIdAsync(farmId, false);
            _repositoryManager.Farms.DeleteFarm(farm);
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task DeleteFarmByUserIdAsync(Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByUserIdAsync(userId, false);
            _repositoryManager.Farms.DeleteFarm(farm);
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task<FarmReadingDto> GetFarmByUserIdAsync(Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByUserIdAsync(userId, false);
            var farmDto = _mapper.Map<FarmReadingDto>(farm);
            return farmDto;
        }

        public async Task<FarmMinReadingDto> GetMinFarmByUserIdAsync(Guid userId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByUserIdAsync(userId, false);
            var farmDto = _mapper.Map<FarmMinReadingDto>(farm);
            return farmDto;
        }

        public async Task<FarmReadingDto> GetFarmByIdAsync(Guid farmId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByIdAsync(farmId, false);
            var farmDto = _mapper.Map<FarmReadingDto>(farm);
            return farmDto;
        }

        public async Task<FarmMinReadingDto> GetMinFarmByIdAsync(Guid farmId)
        {
            var farm = await _repositoryManager.Farms.GetFarmByIdAsync(farmId, false);
            var farmDto = _mapper.Map<FarmMinReadingDto>(farm);
            return farmDto;
        }

        public async Task<IEnumerable<FarmMinReadingDto>> GetFriendFarmsAsync(Guid userId)
        {
            var farms = await _repositoryManager.Farms.GetFriendFarmsAsync(userId);
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
            if (farm.UserId != userId)
                throw new InvalidOperationException("you can't update this farm");
            var farmForUpdating = _mapper.Map<Farm>(farmDto);
            _repositoryManager.Farms.UpdateFarm(farm);
            await _repositoryManager.SaveChangeAsync();
        }
    }
}
