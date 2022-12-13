using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IPetNosesRepository
    {
        public Task<IEnumerable<PetNose>> GetPetNosesAsync();
        public Task<PetNose> GetPetNoseByNameAsync(string picName);
    }
}
