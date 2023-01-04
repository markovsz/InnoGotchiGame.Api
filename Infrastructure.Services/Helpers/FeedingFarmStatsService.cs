using Application.Services.Helpers;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Helpers
{
    public class FeedingFarmStatsService : IFeedingFarmStatsService
    {
        private IRepositoryManager _repositoryManager;
        private IDateTimeConverter _dateTimeConverter;

        public FeedingFarmStatsService(IRepositoryManager repositoryManager, IDateTimeConverter dateTimeConverter)
        {
            _repositoryManager = repositoryManager;
            _dateTimeConverter = dateTimeConverter;
        }

        public async Task<double> GetFarmAverageTimeBetweenFeedingAsync(Guid farmId)
        {
            var farmFeedingEventsList = await _repositoryManager.FeedingEvents.GetFarmFeedingEventsAsync(farmId);
            var farmFeedingTimes = farmFeedingEventsList.Select(e => e.FeedingTime); //TODO: fix convertation
            var farmFeedingTimesList = farmFeedingTimes.ToList(); //TODO: fix convertation


            if (farmFeedingTimesList.Count <= 1)
                return 0;

            long sumOfTimeSpans = 0;
            for (int i = 1; i < farmFeedingTimesList.Count; ++i)
            {
                var span = (farmFeedingTimesList[i] - farmFeedingTimesList[i - 1]);
                sumOfTimeSpans += span;
            }
            sumOfTimeSpans /= farmFeedingTimesList.Count() - 1;

            return _dateTimeConverter.GetTotalDays(sumOfTimeSpans);
        }
    }
}
