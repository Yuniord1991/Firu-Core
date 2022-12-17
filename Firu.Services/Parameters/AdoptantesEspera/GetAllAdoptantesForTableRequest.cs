using System;

namespace Firu.Services.Parameters.Adoptantes
{
    public class GetAllAdoptantesEsperaForTableRequest
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string? SortProperty { get; set; }
        public string? SortDirection { get; set; }
        public string? Nombre { get; set; }
        public int? Telefono { get; set; }
        public string? Ciudad { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }
        public string? Tamano { get; set; }
        public string? Color { get; set; }
        public int? Edad { get; set; }
    }
}