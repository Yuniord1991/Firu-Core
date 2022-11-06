using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Firu_Core.Models
{
    public partial class Movimiento
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Remitente { get; set; }
        public string Destino { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string DireccionRemitente { get; set; }
        public string DireccionDestino { get; set; }
    }
}
