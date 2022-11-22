
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
    public class AdoptanteController : ControllerBase
    {
        private readonly FiruDBContext _context;
        private readonly IAdoptanteService _adoptanteService;

        public AdoptanteController(FiruDBContext context, IAdoptanteService adoptanteService)
        {
            _context = context;
            _adoptanteService = adoptanteService;
        }

        [HttpGet]
        [Route("GetAllAdoptantes")]
        public async Task<ActionResult> Get([FromQuery] GetAllAdoptantesRequest request)
        {
            var response = await _adoptanteService.Get(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAdoptantesForDashboard")]
        public async Task<ActionResult> Get([FromQuery] GetAdoptantesForDashboardRequest request)
        {
            var response = await _adoptanteService.Get(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllAdoptantesForTable")]
        public async Task<ActionResult> Get([FromQuery] GetAllAdoptantesForTableRequest request)
        {
            var response = await _adoptanteService.Get(request);

            return Ok(response);
        }

        // LE COLOQUE COMO GET PORQUE SI LE DEJO EL POST, LOS VALORES DEL REQUEST NO PASAN Y QUEDAN EN "NULL"
        [HttpPost]
        [Route("PostAdoptante")]
        public async Task<IActionResult> Post([FromBody] PostAdoptanteRequest request)
        {
            var response = await _adoptanteService.Post(request);
            return Ok(response);
        }
    }
}
