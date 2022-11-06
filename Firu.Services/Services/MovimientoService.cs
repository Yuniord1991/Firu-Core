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
using Firu.Services.Parameters.Movimientos;

namespace Firu.Services.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly FiruDBContext _context;
        protected readonly IMapper _mapper;

        public MovimientoService(
            FiruDBContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAllMovimientosResponse> Get(GetAllMovimientosRequest request)
        {
            var response = new GetAllMovimientosResponse();

            var hold = await _context.Movimiento.FromSqlRaw("select * from Movimiento").ToListAsync();

            response.Movimientos = hold;
            response.Length = hold.Count;

            return response;
        }

        public async Task<PostMovimientoResponse> Post(PostMovimientoRequest request)
        {
            var response = new PostMovimientoResponse();

            var holdMovimiento = new Movimiento()
            {
                Tipo = request.Tipo,
                Remitente = request.Remitente,
                Destino = request.Destino,
                Motivo = request.Motivo,
                Fecha = request.Fecha,
                Monto = request.Monto,
                DireccionRemitente = request.DireccionRemitente,
                DireccionDestino = request.DireccionDestino,
            };

            _context.Movimiento.Add(holdMovimiento);
            await _context.SaveChangesAsync();

            return response;
        }


    }
}
