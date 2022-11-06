using Firu.Data.Extensions;
using Firu.Services.Helpers;
using Firu.Services.Interfaces;
using Firu.Services.Parameters.Mascotas;
using Firu_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Firu.Data.dbContext;

namespace Firu.Services.Services
{
    public class MascotaService: IMascotaService
    {
        private readonly FiruDBContext _context;
        protected readonly IMapper _mapper;

        public MascotaService(
            FiruDBContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Mascota>> Get()
        { 
            var resp = await _context.Set<Mascota>().FromSqlRaw("select * from mascota").ToListAsync();
            return resp;
        }

        public async Task<GetAllMascotasForTableResponse> Get(GetAllMascotasForTableRequest request)
        {
            var response = new GetAllMascotasForTableResponse();
            var predicate = PredicateBuilder.True<Mascota>();

            var take = request.PageSize;
            var skip = request.PageNumber * request.PageSize;
            var direction = string.IsNullOrEmpty(request.SortDirection) ? "desc" : request.SortDirection;
            var property = string.IsNullOrEmpty(request.SortProperty) ? nameof(Mascota.Id) : request.SortProperty;


            if ((request.Especie) != null && (request.Especie) != "")
                predicate = predicate.And(c => c.Especie.Contains(request.Especie));

            if ((request.Raza) != null && (request.Raza) != "")
                predicate = predicate.And(c => c.Raza.Contains(request.Raza));

            if ((request.Edad) != null && (request.Edad) != 0)
                predicate = predicate.And(c => c.Edad.Equals(request.Edad));

            if ((request.Peso) != null && (request.Peso) != 0)
                predicate = predicate.And(c => c.Peso.Equals(request.Peso));

            if ((request.Castrado) != null)
                predicate = predicate.And(c => c.Castrado.Equals(request.Castrado));

            if ((request.Tamano) != null && (request.Tamano) != 0)
                predicate = predicate.And(c => c.Tamano.Equals(request.Tamano));

            if ((request.Ciudad) != null && (request.Ciudad) != "")
                predicate = predicate.And(c => c.Ciudad.Contains(request.Ciudad));

            var mascotasList = await _context.Set<Mascota>().PropertySorting(property, direction)
                .Where(predicate)
                .Skip((int)skip)
                .Take((int)take)
                .ToListAsync();

            var mascotasLength = await _context.Set<Mascota>()
                .Where(predicate)
                .CountAsync();

            response.Length = Convert.ToInt32(mascotasLength);
            response.Mascotas = _mapper.Map<List<Mascota>>(mascotasList);

            //_context.Database.SetCommandTimeout(TimeSpan.FromMinutes(3));
            //var utilizarEsto =  await _context.Mascota.ToListAsync();


            return response;
        }


    }
}
