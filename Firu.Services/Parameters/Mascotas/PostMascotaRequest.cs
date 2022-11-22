using System;

namespace Firu.Services.Parameters.Mascotas
{
    public class PostMascotaRequest
    {
        public string? Nombre { get; set; }
        public string? Raza { get; set; }
        public string? Edad { get; set; }
        public string? Peso { get; set; }
        public string? Castrado { get; set; }
        public string? Tamano { get; set; }
        public string? Especie { get; set; }
        public string? ResponsableId { get; set; }
        public string? Provincia { get; set; }
        public string? Ciudad { get; set; }
        public string? Localidad { get; set; }
    }
}