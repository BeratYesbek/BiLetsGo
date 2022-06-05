using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Business.Abstracts;
using Core.Entities;
using Core.Entity;
using Core.Entity.Concretes;
using Core.Extensions;
using Core.Utilities.Constants;
using Core.Utilities.IoC;
using Core.Utilities.Result;
using Entity.Concretes.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
            _contextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();


        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            var head = Request.Headers;
            var cookie = Request.Cookies;
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {

                result.Data.User = userToLogin.Data;
                HttpContext.SetCookie(new CookieParams
                {
                    AccessToken = result.Data,
                    User = userToLogin.Data,

                });


                Console.WriteLine("--> ");
                return Ok(result);
            }
            return BadRequest(userToLogin);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
          /*  var existsUser = _authService.UserExists(userForRegisterDto.Email);

            if (!existsUser.Success)
            {
                return BadRequest(existsUser.Message);
            }*/

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                result.Data.User = registerResult.Data;
                HttpContext.SetCookie(new CookieParams
                {
                    AccessToken = result.Data,
                    User = registerResult.Data,

                });

                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("isLoggedIn")]
        public IActionResult IsLoggedIn()
        {
            return Ok(_authService.IsLoggedIn());
        }


        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.DeleteCookies();
            return Ok(new SuccessResult());
        }

    }
}