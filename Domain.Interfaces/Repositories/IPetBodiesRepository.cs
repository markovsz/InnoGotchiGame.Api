using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IPetBodiesRepository
    {
        public Task<IEnumerable<PetBody>> GetPetBodiesAsync();
        public Task<PetBody> GetPetBodyByNameAsync(string picName);
    }
}
