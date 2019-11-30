using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using eazy_transact.Models;
using eazy_transact.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace eazy_transact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
         private readonly UserService _userService;

         private IConfiguration _config;

        public AuthController(UserService userService, IConfiguration config)
        {
            _userService = userService;

            _config = config;
        }

        [HttpPost("{login}")]
        public ActionResult<User> Login(User user)
        {
             var loggedInUser = _userService.Get(user.Email);


             if ( loggedInUser == null )
             {
                 return NotFound();
             }

             if ( loggedInUser.Password != user.Password )
             {
                 return BadRequest();
             }
                        
        
            var tokenStr = GenerateJSONWebToken(loggedInUser);
           return Ok(new  AuthResponse()
           { 
               message = "Login Successful",
               data = loggedInUser,
               token = tokenStr 
               });
             
        }

        private string GenerateJSONWebToken(User loggedInUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.GivenName, loggedInUser.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, loggedInUser.LastName),
                new Claim(JwtRegisteredClaimNames.Email, loggedInUser.Email),
                new Claim(JwtRegisteredClaimNames.Sub, loggedInUser.PhoneNumber),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };

            var token = new JwtSecurityToken(
                issuer: _config["jwt:Issuer"],
                audience: _config["jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }

        public class AuthResponse
        {
            public string message { get; set; }
            public object data { get; set; }
            public string token { get; set; }            
        }
    }
}