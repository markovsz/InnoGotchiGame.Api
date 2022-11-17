using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.Services
{
    public class FeedingEventsService : IFeedingEventsService
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public FeedingEventsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Guid> CreateFeedingEventAsync(FeedingEventCreatingDto feedingEventDto)
        {
            var feedingEvent = _mapper.Map<FeedingEvent>(feedingEventDto);
            feedingEvent.FeedingTime = DateTime.Now;

            var pet = await _repositoryManager.Pets.GetPetByIdAsync(feedingEventDto.PetId, false);
            feedingEvent.HungerValueBefore = pet.HungerValue;

            await _repositoryManager.FeedingEvents.CreateFeedingEventAsync(feedingEvent);
            await _repositoryManager.SaveChangeAsync();
            return feedingEvent.Id;
        }

        public async Task DeleteFeedingEventByIdAsync(Guid eventId)
        {
            var feedingEvent = await _repositoryManager.FeedingEvents.GetFeedingEventByIdAsync(eventId, false);
            _repositoryManager.FeedingEvents.DeleteFeedingEvent(feedingEvent);
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task<double> GetAverageTimeBetweenFeedingAsync(Guid petId)
        {
            throw new NotImplementedException();
        }
    }
}
