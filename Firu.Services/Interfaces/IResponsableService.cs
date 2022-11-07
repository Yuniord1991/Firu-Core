using Firu.Services.Parameters.Movimientos;
using System.Threading.Tasks;

namespace Firu.Services.Interfaces
{
    public interface IMovimientoService
    {       
        Task<GetAllMovimientosResponse> Get(GetAllMovimientosRequest request);
        Task<PostMovimientoResponse> Post(PostMovimientoRequest request);
        Task<GetAllMovimientosForTableResponse> Get(GetAllMovimientosForTableRequest request);
    }
}
