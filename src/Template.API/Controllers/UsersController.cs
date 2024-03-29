﻿using Business.Abstract;
using Core.Utilities.Responses;
using DataAccess.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }


        /// <summary>
        /// User registration.
        /// </summary>
        /// <remarks>
        /// The user registers in the program. Retrieves the JWT (token) used for system authentication.
        /// </remarks>
        /// <param name="model"></param>
        /// <response code="200">Returns user data and token.</response>
        /// 
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(DataResponseModel<UserLoginResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(BaseResponseModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseModel))]

        [HttpPost("registeration")]
        public async Task<IActionResult> RegisterationAsync(UserInsertDto userInsertDto)
        {
            var userInsertResult = await userService.InsertAsync(userInsertDto);
            return Ok(userInsertResult);
        }
    }
}
