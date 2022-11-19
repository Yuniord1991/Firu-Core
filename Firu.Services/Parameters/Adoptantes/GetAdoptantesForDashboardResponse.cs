using Firu_Core.Models;
using System;
using System.Collections.Generic;

namespace Firu.Services.Parameters.Adoptantes
{
    public class GetAdoptantesForDashboardResponse
    {
        public List<Adoptante> ListaEsperaAdoptantes { get; set; }
        public List<Adoptante> ListaMalosAdoptantes { get; set; }
    }
}