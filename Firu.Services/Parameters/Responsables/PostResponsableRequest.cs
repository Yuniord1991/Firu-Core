using System;

namespace Firu.Services.Parameters.Movimientos
{
    public class PostMovimientoRequest
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Remitente { get; set; }
        public string Destino { get; set; }
        public string? Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string? DireccionRemitente { get; set; }
        public string? DireccionDestino { get; set; }
    }
}