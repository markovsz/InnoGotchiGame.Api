using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Helpers;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services.Exceptions;
using Infrastructure.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services.Services
{
    public class PetsService : IPetsService
    {
        private IFeedingEventsService _feedingEventsService;
        private IThirstQuenchingEventsService _thirstQuenchingEventsService;
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;
        private IDateTimeConverter _dateTimeConverter;
        private IPetStatsCalculatingService _petStatsCalculatingService;

        public PetsService(IFeedingEventsService feedingEventsService, IThirstQuenchingEventsService thirstQuenchingEventsService, IRepositoryManager repositoryManager, IMapper mapper, IPetStatsCalculatingService petStatsCalculatingService, IDateTimeConverter dateTimeConverter)
        {
            _feedingEventsService = feedingEventsService;
            _thirstQuenchingEventsService = thirstQuenchingEventsService;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _petStatsCalculatingService = petStatsCalculatingService;
            _dateTimeConverter = dateTimeConverter;
        }

        public async Task<Guid> CreatePetAsync(PetCreatingDto petDto, Guid userId)
        {
            var user = await _repositoryManager.Farms.GetFarmByIdAsync(petDto.FarmId, false);
            if (user.UserId != userId)
                throw new InvalidOperationException("you don't have permissions");

            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);

            var pet = _mapper.Map<Pet>(petDto);
            await _repositoryManager.Pets.CreatePetAsync(pet);
            pet.BirthDate = now;
            pet.HungerValue = HungerLevels.FullMinHungerValue;
            pet.ThirstValue = ThirstLevels.FullMinThirstValue;
            pet.IsAlive = true;
            pet.HappinessDaysCount = 0;
            pet.DeathDate = _petStatsCalculatingService.CalculateDeathDate(pet.HungerValue, pet.ThirstValue, now);
            pet.LastPetDetailsUpdatingTime = now;
            await _repositoryManager.SaveChangeAsync();
            var feedingEvent = new FeedingEventCreatingDto { PetId = pet.Id };
            await _feedingEventsService.CreateFeedingEventAsync(feedingEvent);
            var thirstQuenchingEvent = new ThirstQuenchingEventCreatingDto { PetId = pet.Id };
            await _thirstQuenchingEventsService.CreateThirstQuenchingEventAsync(thirstQuenchingEvent);
            return pet.Id;
        }

        public async Task DeletePetByIdAsync(Guid petId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, false);
            _repositoryManager.Pets.DeletePet(pet);
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task<string> FeedPetAsync(Guid petId, Guid userId)
        {

            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, true);
            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            pet = _petStatsCalculatingService.UpdatePetVitalSignsAsync(pet, now);
            var farm = await _repositoryManager.Farms.GetFarmByUserIdAsync(userId, false);
            var friendFarms = await _repositoryManager.Farms.GetFriendFarmsAsync(userId);
            if (!friendFarms.Where(e => e.Pets.Where(p => p.Id.Equals(petId)).Any()).Any() && farm.UserId != userId)
                throw new InvalidOperationException("you can't feed this pet");

            if (!pet.IsAlive)
                throw new PetIsDeadException("you can't feed a dead pet");

            if (pet.HungerValue >= HungerLevels.FullMinHungerValue)
                throw new PetIsAlreadyFullException("your pet is already full");

            await _feedingEventsService.CreateFeedingEventAsync(new FeedingEventCreatingDto { PetId = pet.Id });
            pet.HungerValue += PetSettings.FeedingUnit;
            await _repositoryManager.SaveChangeAsync();
            return HungerLevels.GetHungerLevelName(pet.HungerValue);
        }

        public async Task<string> QuenchPetThirstAsync(Guid petId, Guid userId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, true);
            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            pet = _petStatsCalculatingService.UpdatePetVitalSignsAsync(pet, now);
            var farm = await _repositoryManager.Farms.GetFarmByUserIdAsync(userId, false);
            var friendFarms = await _repositoryManager.Farms.GetFriendFarmsAsync(userId);
            if (!friendFarms.Where(e => e.Pets.Where(p => p.Id.Equals(petId)).Any()).Any() && farm.UserId != userId)
                throw new InvalidOperationException("you can't feed this pet");

            if (!pet.IsAlive) 
                throw new PetIsDeadException("you can't feed a dead pet");

            if (pet.ThirstValue >= ThirstLevels.FullMinThirstValue)
                throw new PetIsAlreadyFullException("your pet is already full");

            await _thirstQuenchingEventsService.CreateThirstQuenchingEventAsync(new ThirstQuenchingEventCreatingDto { PetId = pet.Id });
            pet.ThirstValue += PetSettings.ThirstQuenchingUnit;
            await _repositoryManager.SaveChangeAsync();
            return ThirstLevels.GetThirstLevelName(pet.ThirstValue);
        }

        public async Task<PetReadingDto> GetPetByIdAsync(Guid petId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, false);
            var petDto = _mapper.Map<PetReadingDto>(pet);
            return petDto;
        }

        public async Task<IEnumerable<PetMinReadingDto>> GetPetsAsync()
        {
            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            var pets = await _repositoryManager.Pets.GetPetsAsync(now);
            var petsDto = _mapper.Map<IEnumerable<PetMinReadingDto>>(pets);
            return petsDto;
        }

        public async Task<IEnumerable<PetReadingDto>> GetUserPetsAsync(Guid userId)
        {
            var now = _dateTimeConverter.ConvertToPetsTime(DateTime.Now);
            var pets = await _repositoryManager.Pets.GetUserPetsAsync(userId, now);
            var petsDto = _mapper.Map<IEnumerable<PetReadingDto>>(pets);
            return petsDto;
        }

        public async Task UpdatePetAsync(PetUpdatingDto petDto, Guid userId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petDto.petId, false);
            var farm = await _repositoryManager.Farms.GetFarmByIdAsync(pet.FarmId, false);
            if (farm.UserId != userId)
                throw new InvalidOperationException("you can't update this pet");

            var petForUpdating = _mapper.Map<Pet>(petDto);
            pet.Id = petDto.petId;
            _repositoryManager.Pets.UpdatePet(petForUpdating);
            await _repositoryManager.SaveChangeAsync();
        }




        
    }
}
