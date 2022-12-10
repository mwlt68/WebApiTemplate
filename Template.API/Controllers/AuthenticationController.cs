using Business.Abstract;
using DataAccess.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequestDto model)
        {
            var authenticateResult = await authenticationService.AuthenticateAsync(model.username, model.password);
            return Ok(authenticateResult);
        }
    }
}
