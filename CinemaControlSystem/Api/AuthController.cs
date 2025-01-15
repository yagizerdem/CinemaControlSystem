using CinemaControlSystem.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using CinemaControlSystem.Utils;
using CinemaControlSystem.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using CinemaControlSystem.Models.Entity;

namespace CinemaControlSystem.Api
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            this._configuration = configuration;
            this._userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInDTO dto)
        {
            try
            {
                // cehck credentisl 
                AppUser? userFromDb = await _userManager.FindByEmailAsync(dto.Email);
                if (userFromDb == null)
                {
                    return BadRequest(JsonSerializer.
                        Serialize(ServiceResponse<string>.Fail(null, [$"cannot find user with email {dto.Email}"])));
                }

                bool flag = await _userManager.CheckPasswordAsync(userFromDb, dto.Password);
                if (!flag)
                {
                    return BadRequest(JsonSerializer.
        Serialize(ServiceResponse<string>.Fail(null, [$"invalid password"])));
                }

                string role = (await _userManager.GetRolesAsync(userFromDb)).FirstOrDefault();

                // assume true for test 
                var token = GenerateJwtToken(userFromDb.FullName, role , userFromDb.Id);

                ServiceResponse<string> response = new();
                response.Data = token;


                // Serialize response to JSON
                var jsonResponse = JsonSerializer.Serialize(response);

                return Ok(jsonResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = ServiceResponse<string>.Fail(null, new List<string> { "Internal server error" });
                var jsonResponse = JsonSerializer.Serialize(errorResponse);

                return StatusCode(500, jsonResponse);
            }

        }


        private string GenerateJwtToken(string username, string role , string userId)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role),
            new Claim("userId" , userId)
        };

            string jwtSecret = _configuration["jwt"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: SD.jwtissuer,
                audience: SD.jwtaudiance,
                claims: claims,
                expires: DateTime.Now.AddDays(60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
