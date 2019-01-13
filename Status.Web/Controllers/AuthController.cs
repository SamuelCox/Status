using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Status.Business.Auth;
using Status.DomainModel.Requests;
using Status.DomainModel.Response;

namespace Status.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterRequest registerReq)
        {
            var loginResult =  await _authService.Register(registerReq);
            return Json(loginResult);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginRequest loginReq)
        {
            var loginResult = await _authService.Login(loginReq);
            return Json(loginResult);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return null;
        }
        
    }
}