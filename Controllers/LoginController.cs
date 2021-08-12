using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BibliotecaApi.Models;
using BibliotecaApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BibliotecaApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {

        private readonly IUsersRepository _userRepository;
        public LoginController(IUsersRepository usersRepository)
        {
            _userRepository = usersRepository;
        }

        private readonly IConfiguration configuration;
        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // POST: api/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            var _userInfo = await AutenticarUsuarioAsync(userLogin.UserNumberOfDocument, userLogin.UserPin);
            if (_userInfo != null)
            {
                return Ok(new { token = GenerarTokenJWT(_userInfo) });
            }
            else
            {
                return Unauthorized();
            }
        }

        private async Task<UserInfo> AutenticarUsuarioAsync(int UserNumberOfDocument, string UserPin)
        {

            var user = await _userRepository.GetNumberDocument(UserNumberOfDocument);
            if (user.UserActive == true)
            {
                return new UserInfo()
                {
                    UserName = user.UserName,
                    UserLastName = user.UserLastName,
                    UserNumberOfDocument = user.UserNumberOfDocument,
                    UserDateYear = user.UserDateYear,
                    UserActive = user.UserActive,
                    UserPin = user.UserPin,
                    UserRol = user.UserRol
                };
            }
            else
            {
                return null;
            }
        }

        private string GenerarTokenJWT(UserInfo userInfo)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames., Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UserPin, userInfo.UserPin),
                new Claim("nombre", userInfo.UserName),
                new Claim("apellidos", userInfo.UserLastName),
                new Claim(JwtRegisteredClaimNames.UserNumberOfDocument, userInfo.UserNumberOfDocument),
                new Claim(userInfo.UserRol, userInfo.UserRol)
            };

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }

    }
}