using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Firu_Core.Models
{
    public partial class Movimiento
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public string remitente { get; set; }
        public string destino { get; set; }
        public string motivo { get; set; }
        public DateTime fecha { get; set; }
        public double monto { get; set; }
        public string direccion_remitente { get; set; }
        public string direccion_destino { get; set; }
    }
}
