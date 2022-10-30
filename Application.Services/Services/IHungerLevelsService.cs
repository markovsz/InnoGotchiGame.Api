using Application.Services.DataTransferObjects.Reading;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public interface IHungerLevelsService
    {
        string GetHungerLevelName(float hungerValue);
    }
}
