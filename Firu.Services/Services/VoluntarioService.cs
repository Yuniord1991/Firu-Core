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
using Firu.Services.Parameters.Voluntarios;

namespace Firu.Services.Services
{
    public class VoluntarioService: IVoluntarioService
    {
        private readonly FiruDBContext _context;
        protected readonly IMapper _mapper;

        public VoluntarioService(
            FiruDBContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllVoluntariosResponse> Get(GetAllVoluntariosRequest request)
        {
            var response = new GetAllVoluntariosResponse();

            var hold = await _context.Voluntario.FromSqlRaw("select * from Voluntario").ToListAsync();

            response.Voluntarios = hold;
            response.Length = hold.Count;

            return response;
        }

        public async Task<GetVoluntariosForDashboardResponse> Get(GetVoluntariosForDashboardRequest request)
        {
            var response = new GetVoluntariosForDashboardResponse();

            var hold = await _context.Voluntario.FromSqlRaw( "select * from Voluntario ORDER BY Id OFFSET 0 ROWS FETCH NEXT 6 ROWS ONLY;" ).ToListAsync();

            response.Voluntarios = hold;

            return response;
        }

        public async Task<GetAllVoluntariosForTableResponse> Get(GetAllVoluntariosForTableRequest request)
        {
            var response = new GetAllVoluntariosForTableResponse();
            var predicate = PredicateBuilder.True<Voluntario>();

            var take = request.PageSize;
            var skip = request.PageNumber * request.PageSize;
            var direction = string.IsNullOrEmpty(request.SortDirection) ? "desc" : request.SortDirection;
            var property = string.IsNullOrEmpty(request.SortProperty) ? nameof(Voluntario.Id) : request.SortProperty;

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

            var voluntariosList = await _context.Set<Voluntario>().PropertySorting(property, direction)
                .Where(predicate)
                .Skip((int)skip)
                .Take((int)take)
                .ToListAsync();

            var voluntariosLength = await _context.Set<Voluntario>()
                .Where(predicate)
                .CountAsync();

            response.Length = Convert.ToInt32(voluntariosLength);
            response.Voluntarios = _mapper.Map<List<Voluntario>>(voluntariosList);

            return response;
        }

        public async Task<PostVoluntarioResponse> Post(PostVoluntarioRequest request)
        {
            var response = new PostVoluntarioResponse();

            var holdVoluntario = new Voluntario()
            {
                Dni = Convert.ToInt32(request.Dni),
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Edad = Convert.ToInt32(request.Edad),
                OrganizacionId = Convert.ToInt32(request.OrganizacionId),
                Provincia = request.Provincia,
                Ciudad = request.Ciudad,
                Localidad = request.Localidad
            };

            var exist = await _context.Voluntario.FromSqlRaw("select * from Voluntario where dni = {0}", holdVoluntario.Dni).ToListAsync();

            if (exist.Count == 0 || exist.Count == null)
            {
                _context.Voluntario.Add(holdVoluntario);
                await _context.SaveChangesAsync();
            }

            return response;
        }


    }
}
