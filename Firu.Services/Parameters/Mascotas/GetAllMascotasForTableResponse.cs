using Firu_Core.Models;
using System;
using System.Collections.Generic;

namespace Firu.Services.Parameters.Mascotas
{
    public class GetAllMascotasForTableResponse
    {
        public List<Mascota> Mascotas { get; set; }
        public int Length { get; set; }
    }
}