using Business.Abstract;
using Core.Utilities.Responses;
using DataAccess.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Template.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        /// <summary>
        /// Get user data and jwt(token). 
        /// </summary>
        /// <remarks>
        /// JWT(token)is used for system authentication.
        /// </remarks>
        /// <param name="model"></param>
        /// <response code="200">Returns user data and token.</response>
        /// 
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(DataResponseModel<UserLoginResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(BaseResponseModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseModel))]

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequestDto model)
        {
            var authenticateResult = await authenticationService.AuthenticateAsync(model.Username, model.Password);
            return Ok(authenticateResult);
        }
    }
}
