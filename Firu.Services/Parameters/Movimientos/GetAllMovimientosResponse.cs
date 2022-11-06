using Firu_Core.Models;
using System.Collections.Generic;

namespace Firu.Services.Parameters.Movimientos
{
    public class GetAllMovimientosResponse
    {
        public List<Movimiento> Movimientos { get; set; }
        public int Length { get; set; }
    }
}