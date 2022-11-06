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

        public async Task<PostVoluntarioResponse> Post(PostVoluntarioRequest request)
        {
            var response = new PostVoluntarioResponse();

            var holdVoluntario = new Voluntario()
            {
                Dni = request.Dni,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Edad = request.Edad,
                OrganizacionId = request.OrganizacionId,
                Provincia = request.Provincia,
                Ciudad = request.Ciudad,
                Localidad = request.Localidad,
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
