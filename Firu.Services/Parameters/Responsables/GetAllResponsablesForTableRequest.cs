using System;

namespace Firu.Services.Parameters.Responsables
{
    public class GetAllResponsablesForTableRequest
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string? SortProperty { get; set; }
        public string? SortDirection { get; set; }
        public string Nombre { get; set; }
        public int? Edad { get; set; }
        public string? Puntuacion { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Localidad { get; set; }
    }
}