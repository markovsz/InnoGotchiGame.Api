using Application.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public interface IAuthService
    {
        Task<UserAccessDto> SignInAsync(UserAuthenticationDto userDto);
    }
}
