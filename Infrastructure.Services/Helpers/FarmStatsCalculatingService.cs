using Application.Services.DataTransferObjects.Reading;
using Application.Services.Helpers;
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
        private IRepositoryManager _repositoryManager;
        public FarmStatsCalculatingService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<FarmReadingDto> UpdateFarmStatsAsync(FarmReadingDto farmDto, long now)
        {
            farmDto.AlivePetsCount = await _repositoryManager.Pets.GetFarmAlivePetsCountAsync(farmDto.Id);
            farmDto.DeadPetsCount = await _repositoryManager.Pets.GetFarmDeadPetsCountAsync(farmDto.Id);
            if(farmDto.Pets.Any()) farmDto.AverageHappinessDaysCount = (int)await _repositoryManager.Pets.GetFarmAverageHappinessDaysCountAsync(farmDto.Id, now);
            if (farmDto.Pets.Any()) farmDto.AveragePetsAge = (int)await _repositoryManager.Pets.GetFarmAveragePetsAgeAsync(farmDto.Id, now);
            return farmDto;
        }

        public async Task<FarmMinReadingDto> UpdateMinFarmStatsAsync(FarmMinReadingDto farmDto, long now)
        {
            farmDto.AlivePetsCount = await _repositoryManager.Pets.GetFarmAlivePetsCountAsync(farmDto.Id);
            farmDto.DeadPetsCount = await _repositoryManager.Pets.GetFarmDeadPetsCountAsync(farmDto.Id);
            if(await _repositoryManager.Pets.GetFarmAlivePetsCountAsync(farmDto.Id) > 0) farmDto.AverageHappinessDaysCount = (int)await _repositoryManager.Pets.GetFarmAverageHappinessDaysCountAsync(farmDto.Id, now);
            if (await _repositoryManager.Pets.GetFarmAlivePetsCountAsync(farmDto.Id) > 0) farmDto.AveragePetsAge = (int)await _repositoryManager.Pets.GetFarmAveragePetsAgeAsync(farmDto.Id, now);
            return farmDto;
        }
    }
}
