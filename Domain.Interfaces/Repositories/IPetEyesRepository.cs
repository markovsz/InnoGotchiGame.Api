using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IPetEyesRepository
    {
        public Task<IEnumerable<PetEyes>> GetPetEyesAsync();
        public Task<PetEyes> GetPetEyesByNameAsync(string picName);
    }
}
