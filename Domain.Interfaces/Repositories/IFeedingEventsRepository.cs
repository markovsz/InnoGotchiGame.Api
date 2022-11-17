using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IFeedingEventsRepository
    {
        Task CreateFeedingEventAsync(FeedingEvent feedingEvent);
        Task<FeedingEvent> GetFeedingEventByIdAsync(Guid feedingEventId, bool trackChanges);
        Task<FeedingEvent> GetLastPetFeedingEventAsync(Guid petId, bool trackChanges);
        Task<IEnumerable<FeedingEvent>> GetPetFeedingEventsAsync(Guid petId);
        Task<IEnumerable<long>> GetHungerDaysAsync(Guid petId);
        void DeleteFeedingEvent(FeedingEvent feedingEvent);
    }
}
