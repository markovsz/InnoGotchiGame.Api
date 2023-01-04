using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public interface IThirstQuenchingEventsService
    {
        Task<Guid> CreateThirstQuenchingEventAsync(ThirstQuenchingEventCreatingDto thirstQuenchingEventDto);
        Task DeleteThirstQuenchingEventByIdAsync(Guid eventId);
    }
}
