using System.Threading.Tasks;
using Nozama.Core.Dtos;

namespace Nozama.Core.Services
{
    public interface IUserAuthenticationService
    {
        Task<SignedInUser> SignInAsync(string username, string password);
    }
}