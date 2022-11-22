using Firu.Services.Parameters.Adoptantes;
using System.Threading.Tasks;

namespace Firu.Services.Interfaces
{
    public interface IAdoptanteService
    {       
        Task<GetAllAdoptantesResponse> Get(GetAllAdoptantesRequest request);
        Task<GetAdoptantesForDashboardResponse> Get(GetAdoptantesForDashboardRequest request);
        Task<GetAllAdoptantesForTableResponse> Get(GetAllAdoptantesForTableRequest request);
        Task<PostAdoptanteResponse> Post(PostAdoptanteRequest request);
    }
}
