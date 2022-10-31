using Firu.Services.Parameters.Login;
using Firu_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Firu.Services.Interfaces
{
    public interface ILoginService
    {
        //Task<List<Mascota>> Get();
        //Task<GetAllMascotasForTableResponse> Get(PostUserRequest request);
        
        Task<GetLoggedResponse> Get(GetLoggedRequest request);
        Task<GetCheckingExistentFieldsResponse> Get(GetCheckingExistentFieldsRequest request);
        Task<PostUserResponse> Post(PostUserRequest request);
    }
}
