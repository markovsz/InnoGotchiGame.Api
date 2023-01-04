using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DataTransferObjects.Reading
{
    public class PetsPaginationDto
    {
        public IEnumerable<PetMinReadingDto> Pets { get; set; }
        public int PagesCount { get; set; }
    }
}
