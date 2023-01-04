using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Exceptions
{
    public class UserWasntFoundException : Exception
    {
        public UserWasntFoundException(string message)
            : base(message)
        {
        }
    }
}
