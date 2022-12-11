using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Models
{
    public class PetEyes
    {
        public Guid Id { get; set; }
        public string PictureName { get; set; }

        public IEnumerable<Pet> RelatedPets { get; set; }
    }
}
