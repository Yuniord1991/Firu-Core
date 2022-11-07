using System;

namespace Firu.Services.Parameters.Movimientos
{
    public class GetAllMovimientosForTableRequest
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string? SortProperty { get; set; }
        public string? SortDirection { get; set; }
        public string? Tipo { get; set; }
        public string? Remitente { get; set; }
        public string? Destino { get; set; }
        public string? Motivo { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Monto { get; set; }
        public string? DireccionRemitente { get; set; }
        public string? DireccionDestino { get; set; }
    }
}