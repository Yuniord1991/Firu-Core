
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Firu.Services.Interfaces;
using Firu.Data.dbContext;
using Firu.Services.Parameters.Voluntarios;

namespace Firu_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoluntarioController : ControllerBase
    {
        private readonly FiruDBContext _context;
        private readonly IVoluntarioService _voluntarioService;

        public VoluntarioController(FiruDBContext context, IVoluntarioService voluntarioService)
        {
            _context = context;
            _voluntarioService = voluntarioService;
        }

        [HttpGet]
        [Route("GetAllVoluntarios")]
        public async Task<ActionResult> Get([FromQuery] GetAllVoluntariosRequest request)
        {
            var response = await _voluntarioService.Get(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetVoluntariosForDashboard")]
        public async Task<ActionResult> Get([FromQuery] GetVoluntariosForDashboardRequest request)
        {
            var response = await _voluntarioService.Get(request);

            return Ok(response);
        }

        // LE COLOQUE COMO GET PORQUE SI LE DEJO EL POST, LOS VALORES DEL REQUEST NO PASAN Y QUEDAN EN "NULL"
        [HttpPost]
        [Route("PostVoluntario")]
        public async Task<IActionResult> Post([FromBody] PostVoluntarioRequest request)
        {
            var response = await _voluntarioService.Post(request);
            return Ok(response);
        }
    }
}
