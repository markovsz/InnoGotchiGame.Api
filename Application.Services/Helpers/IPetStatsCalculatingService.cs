using Domain.Core.Models;
using System.Threading.Tasks;

namespace Application.Services.Helpers
{
    public interface IPetStatsCalculatingService
    {
        Pet UpdatePetVitalSigns(Pet pet, long updationTime);
        float CalculateHungerValueAtTime(float hungerValue, long lastPetDetailsUpdatingTime, long time);
        float CalculateThirstValueAtTime(float thirstValue, long lastPetDetailsUpdatingTime, long time);
        int GetPetHappinessDaysCountAtTime(int happinessDaysCount, long lastPetDetailsUpdatingTime, long time);
        long CalculateDeathDate(float updatedHungerValue, float updatedThirstValue, long time);
        int CalculatePetAge(Pet pet, long currentTime);
        float GetHungerInPercents(float hungerValue);
        float GetThirstInPercents(float thirstValue);
        float GetHungerInPercentsPerRealHour();
        float GetThirstInPercentsPerRealHour();
        bool IsPetAlive(float hungerValue, float thirstValue);
    }
}
