using System;

namespace Firu.Services.Parameters.Adoptantes
{
    public class PostAdoptanteEsperaRequest
    {
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Ciudad { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }
        public string? Tamano { get; set; }
        public string? Color { get; set; }
        public string? Edad { get; set; }
    }
}