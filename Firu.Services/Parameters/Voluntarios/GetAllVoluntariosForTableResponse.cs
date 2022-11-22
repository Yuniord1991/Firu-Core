using Firu_Core.Models;
using System;
using System.Collections.Generic;

namespace Firu.Services.Parameters.Voluntarios
{
    public class GetAllVoluntariosForTableResponse
    {
        public List<Voluntario> Voluntarios { get; set; }
        public int Length { get; set; }
    }
}