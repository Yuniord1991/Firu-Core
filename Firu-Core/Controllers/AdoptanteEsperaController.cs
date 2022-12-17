
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Firu.Services.Interfaces;
using Firu.Data.dbContext;
using Firu.Services.Parameters.Adoptantes;

namespace Firu_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptanteEsperaController : ControllerBase
    {
        private readonly FiruDBContext _context;
        private readonly IAdoptanteEsperaService _adoptanteEsperaService;

        public AdoptanteEsperaController(FiruDBContext context, IAdoptanteEsperaService adoptanteEsperaService)
        {
            _context = context;
            _adoptanteEsperaService = adoptanteEsperaService;
        }

        [HttpGet]
        [Route("GetAdoptantesEsperaForDashboard")]
        public async Task<ActionResult> Get([FromQuery] GetAdoptantesEsperaForDashboardRequest request)
        {
            var response = await _adoptanteEsperaService.Get(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllAdoptantesEsperaForTable")]
        public async Task<ActionResult> Get([FromQuery] GetAllAdoptantesEsperaForTableRequest request)
        {
            var response = await _adoptanteEsperaService.Get(request);

            return Ok(response);
        }

        // LE COLOQUE COMO GET PORQUE SI LE DEJO EL POST, LOS VALORES DEL REQUEST NO PASAN Y QUEDAN EN "NULL"
        [HttpPost]
        [Route("PostAdoptanteEspera")]
        public async Task<IActionResult> Post([FromBody] PostAdoptanteEsperaRequest request)
        {
            var response = await _adoptanteEsperaService.Post(request);
            return Ok(response);
        }
    }
}
