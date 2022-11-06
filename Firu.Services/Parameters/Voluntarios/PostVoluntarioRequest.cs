using System;

namespace Firu.Services.Parameters.Voluntarios
{
    public class PostVoluntarioRequest
    {
        public int? Dni { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? Edad { get; set; }
        public int? OrganizacionId { get; set; }
        public string? Provincia { get; set; }
        public string? Ciudad { get; set; }
        public string? Localidad { get; set; }
    }
}