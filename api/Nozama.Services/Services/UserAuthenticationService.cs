using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Nozama.Core.Dtos;
using Nozama.Core.Providers;
using Nozama.Core.Services;
using Nozama.Persistence.Contexts;

namespace Nozama.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly NozamaContext _context;
        private readonly ISecretKeyProvider _keyProvider;

        public UserAuthenticationService(NozamaContext context, ISecretKeyProvider keyProvider)
        {
            _context = context;
            _keyProvider = keyProvider;
        }

        public async Task<SignedInUser> SignInAsync(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(
                x => x.Username == username && x.Password == password
            );

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var handler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_keyProvider.KeyBytes),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = handler.CreateToken(descriptor);

            return new SignedInUser
            {
                Token = handler.WriteToken(token)
            };
        }
    }
}