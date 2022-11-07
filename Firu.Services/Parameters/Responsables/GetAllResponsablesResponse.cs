using Firu_Core.Models;
using System.Collections.Generic;

namespace Firu.Services.Parameters.Responsables
{
    public class GetAllResponsablesResponse
    {
        public List<Responsable> Responsables { get; set; }
        public int Length { get; set; }
    }
}