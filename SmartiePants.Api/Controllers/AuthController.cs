using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartiePants.Api.Helpers;
using SmartiePants.Api.Settings;
using SmartiePants.Core.Resources;
using SmartiePants.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartiePants.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;

        public AuthController(IUserService userService, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _jwtSettings = jwtSettings != null ? jwtSettings.Value : throw new ArgumentNullException(nameof(jwtSettings));
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="userRegisterDto"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType(201, Type = typeof(UserDto))]
        [ProducesResponseType(422, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            try
            {
                UserDto userDto = await _userService.CreateUserAsync(userRegisterDto);
                return Created(string.Empty, userDto);
            }
            catch (Exception e)
            {
                return Problem(e.Message, null, StatusCodes.Status422UnprocessableEntity);
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(401, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            try
            {
                UserDto userDto = await _userService.Login(userLoginDto);
                string accessToken = JwtGenerator.Generate(userDto, _jwtSettings);
                HttpContext.Response.Headers["Authorization"] = $"Bearer {accessToken}";
                HttpContext.Response.Headers["Access-Control-Expose-Headers"] = "Authorization";
                return Ok(userDto);
            }
            catch (Exception e)
            {
                return Problem(e.Message, null, StatusCodes.Status401Unauthorized);
            }
        }
    }
}