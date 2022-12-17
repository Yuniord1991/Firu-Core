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
            var badListPredicate = PredicateBuilder.True<Adoptante>();

            badListPredicate = badListPredicate.And(c => c.Calificacion.Contains("BAD"));

            var take = 5;
            var listaMalosAdopt = await _context.Set<Adoptante>()
                                .Where(badListPredicate)
                                .Take((int)take)
                                .ToListAsync();

            response.ListaMalosAdoptantes = listaMalosAdopt;

            return response;
        }

        public async Task<GetAllAdoptantesForTableResponse> Get(GetAllAdoptantesForTableRequest request)
        {
            var response = new GetAllAdoptantesForTableResponse();
            var predicate = PredicateBuilder.True<Adoptante>();

            var take = request.PageSize;
            var skip = request.PageNumber * request.PageSize;
            var direction = string.IsNullOrEmpty(request.SortDirection) ? "desc" : request.SortDirection;
            var property = string.IsNullOrEmpty(request.SortProperty) ? nameof(Adoptante.Id) : request.SortProperty;

            if ((request.Dni) != null && (request.Dni) != 0)
                predicate = predicate.And(c => c.Dni.Equals(request.Dni));

            if ((request.Nombre) != null && (request.Nombre) != "")
                predicate = predicate.And(c => c.Nombre.Contains(request.Nombre));

            if ((request.Apellido) != null && (request.Apellido) != "")
                predicate = predicate.And(c => c.Apellido.Contains(request.Apellido));

            if ((request.Edad) != null && (request.Edad) != 0)
                predicate = predicate.And(c => c.Edad.Equals(request.Edad));

            if ((request.Provincia) != null && (request.Provincia) != "")
                predicate = predicate.And(c => c.Provincia.Contains(request.Provincia));

            if ((request.Ciudad) != null && (request.Ciudad) != "")
                predicate = predicate.And(c => c.Ciudad.Contains(request.Ciudad));

            if ((request.Localidad) != null && (request.Localidad) != "")
                predicate = predicate.And(c => c.Localidad.Contains(request.Localidad));

            if ((request.Calificacion) != null && (request.Calificacion) != "")
                predicate = predicate.And(c => c.Calificacion.Contains(request.Calificacion));

            if ((request.EnEspera) != null && (request.EnEspera) != "")
                predicate = predicate.And(c => c.EnEspera.Contains(request.EnEspera));

            var adoptantesList = await _context.Set<Adoptante>().PropertySorting(property, direction)
                .Where(predicate)
                .Skip((int)skip)
                .Take((int)take)
                .ToListAsync();

            var adoptantesLength = await _context.Set<Adoptante>()
                .Where(predicate)
                .CountAsync();

            response.Length = Convert.ToInt32(adoptantesLength);
            response.Adoptantes = _mapper.Map<List<Adoptante>>(adoptantesList);

            return response;
        }

        public async Task<PostAdoptanteResponse> Post(PostAdoptanteRequest request)
        {
            var response = new PostAdoptanteResponse();

            var holdAdoptante = new Adoptante()
            {
                Dni = Convert.ToInt32(request.Dni),
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Edad = Convert.ToInt32(request.Edad),
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
