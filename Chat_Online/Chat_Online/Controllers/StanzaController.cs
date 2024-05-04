using Chat_Online.DTO;
using Chat_Online.Services;
using Chat_Online.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Chat_Online.Controllers
{
    [ApiController]
    [Route("api/stanze")]
    public class StanzaController : Controller
    {
        private readonly StanzaService _service;

        public StanzaController(StanzaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult ListaStanze()
        {
            return Ok(_service.Restituisci());
        }

        [HttpPost("inserisciStanza")]
        public IActionResult InserisciStanza(StanzaDto stanDto)
        {
            if (ModelState.IsValid)
            {
                if (_service.Inserimento(stanDto))
                    return Ok(new Risposta() { Status = "SUCCESS", Data = "Stanza creata" });
            }
            return BadRequest();
        }
    }
}
