using System;

namespace Firu.Services.Parameters.Movimientos
{
    public class GetMovimientosForDashboardResponse
    {
        public int Ingresos { get; set; }
        public int Egresos { get; set; }
        public int Donaciones { get; set; }
    }
}