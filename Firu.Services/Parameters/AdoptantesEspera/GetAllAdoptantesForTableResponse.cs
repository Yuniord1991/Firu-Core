using Firu_Core.Models;
using System;
using System.Collections.Generic;

namespace Firu.Services.Parameters.Adoptantes
{
    public class GetAllAdoptantesEsperaForTableResponse
    {
        public List<AdoptanteEspera> AdoptantesEspera { get; set; }
        public int Length { get; set; }
    }
}