using Application.Services.DataTransferObjects.Reading;
using Application.Services.Helpers;
using Application.Services.Services;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Helpers
{
    public class FarmStatsCalculatingService : IFarmStatsCalculatingService
    {
        private IPetStatsCalculatingService _petStatsCalculatingService;
        private IRepositoryManager _repositoryManager;
        private IFeedingFarmStatsService _feedingFarmStatsService;
        private IThirstQuenchingFarmStatsService _thirstQuenchingFarmStatsService;

        public FarmStatsCalculatingService(IPetStatsCalculatingService petStatsCalculatingService, IFeedingFarmStatsService feedingFarmStatsService, IThirstQuenchingFarmStatsService thirstQuenchingFarmStatsService, IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _feedingFarmStatsService = feedingFarmStatsService;
            _thirstQuenchingFarmStatsService = thirstQuenchingFarmStatsService;
            _petStatsCalculatingService = petStatsCalculatingService;
        }

        public async Task<FarmReadingDto> UpdateFarmStatsAsync(FarmReadingDto farmDto, long now)
        {
            await _petStatsCalculatingService.UpdateFarmPetsVitalSignsAsync(farmDto.Id, now);
            farmDto.AlivePetsCount = await _repositoryManager.Pets.GetFarmAlivePetsCountAsync(farmDto.Id, now);
            farmDto.DeadPetsCount = await _repositoryManager.Pets.GetFarmDeadPetsCountAsync(farmDto.Id, now);
            if(farmDto.Pets.Any()) farmDto.AverageHappinessDaysCount = (int)await _repositoryManager.Pets.GetFarmAverageHappinessDaysCountAsync(farmDto.Id, now);
            if (farmDto.Pets.Any()) farmDto.AveragePetsAge = (int)await _repositoryManager.Pets.GetFarmAveragePetsAgeAsync(farmDto.Id, now);
            farmDto.AverageFeedingTime = (float)await _feedingFarmStatsService.GetFarmAverageTimeBetweenFeedingAsync(farmDto.Id);
            farmDto.AverageThirstQuenchingTime = (float)await _thirstQuenchingFarmStatsService.GetFarmAverageTimeBetweenThirstQuenchingAsync(farmDto.Id);
            return farmDto;
        }

        public async Task<FarmMinReadingDto> UpdateMinFarmStatsAsync(FarmMinReadingDto farmDto, long now)
        {
            await _petStatsCalculatingService.UpdateFarmPetsVitalSignsAsync(farmDto.Id, now);
            farmDto.AlivePetsCount = await _repositoryManager.Pets.GetFarmAlivePetsCountAsync(farmDto.Id, now);
            farmDto.DeadPetsCount = await _repositoryManager.Pets.GetFarmDeadPetsCountAsync(farmDto.Id, now);
            if(farmDto.AlivePetsCount > 0) farmDto.AverageHappinessDaysCount = (int)await _repositoryManager.Pets.GetFarmAverageHappinessDaysCountAsync(farmDto.Id, now);
            if (farmDto.AlivePetsCount > 0) farmDto.AveragePetsAge = (int)await _repositoryManager.Pets.GetFarmAveragePetsAgeAsync(farmDto.Id, now);
            farmDto.AverageFeedingTime = (float)await _feedingFarmStatsService.GetFarmAverageTimeBetweenFeedingAsync(farmDto.Id);
            farmDto.AverageThirstQuenchingTime = (float)await _thirstQuenchingFarmStatsService.GetFarmAverageTimeBetweenThirstQuenchingAsync(farmDto.Id);
            return farmDto;
        }
    }
}
