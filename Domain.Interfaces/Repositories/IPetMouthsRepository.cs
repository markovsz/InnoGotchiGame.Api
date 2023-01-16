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
        Task<IEnumerable<PetMouth>> GetPetMouthsAsync();
        Task<PetMouth> GetPetMouthByNameAsync(string picName);
    }
}
