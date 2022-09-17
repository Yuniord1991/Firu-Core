using Firu.Services.Interfaces;
using Firu_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Firu.Services.Services
{
    public class MascotaService: IMascotaService
    {
        private readonly FiruDBContext _context;

        public MascotaService(FiruDBContext context)
        {
            _context = context;
        }

        public async Task<List<Mascota>> Get()
        { 
            var resp = await _context.Set<Mascota>().FromSqlRaw("select * from mascota").ToListAsync();
            return resp;
        }
            
    }
}
