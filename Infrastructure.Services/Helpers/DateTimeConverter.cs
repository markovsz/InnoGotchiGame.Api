﻿using Application.Services.Helpers;
using Infrastructure.Data;
using System;

namespace Infrastructure.Services.Helpers
{
    public class DateTimeConverter : IDateTimeConverter
    {
        private DateTime startingDate = new DateTime(2022, 1, 1, 0, 0, 0, 0);

        public long ConvertToPetsTime(DateTime time)
        {
            var timeSpan = time.Subtract(startingDate);
            timeSpan = timeSpan.Multiply(PetSettings.PetsTimeConstant);
            return (long)timeSpan.TotalSeconds;
        }

        public DateTime ConvertFromPetsTime(long time)
        {
            DateTime realTime = startingDate.AddSeconds(time / PetSettings.PetsTimeConstant);
            return realTime;
        }

        public long TruncToDay(long time)
        {
            return time - time % (60 * 60 * 24);
        }

        public int GetYears(long time)
        {
            return startingDate.AddSeconds(time).Year - startingDate.Year;
        }

        public long GetDays(long time)
        {
            return time / (60 * 60 * 24);
        }

        public long GetHours(long time)
        {
            return time / (60 * 60);
        }

        public int SubtractDays(long timeInDaysBefore, long timeInDaysAfter)
        {
            return (int)(timeInDaysAfter - timeInDaysBefore);
        }

        public double GetTotalDays(long seconds)
        {
            return seconds / (60 * 60 * 24);
        }
    }
}
