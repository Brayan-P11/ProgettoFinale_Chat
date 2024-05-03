using Chat_Online.DTO;
using Chat_Online.Filters;
using Chat_Online.Services;
using Chat_Online.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chat_Online.Controllers
{
    public class AuthController : Controller
    {
        private readonly UtenteService _service;

        public AuthController(UtenteService service)
        {
            _service = service;
        }


        [HttpPost("login")]
        public IActionResult Loggati([FromBody]UtenteDto uteDtoLogin)
        {
            //TODO: Verifica accesso, emissione JWT
            if (_service.LoginUtente(uteDtoLogin))
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Sub, uteDtoLogin.Use),
                    new Claim("UserType","USER"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),      //Evito che due dispositivi abbiano lo stesso JWT TOken (rubato)
                    new Claim("Username", uteDtoLogin.Use)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Team",
                    audience: "Utenti",
                    claims: claims,          //Body o Payload del JWT
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }
            return Unauthorized();
        }
        [HttpGet("profiloutente")]
        [AutorizzazioneUtente("USER")]
        public IActionResult DammiInformazioniUtente()
        {
            //var email = User.Claims.FirstOrDefault(u => u.Type == "User")?.Value;
            //if (email is not null)
            //{
            //    return Ok(new Risposta()
            //    {
            //        Status = "SUCCESS",
            //        Data = _service.PerEmail(email)
            //    });
            //}
            //return Ok(new Risposta()
            //{
            //    Status = "ERRORE"
            //});

           
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = "Sei nel profilo utente"
                });
            
           
        }
    }
}
