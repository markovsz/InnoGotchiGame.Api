﻿using Application.Services.Helpers;
using Domain.Core.Models;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services.Helpers;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services.Helpers
{
    public class PetStatsCalculatingService : IPetStatsCalculatingService
    {
        private IRepositoryManager _repositoryManager;
        private IDateTimeConverter _dateTimeConverter;

        public PetStatsCalculatingService(IRepositoryManager repositoryManager, IDateTimeConverter dateTimeConverter)
        {
            _repositoryManager = repositoryManager;
            _dateTimeConverter = dateTimeConverter;
        }

        public async Task UpdateFarmPetsVitalSignsAsync(Guid farmId, long updationTime)
        {
            var pets = await _repositoryManager.Pets.GetFarmPetsAsync(farmId, true);
            foreach (var pet in pets)
            {
                UpdatePetVitalSigns(pet, updationTime);
            }
            await _repositoryManager.SaveChangeAsync();
        }

        public Pet UpdatePetVitalSigns(Pet pet, long updationTime)
        {
            var hungerValue = CalculateHungerValueAtTime(pet.HungerValue, pet.LastPetDetailsUpdatingTime, updationTime);
            var thirstValue = CalculateThirstValueAtTime(pet.ThirstValue, pet.LastPetDetailsUpdatingTime, updationTime);
            pet.HungerValue = hungerValue;
            pet.ThirstValue = thirstValue;
            if (hungerValue >= HungerLevels.NormalMinHungerValue && thirstValue >= ThirstLevels.NormalMinThirstValue)
                pet.HappinessDaysCount = GetPetHappinessDaysCountAtTime(pet.HappinessDaysCount, pet.LastPetDetailsUpdatingTime, updationTime);
            else
                pet.HappinessDaysCount = 0;

            pet.DeathDate = CalculateDeathDate(hungerValue, thirstValue, updationTime);
            if (updationTime > pet.DeathDate && pet.LastPetDetailsUpdatingTime < pet.DeathDate)
            {
                pet.HappinessDaysCount = 0;
            }
            pet.LastPetDetailsUpdatingTime = updationTime;
            return pet;
        }

        public float CalculateHungerValueAtTime(float hungerValue, long lastPetDetailsUpdatingTime, long time)
        {
            var lastFeedingTimeSpan = _dateTimeConverter.GetHours(time - lastPetDetailsUpdatingTime);
            hungerValue -= lastFeedingTimeSpan * PetSettings.HungerUnitsPerPetsHour;

            return hungerValue;
        }

        public float CalculateThirstValueAtTime(float thirstValue, long lastPetDetailsUpdatingTime, long time)
        {
            var lastThirstQuenchingTimeSpan = _dateTimeConverter.GetHours(time - lastPetDetailsUpdatingTime);
            thirstValue -= lastThirstQuenchingTimeSpan * PetSettings.ThirstUnitsPerPetsHour;
            return thirstValue;
        }

        public double GetPetHappinessDaysCountAtTime(double happinessDaysCount, long lastPetDetailsUpdatingTime, long time)
        {
            var happinessDays = happinessDaysCount + _dateTimeConverter.ConvertFromPetsTime(time).Subtract(_dateTimeConverter.ConvertFromPetsTime(lastPetDetailsUpdatingTime)).TotalDays * PetSettings.PetsTimeConstant;
            return happinessDays;
        }

        public long CalculateDeathDate(float updatedHungerValue, float updatedThirstValue, long time)
        {
            long timeSpanByHungerValue = (long)((updatedHungerValue - HungerLevels.HungerMinHungerValue) / PetSettings.HungerUnitsPerPetsHour * 3600);
            long timeSpanByThirstValue = (long)((updatedThirstValue - ThirstLevels.ThirstyMinThirstValue) / PetSettings.ThirstUnitsPerPetsHour * 3600);
            return time + (timeSpanByHungerValue > timeSpanByThirstValue ? timeSpanByThirstValue : timeSpanByHungerValue);
        }

        public int CalculatePetAge(Pet pet, long currentTime)
        {
            if (!pet.IsAlive(currentTime))
                return _dateTimeConverter.GetYears(pet.DeathDate - pet.BirthDate);
            return _dateTimeConverter.GetYears(currentTime - pet.BirthDate);
        }

        public float GetHungerInPercents(float hungerValue)
        {
            var hungerInPercents = (hungerValue - HungerLevels.HungerMinHungerValue) / (HungerLevels.FullMaxHungerValue - HungerLevels.HungerMinHungerValue) * 100.0f;
            return (hungerInPercents > 0 ? hungerInPercents : 0);
        }

        public float GetThirstInPercents(float thirstValue)
        {
            var thirstInPercents = (thirstValue - ThirstLevels.ThirstyMinThirstValue) / (ThirstLevels.FullMaxThirstValue - ThirstLevels.ThirstyMinThirstValue) * 100.0f;
            return (thirstInPercents > 0 ? thirstInPercents : 0);
        }

        public float GetHungerInPercentsPerRealHour()
        {
            return PetSettings.HungerUnitsPerPetsHour * PetSettings.PetsTimeConstant;
        }

        public float GetThirstInPercentsPerRealHour()
        {
            return PetSettings.ThirstUnitsPerPetsHour * PetSettings.PetsTimeConstant;
        }

        public bool IsPetAlive(float hungerValue, float thirstValue)
        {
            if (hungerValue >= HungerLevels.HungerMinHungerValue && thirstValue >= ThirstLevels.ThirstyMinThirstValue) return true;
            return false;
        }
    }
}
