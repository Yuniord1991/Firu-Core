using System;

namespace Firu.Services.Parameters.Responsables
{
    public class PostResponsableRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Edad { get; set; }
        public string? Puntuacion { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Localidad { get; set; }
    }
}