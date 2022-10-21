using System;

namespace Domain.Core.Models
{
    public class FarmFriend
    {
        public Guid Id { get; set; }
        public Guid FarmId { get; set; }
        public Guid UserId { get; set; }

        public Farm Farm { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
