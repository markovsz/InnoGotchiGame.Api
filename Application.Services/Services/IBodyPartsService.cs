using Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public interface IBodyPartsService
    {
        public Task<IEnumerable<string>> GetPetBodiesAsync();
        public Task<IEnumerable<string>> GetPetEyesAsync();
        public Task<IEnumerable<string>> GetPetMouthsAsync();
        public Task<IEnumerable<string>> GetPetNosesAsync();
    }
}
