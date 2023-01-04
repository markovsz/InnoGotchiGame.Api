using Domain.Core.Models;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class PetNosesRepository : BaseRepository<PetNose>, IPetNosesRepository
    {
        public PetNosesRepository(RepositoryContext context)
            : base(context)
        {
        }

        public async Task<PetNose> GetPetNoseByNameAsync(string picName) =>
            await GetByCondition(e => e.PictureName.Equals(picName), false)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<PetNose>> GetPetNosesAsync() =>
            await GetAll(false)
            .ToListAsync();
    }
}
