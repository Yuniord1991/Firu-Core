using Firu_Core.Models;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Firu_Core.Entities
{
    public partial class TamanoMascotaDto
    {
        public TamanoMascotaDto()
        {
            Mascota = new HashSet<Mascota>();
        }

        public int Id { get; set; }
        public string Tamano { get; set; }

        public virtual ICollection<Mascota> Mascota { get; set; }
    }
}
