using JwtWebApi.Dtos;
using JwtWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace JwtWebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password,out byte[] passwordHarsh,out byte[] passwordSalt);
            if (request != null) {
                user.Username = request.Username;
                user.PasswordHarsh = passwordHarsh;
                user.PasswordSalt = passwordSalt;
                return Ok(user);

            }
            return BadRequest();

        }
        // adding a function to hash and sort the password
        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }


    }
}
