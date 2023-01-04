using System;
using System.Collections.Generic;

namespace Domain.Core.Models
{
    public class UserInfo
    {
        public Guid UserId { get; set; }
        public string PictureSrc { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User User { get; set; }
        public Farm Farm { get; set; }
        public IEnumerable<FarmFriend> FarmFriends { get; set; }
    }
}
