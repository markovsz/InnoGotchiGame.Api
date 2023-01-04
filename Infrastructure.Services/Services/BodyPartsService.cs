using Application.Services.Services;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services.Services
{
    public class BodyPartsService : IBodyPartsService
    {
        private IRepositoryManager _repositoryManager;

        public BodyPartsService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<string>> GetPetBodiesAsync()
        {
            var bodies = await _repositoryManager.PetBodies.GetPetBodiesAsync();
            return bodies.Select(e => e.PictureName);
        }

        public async Task<IEnumerable<string>> GetPetEyesAsync()
        {
            var eyes = await _repositoryManager.PetEyes.GetPetEyesAsync();
            return eyes.Select(e => e.PictureName);
        }

        public async Task<IEnumerable<string>> GetPetMouthsAsync()
        {
            var mouths = await _repositoryManager.PetMouths.GetPetMouthsAsync();
            return mouths.Select(e => e.PictureName);
        }

        public async Task<IEnumerable<string>> GetPetNosesAsync()
        {
            var noses = await _repositoryManager.PetNoses.GetPetNosesAsync();
            return noses.Select(e => e.PictureName);
        }
    }
}
