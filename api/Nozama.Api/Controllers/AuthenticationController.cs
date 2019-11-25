using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nozama.Core.Dtos;
using Nozama.Core.Services;

namespace Nozama.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserAuthenticationService _service;

        public AuthenticationController(IUserAuthenticationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<SignedInUser>> SignIn([FromQuery]string username, [FromQuery] string password)
        {
            var signedInUser = await _service.SignInAsync(username, password);

            if (signedInUser == null)
                return NotFound();

            return signedInUser;
        }
    }
}
