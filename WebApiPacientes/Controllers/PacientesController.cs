using Microsoft.AspNetCore.Mvc;
using WebApiPacientes.Models;

namespace WebApiPacientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly PacienteAppService _appService;

        public PacientesController(PacienteAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_appService.ListarTodo());

        [HttpPost]
        public IActionResult Post(Paciente p)
        {
            try
            {
                _appService.Agregar(p);
                return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Devuelve el error de validación
            }
        }
    }
}
