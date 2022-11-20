using Application.Services.DataTransferObjects;
using Application.Services.Services;
using Domain.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Services
{
    public class AuthService : IAuthService
    {
        private UserManager<User> _userManager;
        private IJwtTokensGeneratorService _jwtTokensGeneratorService;

        public AuthService(UserManager<User> userManager, IJwtTokensGeneratorService jwtTokensGeneratorService)
        {
            _userManager = userManager;
            _jwtTokensGeneratorService = jwtTokensGeneratorService;
        }

        public async Task<UserAccessDto> SignInAsync(UserAuthenticationDto userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.Email);
            var jwtToken = await _jwtTokensGeneratorService.CreateJwtToken(user);
            return new UserAccessDto { JwtToken = jwtToken };
        }
    }
}
