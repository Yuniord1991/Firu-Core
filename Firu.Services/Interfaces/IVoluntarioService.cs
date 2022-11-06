using Firu.Services.Parameters.Voluntarios;
using System.Threading.Tasks;

namespace Firu.Services.Interfaces
{
    public interface IVoluntarioService
    {       
        Task<GetAllVoluntariosResponse> Get(GetAllVoluntariosRequest request);
        Task<PostVoluntarioResponse> Post(PostVoluntarioRequest request);
    }
}
