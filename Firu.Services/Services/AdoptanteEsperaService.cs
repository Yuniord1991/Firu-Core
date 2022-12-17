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
    public class AdoptanteEsperaService : IAdoptanteEsperaService
    {
        private readonly FiruDBContext _context;
        protected readonly IMapper _mapper;

        public AdoptanteEsperaService(
            FiruDBContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAdoptantesEsperaForDashboardResponse> Get(GetAdoptantesEsperaForDashboardRequest request)
        {
            var response = new GetAdoptantesEsperaForDashboardResponse();

            //var hold = await _context.Adoptante.FromSqlRaw( "select * from Adoptantes where en_espera = 'YES' ORDER BY Id OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY;" ).ToListAsync();

            var take = 5;
            var listaEspera = await _context.AdoptantesEspera
                                .Take((int)take)
                                .ToListAsync();

            response.ListaEsperaAdoptantes = listaEspera;

            return response;
        }

        public async Task<GetAllAdoptantesEsperaForTableResponse> Get(GetAllAdoptantesEsperaForTableRequest request)
        {
            var response = new GetAllAdoptantesEsperaForTableResponse();
            var predicate = PredicateBuilder.True<AdoptanteEspera>();

            var take = request.PageSize;
            var skip = request.PageNumber * request.PageSize;
            var direction = string.IsNullOrEmpty(request.SortDirection) ? "desc" : request.SortDirection;
            var property = string.IsNullOrEmpty(request.SortProperty) ? nameof(Adoptante.Id) : request.SortProperty;

            if ((request.Nombre) != null && (request.Nombre) != "")
                predicate = predicate.And(c => c.Nombre.Contains(request.Nombre));

            if ((request.Telefono) != null && (request.Telefono) != 0)
                predicate = predicate.And(c => c.Telefono.Equals(request.Telefono));

            if ((request.Ciudad) != null && (request.Ciudad) != "")
                predicate = predicate.And(c => c.Ciudad.Contains(request.Ciudad));

            if ((request.Especie) != null && (request.Especie) != "")
                predicate = predicate.And(c => c.Especie.Contains(request.Especie));

            if ((request.Raza) != null && (request.Raza) != "")
                predicate = predicate.And(c => c.Raza.Contains(request.Raza));

            if ((request.Tamano) != null && (request.Tamano) != "")
                predicate = predicate.And(c => c.Tamano.Contains(request.Tamano));

            if ((request.Color) != null && (request.Color) != "")
                predicate = predicate.And(c => c.Color.Contains(request.Color));

            if ((request.Edad) != null && (request.Edad) != 0)
                predicate = predicate.And(c => c.Edad.Equals(request.Edad));

            var adoptantesList = await _context.Set<AdoptanteEspera>().PropertySorting(property, direction)
                .Where(predicate)
                .Skip((int)skip)
                .Take((int)take)
                .ToListAsync();

            var adoptantesLength = await _context.Set<AdoptanteEspera>()
                .Where(predicate)
                .CountAsync();

            response.Length = Convert.ToInt32(adoptantesLength);
            response.AdoptantesEspera = _mapper.Map<List<AdoptanteEspera>>(adoptantesList);

            return response;
        }

        public async Task<PostAdoptanteEsperaResponse> Post(PostAdoptanteEsperaRequest request)
        {
            var response = new PostAdoptanteEsperaResponse();

            var holdAdoptante = new AdoptanteEspera()
            {
                Nombre = request.Nombre,
                Telefono = Convert.ToInt32(request.Telefono),
                Ciudad = request.Ciudad,
                Especie = request.Especie != "" ? request.Especie : "",
                Raza = request.Raza != "" ? request.Raza : "",
                Tamano = request.Tamano != "" ? request.Tamano : "",
                Color = request.Color != "" ? request.Color : "",
                Edad = request.Edad != "" ? Convert.ToInt32(request.Edad) : 0,
            };

            _context.AdoptantesEspera.Add(holdAdoptante);
            await _context.SaveChangesAsync();

            return response;
        }


    }
}
