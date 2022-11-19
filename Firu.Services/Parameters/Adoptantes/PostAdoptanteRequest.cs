using System;

namespace Firu.Services.Parameters.Adoptantes
{
    public class PostAdoptanteRequest
    {
        public int? Dni { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? Edad { get; set; }
        public string? Provincia { get; set; }
        public string? Ciudad { get; set; }
        public string? Localidad { get; set; }
        public string? Calificacion { get; set; }
        public string? EnEspera { get; set; }
    }
}