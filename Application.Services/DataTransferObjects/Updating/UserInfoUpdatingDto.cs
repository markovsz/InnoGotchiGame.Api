using System;

namespace Application.Services.DataTransferObjects.Updating
{
    public class UserInfoUpdatingDto
    {
        public Guid UserId { get; set; }
        public string PictureSrc { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
