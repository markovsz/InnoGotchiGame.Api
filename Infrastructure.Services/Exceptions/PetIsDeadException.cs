using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Exceptions
{
    public class PetIsDeadException : Exception
    {
        public PetIsDeadException(string message)
            : base(message)
        {
        }
    }
}
