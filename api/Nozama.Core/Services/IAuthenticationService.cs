using System.Threading.Tasks;
using Nozama.Core.Dtos;

namespace Nozama.Core.Services
{
    public interface IAuthenticationService
    {
        Task<SignedInUser> SignInAsync(string username, string password);
    }
}