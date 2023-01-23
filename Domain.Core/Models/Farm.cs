using System;
using System.Collections.Generic;

namespace Domain.Core.Models
{
    public class Farm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }


        public IEnumerable<Pet> Pets { get; set; }
        public UserInfo UserInfo { get; set; }
        public IEnumerable<FarmFriend> FarmFriends { get; set; }
    }
}
