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
using Firu.Services.Parameters.Responsables;

namespace Firu.Services.Services
{
    public class ResponsableService : IResponsableService
    {
        private readonly FiruDBContext _context;
        protected readonly IMapper _mapper;

        public ResponsableService(
            FiruDBContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllResponsablesResponse> Get(GetAllResponsablesRequest request)
        {
            var response = new GetAllResponsablesResponse();

            var hold = await _context.Responsable.FromSqlRaw("select * from Responsable").ToListAsync();

            response.Responsables = hold;
            response.Length = hold.Count;

            return response;
        }

        public async Task<PostResponsableResponse> Post(PostResponsableRequest request)
        {
            var response = new PostResponsableResponse();

            var holdResponsable = new Responsable()
            {
                Nombre = request.Nombre,
                Edad = request.Edad,
                Puntuacion = request.Puntuacion,
                Provincia = request.Provincia,
                Ciudad = request.Ciudad,
                Localidad = request.Localidad
            };

            _context.Responsable.Add(holdResponsable);
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<GetAllResponsablesForTableResponse> Get(GetAllResponsablesForTableRequest request)
        {
            var response = new GetAllResponsablesForTableResponse();
            var predicate = PredicateBuilder.True<Responsable>();

            var take = request.PageSize;
            var skip = request.PageNumber * request.PageSize;
            var direction = string.IsNullOrEmpty(request.SortDirection) ? "desc" : request.SortDirection;
            var property = string.IsNullOrEmpty(request.SortProperty) ? nameof(Responsable.Id) : request.SortProperty;

            if ((request.Nombre) != null && (request.Nombre) != "")
                predicate = predicate.And(c => c.Nombre.Contains(request.Nombre));

            if ((request.Edad) != null && (request.Edad) != 0)
                predicate = predicate.And(c => c.Edad.Equals(request.Edad));

            if ((request.Puntuacion) != null && (request.Puntuacion) != "")
                predicate = predicate.And(c => c.Puntuacion.Contains(request.Puntuacion));

            if ((request.Provincia) != null && (request.Provincia) != "")
                predicate = predicate.And(c => c.Provincia.Contains(request.Provincia));

            if ((request.Ciudad) != null && (request.Ciudad) != "")
                predicate = predicate.And(c => c.Ciudad.Contains(request.Ciudad));

            if ((request.Localidad) != null && (request.Localidad) != "")
                predicate = predicate.And(c => c.Localidad.Contains(request.Localidad));

            var responsableList = await _context.Set<Responsable>().PropertySorting(property, direction)
                .Where(predicate)
                .Skip((int)skip)
                .Take((int)take)
                .ToListAsync();

            var responsableLength = await _context.Set<Responsable>()
                .Where(predicate)
                .CountAsync();

            response.Length = Convert.ToInt32(responsableLength);
            response.Responsables = _mapper.Map<List<Responsable>>(responsableList);

            return response;
        }
    }
}
