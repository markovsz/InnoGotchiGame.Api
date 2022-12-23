using Application.Services.Helpers;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Helpers
{
    public class ThirstQuenchingFarmStatsService : IThirstQuenchingFarmStatsService
    {
        private IRepositoryManager _repositoryManager;
        private IDateTimeConverter _dateTimeConverter;

        public ThirstQuenchingFarmStatsService(IRepositoryManager repositoryManager, IDateTimeConverter dateTimeConverter)
        {
            _repositoryManager = repositoryManager;
            _dateTimeConverter = dateTimeConverter;
        }

        public async Task<double> GetFarmAverageTimeBetweenThirstQuenchingAsync(Guid farmId)
        {
            var farmThirstQuenchingEventsList = await _repositoryManager.ThirstQuenchingEvents.GetFarmThirstQuenchingEventsAsync(farmId);
            var farmThirstQuenchingTimes = farmThirstQuenchingEventsList.Select(e => e.ThirstQuenchingTime);
            var farmThirstQuenchingTimesList = farmThirstQuenchingTimes.ToList();

            if (farmThirstQuenchingTimesList.Count <= 1)
                return 0;

            long sumOfTimeSpans = 0;
            for (int i = 1; i < farmThirstQuenchingTimesList.Count; ++i)
            {
                sumOfTimeSpans += (farmThirstQuenchingTimesList[i] - farmThirstQuenchingTimesList[i - 1]);
            }
            sumOfTimeSpans /= farmThirstQuenchingTimesList.Count() - 1;

            return _dateTimeConverter.GetTotalDays(sumOfTimeSpans);
        }
    }
}
