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
    public class PetEyesRepository : BaseRepository<PetEyes>, IPetEyesRepository
    {
        public PetEyesRepository(RepositoryContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<PetEyes>> GetPetEyesAsync() =>
            await GetAll(false)
            .ToListAsync();

        public async Task<PetEyes> GetPetEyesByNameAsync(string picName) =>
            await GetByCondition(e => e.PictureName.Equals(picName), false)
            .FirstOrDefaultAsync();
    }
}
