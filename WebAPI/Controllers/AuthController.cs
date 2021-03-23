using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExist = _authService.UserExists(userForRegisterDto.Email);
            if (!userExist.Success)
            {
                return BadRequest(userExist);
            }
            var register =  _authService.Register(userForRegisterDto);
            if (!register.Success)
            {
                return BadRequest(register);
            }

            var token = _authService.CreateToken(register.Data);
            if (!token.Success)
            {
                return BadRequest(token);
            }
            return Ok(token);
        }

        [HttpPost]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userExist = _authService.UserExists(userForLoginDto.Email);
            if (!userExist.Success)
            {
                return BadRequest(userExist);
            }
            var login = _authService.Login(userForLoginDto);
            if (!login.Success)
            {
                return BadRequest(login);
            }

            var token = _authService.CreateToken(login.Data);
            if (!token.Success)
            {
                return BadRequest(token);
            }
            return Ok(token);
        }



    }
}
