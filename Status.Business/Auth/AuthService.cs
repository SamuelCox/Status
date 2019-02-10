using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Status.DomainModel.Requests;
using Status.DomainModel.Response;

namespace Status.Business.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private IMapper _mapper;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<LoginResult> Register(RegisterRequest registerReq)
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
                await _signInManager.PasswordSignInAsync(user, registerReq.Password, false, false);
                var token = GenerateJwtToken(user);
                loginResult.Token = (string)token;
                return loginResult;
            }

            return loginResult;
        }

        public async Task<LoginResult> Login(LoginRequest loginReq)
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
            }

            return loginResult;
        }

        public async Task<DomainModel.Models.User> GetCurrentUser(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return _mapper.Map<DomainModel.Models.User>(user);
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
