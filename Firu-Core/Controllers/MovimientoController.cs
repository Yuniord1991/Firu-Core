
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Firu.Services.Interfaces;
using Firu.Data.dbContext;
using Firu.Services.Parameters.Movimientos;

namespace Firu_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly FiruDBContext _context;
        private readonly IMovimientoService _movimientoService;

        public MovimientoController(FiruDBContext context, IMovimientoService movimientoService)
        {
            _context = context;
            _movimientoService = movimientoService;
        }

        [HttpGet]
        [Route("GetAllMovimientos")]
        public async Task<ActionResult> Get([FromQuery] GetAllMovimientosRequest request)
        {
            var response = await _movimientoService.Get(request);
            return Ok(response);
        }

        // LE COLOQUE COMO GET PORQUE SI LE DEJO EL POST, LOS VALORES DEL REQUEST NO PASAN Y QUEDAN EN "NULL"
        [HttpPost]
        [Route("PostMovimiento")]
        public async Task<IActionResult> Post([FromBody] PostMovimientoRequest request)
        {
            var response = await _movimientoService.Post(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllMovimientosForTable")]
        public async Task<ActionResult> Get([FromQuery] GetAllMovimientosForTableRequest request)
        {
            var response = await _movimientoService.Get(request);

            return Ok(response);
        }
    }
}
