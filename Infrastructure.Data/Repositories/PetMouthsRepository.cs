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
    public class PetMouthsRepository : BaseRepository<PetMouth>, IPetMouthsRepository
    {
        public PetMouthsRepository(RepositoryContext context)
            : base(context)
        {
        }

        public async Task<PetMouth> GetPetMouthByNameAsync(string picName) =>
            await GetByCondition(e => e.PictureName.Equals(picName), false)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<PetMouth>> GetPetMouthsAsync() =>
            await GetAll(false)
            .ToListAsync();
    }
}
