using Firu_Core.Models;
using System;
using System.Collections.Generic;

namespace Firu.Services.Parameters.Adoptantes
{
    public class GetAllAdoptantesResponse
    {
        public List<Adoptante> Adoptantes { get; set; }
        public int Length { get; set; }
    }
}