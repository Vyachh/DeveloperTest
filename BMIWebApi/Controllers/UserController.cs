using AutoMapper;
using BMIWebApi.Data;
using BMIWebApi.Dto;
using BMIWebApi.Interfaces;
using BMIWebApi.Models;
using BMIWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static System.Net.WebRequestMethods;

namespace BMIWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public static User user = new();
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly IPacientRepository pacientRepository;

        public UserController(IConfiguration configuration, IMapper mapper, IPacientRepository pacientRepository)
        {
            this.configuration = configuration;
            this.mapper = mapper;
            this.pacientRepository = pacientRepository;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto request)
        {
            if (pacientRepository.GetPacient(request.NickName) != null)
            {
                return BadRequest("User has found.");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.NickName = request.NickName;
            user.PasswordHash = passwordHash;


            var pacientMap = mapper.Map<Pacient>(user);



            var bmiIndex = new BMIIndex
            {
                Pacient = pacientMap
            };

            pacientMap.BMIIndex = bmiIndex;

            if (!pacientRepository.Add(pacientMap))
            {
                ModelState.AddModelError("", "Что-то пошло не так. Попробуйте еще раз.");
                return StatusCode(500, ModelState);
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto request)
        {
            var pacient = pacientRepository.GetPacient(request.NickName);

            user.NickName = pacient.NickName;
            user.PasswordHash = pacient.PasswordHash;

            if (user.NickName != request.NickName)
            {
                return BadRequest("User not found.");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Bad password.");
            }

            string token = CreateToken(pacient);

            return Ok(token);
        }

        private string CreateToken(Pacient user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.NickName),
                new Claim(ClaimTypes.Surname, user.Surname ?? string.Empty),
                new Claim(ClaimTypes.GivenName, user.FirstName ?? string.Empty),
                new Claim("Patronymic", user.FirstName ?? string.Empty),
                new Claim("Age", user.Age.ToString()),
                new Claim("Height", user.Height.ToString()),
                new Claim("Weight", user.Weight.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: cred
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        [HttpGet("GetUserInfo"), Authorize]
        public IActionResult GetUserInfo([FromHeader] string Authorization)
        {
            var claims = DecodeJwtToken(Authorization);
            return Ok(claims);
        }

        private static IDictionary<string, string> DecodeJwtToken(string token)
        {

            var jwtHandler = new JwtSecurityTokenHandler();
            var middle = token.Replace("Bearer ", "");
            var jwtToken = jwtHandler.ReadJwtToken(middle);

            var claims = new Dictionary<string, string>();
            foreach (var claim in jwtToken.Claims)
            {
                claims.Add(claim.Type, claim.Value);
            }

            return claims;
        }
    }
}
