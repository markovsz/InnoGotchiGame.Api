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
        Task DeleteFeedingEventByIdAsync(Guid eventId);
    }
}
