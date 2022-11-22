using System;

namespace Firu.Services.Parameters.Movimientos
{
    public class PostMovimientoRequest
    {
        public string? Tipo { get; set; }
        public string? Remitente { get; set; }
        public string? Destino { get; set; }
        public string? Motivo { get; set; }
        public string? Fecha { get; set; }
        public string? Monto { get; set; }
        public string? DireccionRemitente { get; set; }
        public string? DireccionDestino { get; set; }
    }
}