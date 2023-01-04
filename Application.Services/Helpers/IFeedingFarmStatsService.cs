using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Helpers
{
    public interface IFeedingFarmStatsService
    {
        Task<double> GetFarmAverageTimeBetweenFeedingAsync(Guid farmId);
    }
}
