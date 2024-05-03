using Chat_Online.DTO;
using Chat_Online.Services;
using Chat_Online.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Chat_Online.Controllers
{
    [ApiController]
    [Route("api/messaggi")]
    public class MessaggioController : Controller
    {
        private readonly MessaggioService _service;

        public MessaggioController(MessaggioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult ListaMessaggi()
        {
            return Ok(_service.Restituisci());
        }

        [HttpPost]
        public IActionResult InserisciMessaggio(MessaggioDto mesDto)
        {
            if (ModelState.IsValid)
            {
                if (_service.Inserimento(mesDto))
                    return Ok(new Risposta() { Status = "SUCCESS" });
            }
            return BadRequest();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
