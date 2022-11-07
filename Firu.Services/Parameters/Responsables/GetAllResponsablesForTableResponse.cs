using Firu_Core.Models;
using System;
using System.Collections.Generic;

namespace Firu.Services.Parameters.Movimientos
{
    public class GetAllMovimientosForTableResponse
    {
        public List<Movimiento> Movimientos { get; set; }
        public int Length { get; set; }
    }
}