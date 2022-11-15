using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Reading;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Infrastructure.Services.Exceptions;

namespace Infrastructure.Services.Services
{
    public class PetsService : IPetsService
    {
        private IFeedingEventsService _feedingEventsService;
        private IThirstQuenchingEventsService _thirstQuenchingEventsService;
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public PetsService(IFeedingEventsService feedingEventsService, IThirstQuenchingEventsService thirstQuenchingEventsService, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _feedingEventsService = feedingEventsService;
            _thirstQuenchingEventsService = thirstQuenchingEventsService;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Guid> CreatePetAsync(PetCreatingDto petDto)
        {
            var pet = _mapper.Map<Pet>(petDto);
            await _repositoryManager.Pets.CreatePetAsync(pet);
            pet.BirthDate = DateTime.Now;
            pet.HungerValue = HungerLevels.FullMinHungerValue;
            pet.ThirstValue = ThirstLevels.FullMinThirstValue;
            pet.IsAlive = true;
            pet.HappinessDaysCount = 0;
            pet.DeathDate = CalculateDeathDate(pet.HungerValue, pet.ThirstValue, DateTime.Now);
            pet.LastPetDetailsUpdatingTime = DateTime.Now;
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

        public async Task FeedPetAsync(Guid petId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, true);

            await UpdatePetVitalSignsAsync(pet, DateTime.Now);
            if (!pet.IsAlive)
                throw new PetIsDeadException("you can't feed a dead pet");

            if (pet.HungerValue >= HungerLevels.FullMinHungerValue)
                throw new PetIsAlreadyFullException("your pet is already full");

            await _feedingEventsService.CreateFeedingEventAsync(new FeedingEventCreatingDto { PetId = pet.Id });
            pet.HungerValue += PetSettings.FeedingUnit;
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task QuenchPetThirstAsync(Guid petId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, true);

            await UpdatePetVitalSignsAsync(pet, DateTime.Now);
            if (!pet.IsAlive) 
                throw new PetIsDeadException("you can't feed a dead pet");

            if (pet.ThirstValue >= ThirstLevels.FullMinThirstValue)
                throw new PetIsAlreadyFullException("your pet is already full");

            await _thirstQuenchingEventsService.CreateThirstQuenchingEventAsync(new ThirstQuenchingEventCreatingDto { PetId = pet.Id });
            pet.ThirstValue += PetSettings.ThirstQuenchingUnit;
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task<PetReadingDto> GetPetByIdAsync(Guid petId)
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, false);
            await UpdatePetVitalSignsAsync(pet, DateTime.Now);
            var petDto = _mapper.Map<PetReadingDto>(pet);
            return petDto;
        }

        public async Task<IEnumerable<PetMinReadingDto>> GetPetsAsync()
        {
            var pets = await _repositoryManager.Pets.GetPetsAsync();
            foreach (var pet in pets)
                await UpdatePetVitalSignsAsync(pet, DateTime.Now);
            var petsDto = _mapper.Map<IEnumerable<PetMinReadingDto>>(pets);
            return petsDto;
        }

        public async Task<IEnumerable<PetReadingDto>> GetUserPetsAsync(Guid userId)
        {
            var pets = await _repositoryManager.Pets.GetUserPetsAsync(userId);
            foreach (var pet in pets)
                await UpdatePetVitalSignsAsync(pet, DateTime.Now);
            var petsDto = _mapper.Map<IEnumerable<PetReadingDto>>(pets);
            return petsDto;
        }

        public async Task UpdatePetAsync(Guid petId, PetUpdatingDto petDto)
        {
            var pet = _mapper.Map<Pet>(petDto);
            pet.Id = petId;
            _repositoryManager.Pets.UpdatePet(pet);
            await _repositoryManager.SaveChangeAsync();
        }

        public async Task<DateTime> TimeLeftBeforeHungerAsync(Guid petId) //TODO: add checks of death
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, false);
            var hungerValue = CalculateHungerValueAtTime(pet.HungerValue, pet.LastPetDetailsUpdatingTime, DateTime.Now);
            var hours = (hungerValue - HungerLevels.NormalMinHungerValue) / PetSettings.HungerUnitsPerPetsHour / PetSettings.PetsTimeConstant;
            return DateTime.Now.AddHours(hours);
        }

        public async Task<DateTime> TimeLeftBeforeThirstAsync(Guid petId) //TODO: add checks of death
        {
            var pet = await _repositoryManager.Pets.GetPetByIdAsync(petId, false);
            var thirstValue = CalculateThirstValueAtTime(pet.ThirstValue, pet.LastPetDetailsUpdatingTime, DateTime.Now);
            var hours = (thirstValue - ThirstLevels.NormalMinThirstValue) / PetSettings.ThirstUnitsPerPetsHour / PetSettings.PetsTimeConstant;
            return DateTime.Now.AddHours(hours);
        }




        public async Task UpdatePetVitalSignsAsync(Pet pet, DateTime updationTime) {
            var hungerValue = CalculateHungerValueAtTime(pet.HungerValue, pet.LastPetDetailsUpdatingTime, updationTime);
            var thirstValue = CalculateThirstValueAtTime(pet.ThirstValue, pet.LastPetDetailsUpdatingTime, updationTime);
            pet.HungerValue = hungerValue;
            pet.ThirstValue = thirstValue;
            pet.LastPetDetailsUpdatingTime = updationTime;
            if (hungerValue >= HungerLevels.NormalMinHungerValue && thirstValue >= ThirstLevels.NormalMinThirstValue)
            {
                pet.HappinessDaysCount = GetPetHappinessDaysCountAtTime(pet.HappinessDaysCount, pet.LastPetDetailsUpdatingTime, updationTime);
                return;
            }
            if (!IsPetAlive(hungerValue, thirstValue)) await MakePetDeadAsync(pet, hungerValue, thirstValue, updationTime);
        }

        public float CalculateHungerValueAtTime(float hungerValue, DateTime lastPetDetailsUpdatingTime, DateTime time)
        {
            var lastFeedingTimeSpan = time.Subtract(lastPetDetailsUpdatingTime).Multiply(PetSettings.PetsTimeConstant); // in pet's time
            hungerValue -= (float) (lastFeedingTimeSpan.TotalHours) * PetSettings.HungerUnitsPerPetsHour;

            return hungerValue;
        }

        public float CalculateThirstValueAtTime(float thirstValue, DateTime lastPetDetailsUpdatingTime, DateTime time)
        {
            var lastThirstQuenchingTimeSpan = time.Subtract(lastPetDetailsUpdatingTime).Multiply(PetSettings.PetsTimeConstant); // in pet's time
            thirstValue -= (float)(lastThirstQuenchingTimeSpan.TotalHours) * PetSettings.ThirstUnitsPerPetsHour;

            return thirstValue;
        }

        public int GetPetHappinessDaysCountAtTime(int happinessDaysCount, DateTime lastPetDetailsUpdatingTime, DateTime time)
        {
            var newPetDetailsUpdatingTime = new DateTime(lastPetDetailsUpdatingTime.Year, lastPetDetailsUpdatingTime.Month, lastPetDetailsUpdatingTime.Day);
            var today = new DateTime(time.Year, time.Month, time.Day);
            var happinessDays = happinessDaysCount + today.Subtract(newPetDetailsUpdatingTime).Days;
            return happinessDays;
        }

        public DateTime CalculateDeathDate(float updatedHungerValue, float updatedThirstValue, DateTime now)
        {
            float timeSpanByHungerValue = (updatedHungerValue - HungerLevels.HungerMinHungerValue) / PetSettings.HungerUnitsPerPetsHour / PetSettings.PetsTimeConstant;
            float timeSpanByThirstValue = (updatedThirstValue - ThirstLevels.ThirstyMinThirstValue) / PetSettings.ThirstUnitsPerPetsHour / PetSettings.PetsTimeConstant;
            return now.AddHours(timeSpanByHungerValue > timeSpanByThirstValue ? timeSpanByThirstValue : timeSpanByHungerValue);
        }

        public bool IsPetAlive(float hungerValue, float thirstValue)
        {
            if (hungerValue >= HungerLevels.HungerMinHungerValue && thirstValue >= ThirstLevels.ThirstyMinThirstValue) return true;
            return false;
        }

        public async Task MakePetDeadAsync(Pet pet, float updatedHungerValue, float updatedThirstValue, DateTime now)
        {
            if (IsPetAlive(updatedHungerValue, updatedThirstValue))
                throw new InvalidOperationException("can't kill the pet");
            pet.DeathDate = CalculateDeathDate(updatedHungerValue, updatedThirstValue, now);
            pet.IsAlive = false;
            _repositoryManager.Pets.UpdatePet(pet);
            await _repositoryManager.SaveChangeAsync();
        }
    }
}
