using System;

namespace Firu.Services.Parameters.Mascotas
{
    public class GetAllMascotasForTableRequest
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string? SortProperty { get; set; }
        public string? SortDirection { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }
        public int? Edad { get; set; }
        public decimal? Peso { get; set; }
        public bool? Castrado { get; set; }
        public int? Tamano { get; set; }
        public string? Ciudad { get; set; }
    }
}