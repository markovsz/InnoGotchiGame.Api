using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Exceptions
{
    public class PetIsAlreadyFullException : Exception
    {
        public PetIsAlreadyFullException(string message)
            : base(message)
        {
        }
    }
}
