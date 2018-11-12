using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Kanban.Server.Security;
using Kanban.Server.Services;
using Kanban.Server.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Kanban.Server.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly SigningConfigurations _signingConfigurations;

        public AuthController(IUserService userService, TokenConfigurations tokenConfigurations, SigningConfigurations signingConfigurations)
        {
            _userService = userService;
            _tokenConfigurations = tokenConfigurations;
            _signingConfigurations = signingConfigurations;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] LoginViewModel login)
        {
            bool valid = false;
            if (login != null && !string.IsNullOrWhiteSpace(login.Email))
            {
                var dbUser = _userService.FindByEmail(login.Email);
                valid = (dbUser != null
                    && dbUser.Email == login.Email
                    && dbUser.Password == login.Password);
            }

            if (valid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(login.Email, "Login"),
                    new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, login.Email)
                    }
                );

                DateTime creationDate = DateTime.Now;
                DateTime expirarionDate = creationDate +
                    TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = creationDate,
                    Expires = expirarionDate
                });

                var token = handler.WriteToken(securityToken);

                return Ok(new
                {
                    authenticated = true,
                    created = creationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = expirarionDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                });
            }
            else
            {
                return BadRequest(new
                {
                    authenticated = false,
                    message = "Authentication failure"
                });
            }
        }
    }
}