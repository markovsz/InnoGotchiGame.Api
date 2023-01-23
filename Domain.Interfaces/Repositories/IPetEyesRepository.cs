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
        Task<IEnumerable<PetEyes>> GetPetEyesAsync();
        Task<PetEyes> GetPetEyesByNameAsync(string picName);
    }
}
