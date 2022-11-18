using Domain.Core.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public interface IJwtTokensGeneratorService
    {
        Task<string> CreateJwtToken(User user);
    }
}
