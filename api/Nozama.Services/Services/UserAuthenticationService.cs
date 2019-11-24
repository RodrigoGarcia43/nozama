using System.Threading.Tasks;
using Nozama.Core.Dtos;
using Nozama.Core.Services;
using Nozama.Persistence.Contexts;

namespace Nozama.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly NozamaContext _context;

        public UserAuthenticationService(NozamaContext context)
        {
            _context = context;
        }

        public Task<SignedInUser> SignInAsync(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}