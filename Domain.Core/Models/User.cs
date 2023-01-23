using Microsoft.AspNetCore.Identity;
using System;

namespace Domain.Core.Models
{
    public class User : IdentityUser<Guid>
    {
        public UserInfo UserInfo { get; set; }
    }
}
