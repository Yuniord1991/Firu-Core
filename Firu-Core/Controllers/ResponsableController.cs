
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Firu.Services.Interfaces;
using Firu.Data.dbContext;
using Firu.Services.Parameters.Responsables;

namespace Firu_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsableController : ControllerBase
    {
        private readonly FiruDBContext _context;
        private readonly IResponsableService _responsableService;

        public ResponsableController(FiruDBContext context, IResponsableService responsableService)
        {
            _context = context;
            _responsableService = responsableService;
        }

        [HttpGet]
        [Route("GetAllResponsables")]
        public async Task<ActionResult> Get([FromQuery] GetAllResponsablesRequest request)
        {
            var response = await _responsableService.Get(request);
            return Ok(response);
        }

        // LE COLOQUE COMO GET PORQUE SI LE DEJO EL POST, LOS VALORES DEL REQUEST NO PASAN Y QUEDAN EN "NULL"
        [HttpPost]
        [Route("PostResponsable")]
        public async Task<IActionResult> Post([FromBody] PostResponsableRequest request)
        {
            var response = await _responsableService.Post(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllResponsablesForTable")]
        public async Task<ActionResult> Get([FromQuery] GetAllResponsablesForTableRequest request)
        {
            var response = await _responsableService.Get(request);
            return Ok(response);
        }
    }
}
