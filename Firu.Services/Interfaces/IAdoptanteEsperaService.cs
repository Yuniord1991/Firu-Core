using Firu.Services.Parameters.Adoptantes;
using System.Threading.Tasks;

namespace Firu.Services.Interfaces
{
    public interface IAdoptanteEsperaService
    {       
        Task<GetAdoptantesEsperaForDashboardResponse> Get(GetAdoptantesEsperaForDashboardRequest request);
        Task<GetAllAdoptantesEsperaForTableResponse> Get(GetAllAdoptantesEsperaForTableRequest request);
        Task<PostAdoptanteEsperaResponse> Post(PostAdoptanteEsperaRequest request);
    }
}
