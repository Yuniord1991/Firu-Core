using System;

namespace Firu.Services.Parameters.Voluntarios
{
    public class PostVoluntarioRequest
    {
        public string? Dni { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Edad { get; set; }
        public string? OrganizacionId { get; set; }
        public string? Provincia { get; set; }
        public string? Ciudad { get; set; }
        public string? Localidad { get; set; }
    }
}