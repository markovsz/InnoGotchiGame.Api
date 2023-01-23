using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Helpers
{
    public interface IDateTimeConverter
    {
        public long ConvertToPetsTime(DateTime time);
        public DateTime ConvertFromPetsTime(long time);
        public long TruncToDay(long time);
        public int GetYears(long time);
        public long GetDays(long time);
        public long GetHours(long time);
        public int SubtractDays(long timeInDaysBefore, long timeInDaysAfter);
        public double GetTotalDays(long seconds);
    }
}
