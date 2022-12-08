using Application.Services.DataTransferObjects.Reading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Helpers
{
    public interface IFarmStatsCalculatingService
    {
        Task<FarmReadingDto> UpdateFarmStatsAsync(FarmReadingDto farmDto, long now);
        Task<FarmMinReadingDto> UpdateMinFarmStatsAsync(FarmMinReadingDto farmDto, long now);
    }
}
