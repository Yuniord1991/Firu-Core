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
                Fecha = Convert.ToDateTime(request.Fecha),
                Monto = Convert.ToDecimal(request.Monto),
                DireccionRemitente = request.DireccionRemitente,
                DireccionDestino = request.DireccionDestino,
            };

            _context.Movimiento.Add(holdMovimiento);
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<GetAllMovimientosForTableResponse> Get(GetAllMovimientosForTableRequest request)
        {
            var response = new GetAllMovimientosForTableResponse();
            var predicate = PredicateBuilder.True<Movimiento>();

            var take = request.PageSize;
            var skip = request.PageNumber * request.PageSize;
            var direction = string.IsNullOrEmpty(request.SortDirection) ? "desc" : request.SortDirection;
            var property = string.IsNullOrEmpty(request.SortProperty) ? nameof(Movimiento.Id) : request.SortProperty;


            if ((request.Tipo) != null && (request.Tipo) != "")
                predicate = predicate.And(c => c.Tipo.Contains(request.Tipo));

            if ((request.Remitente) != null && (request.Remitente) != "")
                predicate = predicate.And(c => c.Remitente.Contains(request.Remitente));

            if ((request.Destino) != null && (request.Destino) != "")
                predicate = predicate.And(c => c.Destino.Contains(request.Destino));

            if ((request.Motivo) != null && (request.Motivo) != "")
                predicate = predicate.And(c => c.Motivo.Contains(request.Motivo));

            if ((request.Monto) != null && (request.Monto) != 0)
                predicate = predicate.And(c => c.Monto.Equals(request.Monto));

            if (request.Fecha.HasValue)
                predicate = predicate.And(c => c.Fecha > request.Fecha.Value);

            if ((request.DireccionRemitente) != null && (request.DireccionRemitente) != "")
                predicate = predicate.And(c => c.DireccionRemitente.Contains(request.DireccionRemitente));

            if ((request.DireccionDestino) != null && (request.DireccionDestino) != "")
                predicate = predicate.And(c => c.DireccionDestino.Contains(request.DireccionDestino));

            var movimientosList = await _context.Set<Movimiento>().PropertySorting(property, direction)
                .Where(predicate)
                .Skip((int)skip)
                .Take((int)take)
                .ToListAsync();

            var movimientosLength = await _context.Set<Movimiento>()
                .Where(predicate)
                .CountAsync();

            response.Length = Convert.ToInt32(movimientosLength);
            response.Movimientos = _mapper.Map<List<Movimiento>>(movimientosList);

            return response;
        }

        public async Task<GetMovimientosForDashboardResponse> Get(GetMovimientosForDashboardRequest request)
        {
            var response = new GetMovimientosForDashboardResponse();

            //INGRESOS
            var predicateIngreso = PredicateBuilder.True<Movimiento>();
            predicateIngreso = predicateIngreso.And(c => c.Tipo.Contains("INGRESO"));

            var listIngresos = await _context.Set<Movimiento>()
                                .Where(predicateIngreso)
                                .ToListAsync();
            var totalIncome = 0;

            foreach (var income in listIngresos)
            {
                totalIncome = (int)(totalIncome + income.Monto);
            }

            response.Ingresos = totalIncome;

            //EGRESOS
            var predicateEgreso = PredicateBuilder.True<Movimiento>();
            predicateEgreso = predicateEgreso.And(c => c.Tipo.Contains("EGRESO"));

            var listEgresos =  await _context.Set<Movimiento>()
                                .Where(predicateEgreso)
                                .ToListAsync();

            var totalOutcome = 0;

            foreach (var outcome in listEgresos)
            {
                totalOutcome = (int)(totalOutcome + outcome.Monto);
            }

            response.Egresos = totalOutcome;

            //DONACIONES
            var predicateDonacion = PredicateBuilder.True<Movimiento>();
            predicateDonacion = predicateDonacion.And(c => c.Tipo.Contains("DONACION"));

            var listDonations = await _context.Set<Movimiento>()
                                .Where(predicateDonacion)
                                .ToListAsync();

            var totalDonations = 0;

            foreach (var donation in listDonations)
            {
                totalDonations = (int)(totalDonations + donation.Monto);
            }

            response.Donaciones = totalDonations;

            return response;
        }
    }
}
