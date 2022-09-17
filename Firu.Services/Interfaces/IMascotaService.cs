using Firu_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Firu.Services.Interfaces
{
    public interface IMascotaService
    {
        Task<List<Mascota>> Get();
    }
}
