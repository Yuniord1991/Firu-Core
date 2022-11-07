using Firu.Services.Parameters.Responsables;
using System.Threading.Tasks;

namespace Firu.Services.Interfaces
{
    public interface IResponsableService
    {       
        Task<GetAllResponsablesResponse> Get(GetAllResponsablesRequest request);
        Task<PostResponsableResponse> Post(PostResponsableRequest request);
        Task<GetAllResponsablesForTableResponse> Get(GetAllResponsablesForTableRequest request);
    }
}
