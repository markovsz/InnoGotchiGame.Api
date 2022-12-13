using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IPetMouthsRepository
    {
        public Task<IEnumerable<PetMouth>> GetPetMouthsAsync();
        public Task<PetMouth> GetPetMouthByNameAsync(string picName);
    }
}
