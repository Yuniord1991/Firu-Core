using Firu.Data.Extensions;
using Firu.Services.Helpers;
using Firu.Services.Interfaces;
using Firu_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Firu.Data.dbContext;
using Firu.Services.Parameters.Adoptantes;

namespace Firu.Services.Services
{
    public class AdoptanteService : IAdoptanteService
    {
        private readonly FiruDBContext _context;
        protected readonly IMapper _mapper;

        public AdoptanteService(
            FiruDBContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllAdoptantesResponse> Get(GetAllAdoptantesRequest request)
        {
            var response = new GetAllAdoptantesResponse();

            //var hold = await _context.Adoptante.FromSqlRaw("select * from Adoptantes").ToListAsync();
            var hold = await _context.Adoptantes.ToListAsync();

            response.Adoptantes = hold;
            response.Length = hold.Count;

            return response;
        }

        public async Task<GetAdoptantesForDashboardResponse> Get(GetAdoptantesForDashboardRequest request)
        {
            var response = new GetAdoptantesForDashboardResponse();
            var espListPredicate = PredicateBuilder.True<Adoptante>();
            var badListPredicate = PredicateBuilder.True<Adoptante>();

            //var hold = await _context.Adoptante.FromSqlRaw( "select * from Adoptantes where en_espera = 'YES' ORDER BY Id OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY;" ).ToListAsync();

            espListPredicate = espListPredicate.And(c => c.EnEspera.Contains("YES"));

            var listaEspera = await _context.Adoptantes
                                .Where(espListPredicate)
                                .ToListAsync();

            response.ListaEsperaAdoptantes = listaEspera;

            badListPredicate = badListPredicate.And(c => c.Calificacion.Contains("BAD"));

            var listaMalosAdopt = await _context.Set<Adoptante>()
                                .Where(badListPredicate)
                                .ToListAsync();

            response.ListaMalosAdoptantes = listaMalosAdopt;

            return response;
        }

        public async Task<PostAdoptanteResponse> Post(PostAdoptanteRequest request)
        {
            var response = new PostAdoptanteResponse();

            var holdAdoptante = new Adoptante()
            {
                Dni = (int)request.Dni,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Edad = (int)request.Edad,
                Provincia = request.Provincia,
                Ciudad = request.Ciudad,
                Localidad = request.Localidad,
                Calificacion = request.Calificacion,
                EnEspera = request.EnEspera,
            };

            var exist = await _context.Adoptantes.FromSqlRaw("select * from Adoptantes where dni = {0}", holdAdoptante.Dni).ToListAsync();

            if (exist.Count == 0 || exist.Count == null)
            {
                _context.Adoptantes.Add(holdAdoptante);
                await _context.SaveChangesAsync();
            }

            return response;
        }


    }
}
