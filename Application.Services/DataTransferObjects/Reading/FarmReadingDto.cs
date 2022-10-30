using System.Collections.Generic;

namespace Application.Services.DataTransferObjects.Reading
{
    public class FarmReadingDto
    {
        public string Name { get; set; }

        public IEnumerable<PetReadingDto> Pets { get; set; }
        public IEnumerable<FarmFriendReadingDto> FarmFriends { get; set; }
    }
}
