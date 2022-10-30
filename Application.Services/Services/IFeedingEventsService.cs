using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public interface IFeedingEventsService
    {
        Task<Guid> CreateFeedingEventAsync(FeedingEventCreatingDto thirstQuenchingEventDto);
        Task<FeedingEventReadingDto> GetFeedingEventByIdAsync(Guid eventId);
        Task<FeedingEventReadingDto> GetLastPetFeedingEventAsync(Guid petId);
        Task<IEnumerable<FeedingEventReadingDto>> GetPetFeedingEventsAsync(Guid petId);
        Task<IEnumerable<DateTime>> GetHungerDaysAsync(Guid petId);
        Task DeleteFeedingEventByIdAsync(Guid eventId);
    }
}
