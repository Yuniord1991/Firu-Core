using Firu_Core.Models;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Firu_Core.Entities
{
    public partial class OrganizacionDto
    {
        public OrganizacionDto()
        {
            Voluntario = new HashSet<Voluntario>();
        }

        public int Id { get; set; }
        public int? Cuit { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Localidad { get; set; }

        public virtual ICollection<Voluntario> Voluntario { get; set; }
    }
}
