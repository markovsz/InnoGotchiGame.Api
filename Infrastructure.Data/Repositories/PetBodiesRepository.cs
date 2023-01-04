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
    public class PetBodiesRepository : BaseRepository<PetBody>, IPetBodiesRepository
    {
        public PetBodiesRepository(RepositoryContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<PetBody>> GetPetBodiesAsync() =>
            await GetAll(false)
            .ToListAsync();

        public async Task<PetBody> GetPetBodyByNameAsync(string picName) =>
            await GetByCondition(e => e.PictureName.Equals(picName), false)
            .FirstOrDefaultAsync();
    }
}
