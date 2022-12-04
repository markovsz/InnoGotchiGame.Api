﻿using Domain.Core.Models;
using System.Threading.Tasks;

namespace Application.Services.Helpers
{
    public interface IPetStatsCalculatingService
    {
        Pet UpdatePetVitalSignsAsync(Pet pet, long updationTime);
        float CalculateHungerValueAtTime(float hungerValue, long lastPetDetailsUpdatingTime, long time);
        float CalculateThirstValueAtTime(float thirstValue, long lastPetDetailsUpdatingTime, long time);
        int GetPetHappinessDaysCountAtTime(int happinessDaysCount, long lastPetDetailsUpdatingTime, long time);
        long CalculateDeathDate(float updatedHungerValue, float updatedThirstValue, long time);
        bool IsPetAlive(float hungerValue, float thirstValue);
    }
}