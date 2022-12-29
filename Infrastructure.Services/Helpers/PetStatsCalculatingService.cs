﻿using Application.Services.Helpers;
using Domain.Core.Models;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services.Helpers;
using System;

namespace Infrastructure.Services.Helpers
{
    public class PetStatsCalculatingService : IPetStatsCalculatingService
    {
        private IDateTimeConverter _dateTimeConverter;

        public PetStatsCalculatingService(IDateTimeConverter dateTimeConverter)
        {
            _dateTimeConverter = dateTimeConverter;
        }

        public Pet UpdatePetVitalSigns(Pet pet, long updationTime) //TODO: delete Async
        {
            var hungerValue = CalculateHungerValueAtTime(pet.HungerValue, pet.LastPetDetailsUpdatingTime, updationTime);
            var thirstValue = CalculateThirstValueAtTime(pet.ThirstValue, pet.LastPetDetailsUpdatingTime, updationTime);
            pet.HungerValue = hungerValue;
            pet.ThirstValue = thirstValue;
            if (hungerValue >= HungerLevels.NormalMinHungerValue && thirstValue >= ThirstLevels.NormalMinThirstValue)
            {
                pet.HappinessDaysCount = GetPetHappinessDaysCountAtTime(pet.HappinessDaysCount, pet.LastPetDetailsUpdatingTime, updationTime);
                pet.LastPetDetailsUpdatingTime = updationTime;
            }
            pet.DeathDate = CalculateDeathDate(hungerValue, thirstValue, updationTime);
            if (!IsPetAlive(hungerValue, thirstValue))
            {
                pet.IsAlive = false;
                pet.HappinessDaysCount = 0;
            }
            return pet;
        }

        public float CalculateHungerValueAtTime(float hungerValue, long lastPetDetailsUpdatingTime, long time)
        {
            var lastFeedingTimeSpan = _dateTimeConverter.GetHours(time - lastPetDetailsUpdatingTime); // in pet's time
            hungerValue -= lastFeedingTimeSpan * PetSettings.HungerUnitsPerPetsHour;

            return hungerValue;
        }

        public float CalculateThirstValueAtTime(float thirstValue, long lastPetDetailsUpdatingTime, long time)
        {
            var lastThirstQuenchingTimeSpan = _dateTimeConverter.GetHours(time - lastPetDetailsUpdatingTime); // in pet's time
            thirstValue -= lastThirstQuenchingTimeSpan * PetSettings.ThirstUnitsPerPetsHour;
            return thirstValue;
        }

        public int GetPetHappinessDaysCountAtTime(int happinessDaysCount, long lastPetDetailsUpdatingTime, long time)
        {
            var newPetDetailsUpdatingTime = _dateTimeConverter.GetDays(lastPetDetailsUpdatingTime);
            var today = _dateTimeConverter.GetDays(time);
            var happinessDays = happinessDaysCount + _dateTimeConverter.SubtractDays(newPetDetailsUpdatingTime, today);
            return happinessDays;
        }

        public long CalculateDeathDate(float updatedHungerValue, float updatedThirstValue, long time)
        {
            long timeSpanByHungerValue = (long)((updatedHungerValue - HungerLevels.HungerMinHungerValue) / PetSettings.HungerUnitsPerPetsHour * 3600);
            long timeSpanByThirstValue = (long)((updatedThirstValue - ThirstLevels.ThirstyMinThirstValue) / PetSettings.ThirstUnitsPerPetsHour * 3600);
            return time + (timeSpanByHungerValue > timeSpanByThirstValue ? timeSpanByThirstValue : timeSpanByHungerValue);
        }

        public bool IsPetAlive(float hungerValue, float thirstValue)
        {
            if (hungerValue >= HungerLevels.HungerMinHungerValue && thirstValue >= ThirstLevels.ThirstyMinThirstValue) return true;
            return false;
        }
    }
}
