using Chat_Online.DTO;
using Chat_Online.Services;
using Chat_Online.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Chat_Online.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UtenteController : Controller
    {

        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly UtenteService _service;

        public UtenteController(UtenteService service)
        {
            _service = service;
        }

        [HttpGet("lista")]
        public IActionResult ListaUtenti()
        {
            return Ok(_service.RestituisciTutto());
        }

        [HttpDelete("elimina")]
        public IActionResult EliminaUtente(UtenteDto uteDto)
        {
            //return Ok(_service.EliminaPerCodice(ut));
            if (_service.EliminaPerCodice(uteDto))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = "Eliminazione effettuata con successo"
                });
            return BadRequest();
        }

        [HttpPost("registra")]
        public IActionResult RegistraUtente(UtenteDto uteDto)
        {
            if (_service.CreaUtente(uteDto))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = "Registrazione utente effettuata con successo"
                });
            return BadRequest();

        }

        //Prende i valori DTO e li passa al service

        [HttpPut("modifica")]
        public IActionResult ModificaUtente(UtenteDto uteDto)
        {
            if(_service.AggiornaUtente(uteDto))
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = "Modifica effettuata con successo"
            });
            return BadRequest();
        }
    }
}
