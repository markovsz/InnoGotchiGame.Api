using Application.Services.Helpers;
using System;

namespace Infrastructure.Services.Helpers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now {
            get { return DateTime.Now; }
        }
    }
}
