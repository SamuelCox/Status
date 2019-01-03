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
using Status.DomainModel.Requests;
using Status.DomainModel.Response;

namespace Status.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
                              IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterRequest registerReq)
        {
            var user = new IdentityUser
            {
                UserName = registerReq.Username,
                Email = registerReq.Username
            };

            var userCreationResult = await _userManager.CreateAsync(user, registerReq.Password);

            var loginResult = new LoginResult
            {
                Success = userCreationResult.Succeeded
            };
            if (userCreationResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                var token = GenerateJwtToken(user);
                loginResult.Token = (string)token;                
                return Json(loginResult);
            }
            
            return Json(loginResult);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginRequest loginReq)
        {
            var user = await _userManager.FindByNameAsync(loginReq.Username);
            var signIn = await _signInManager.PasswordSignInAsync(user, loginReq.Password, false, false);

            var loginResult = new LoginResult
            {
                Success = signIn.Succeeded
            };
            if (signIn.Succeeded)
            {
                var token = GenerateJwtToken(user);
                loginResult.Token = (string)token;
                return Json(loginResult);
            }

            return Json(loginResult);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return null;
        }

        private object GenerateJwtToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(30);

            var token = new JwtSecurityToken(
                _configuration["Issuer"],
                _configuration["Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}