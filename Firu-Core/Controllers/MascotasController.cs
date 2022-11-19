using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firu_Core.Models;
using Firu.Services.Services;
using Firu.Services.Interfaces;
using Firu.Services.Parameters.Mascotas;
using Firu.Data.dbContext;

namespace Firu_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotasController : ControllerBase
    {
        private readonly FiruDBContext _context;
        private readonly IMascotaService _mascotaService;

        public MascotasController(FiruDBContext context, IMascotaService mascotaService)
        {
            _context = context;
            _mascotaService = mascotaService;
        }

        // GET: api/Mascotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mascota>>> GetMascota()
        {
            _context.Database.SetCommandTimeout(TimeSpan.FromMinutes(3));

            return await _context.Mascota.ToListAsync();

            //return await _context.Set<Mascota>().FromSqlRaw("select * from mascota").ToListAsync();

            //var response = await _mascotaService.Get();   ESTE FUNCIONA, CON LA LINEA DE ABAJO
            //return response;
        }

        // GET: api/Mascotas/GetAllMascotasForTable
        [HttpGet]
        [Route("GetAllMascotasForTable")]
        public async Task<ActionResult> Get([FromQuery] GetAllMascotasForTableRequest request)
        {
            var response = await _mascotaService.Get(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetMascotasForDashboard")]
        public async Task<ActionResult> Get([FromQuery] GetMascotasForDashboardRequest request)
        {
            var response = await _mascotaService.Get(request);

            return Ok(response);
        }

        // GET: api/Mascotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mascota>> GetMascota(int id)
        {
            var mascota = await _context.Mascota.FindAsync(id);

            if (mascota == null)
            {
                return NotFound();
            }

            return mascota;
        }

        // PUT: api/Mascotas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMascota(int id, Mascota mascota)
        {
            if (id != mascota.Id)
            {
                return BadRequest();
            }

            _context.Entry(mascota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Mascotas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mascota>> PostMascota(Mascota mascota)
        {
            _context.Mascota.Add(mascota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMascota", new { id = mascota.Id }, mascota);
        }

        // DELETE: api/Mascotas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mascota>> DeleteMascota(int id)
        {
            var mascota = await _context.Mascota.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }

            _context.Mascota.Remove(mascota);
            await _context.SaveChangesAsync();

            return mascota;
        }

        private bool MascotaExists(int id)
        {
            return _context.Mascota.Any(e => e.Id == id);
        }
    }
}
