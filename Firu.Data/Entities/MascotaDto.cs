using Firu_Core.Models;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Firu_Core.Entities
{
    public partial class MascotaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public int? Edad { get; set; }
        public decimal? Peso { get; set; }
        public bool? Castrado { get; set; }
        public int Tamano { get; set; }
        public string Especie { get; set; }
        public int? ResponsableId { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Localidad { get; set; }

        public virtual Responsable Responsable { get; set; }
        public virtual TamanoMascota TamanoNavigation { get; set; }
    }
}
