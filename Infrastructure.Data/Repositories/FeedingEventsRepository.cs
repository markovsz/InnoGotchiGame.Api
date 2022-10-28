using Domain.Core.Models;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class FeedingEventsRepository : BaseRepository<FeedingEvent>, IFeedingEventsRepository
    {
        public FeedingEventsRepository(RepositoryContext context)
            : base(context)
        {
        }

        public async Task CreateFeedingEventAsync(FeedingEvent feedingEvent) => await CreateAsync(feedingEvent);

        public void DeleteFeedingEvent(FeedingEvent feedingEvent) => Delete(feedingEvent);

        public async Task<FeedingEvent> GetFeedingEventByIdAsync(Guid feedingEventId, bool trackChanges) =>
            await GetByCondition(e => e.Id.Equals(feedingEventId), trackChanges)
            .FirstOrDefaultAsync();

        public async Task<FeedingEvent> GetLastPetFeedingEventAsync(Guid petId, bool trackChanges) =>
            await GetByCondition(e => e.PetId.Equals(petId), trackChanges)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<DateTime>> GetHungerDaysAsync(Guid petId) =>
            await GetByCondition(e => e.PetId.Equals(petId), false)
            .Where(e => e.HungerValueBefore < HungerLevels.NormalMinHungerValue)
            .Select(e => new DateTime(e.FeedingTime.Year, e.FeedingTime.Month, e.FeedingTime.Day))
            .Distinct()
            .ToListAsync();

        public async Task<IEnumerable<FeedingEvent>> GetPetFeedingEventsAsync(Guid petId) =>
            await GetByCondition(e => e.PetId.Equals(petId), false)
            .ToListAsync();

        public void UpdateFeedingEvent(FeedingEvent feedingEvent) => Update(feedingEvent);
    }
}
