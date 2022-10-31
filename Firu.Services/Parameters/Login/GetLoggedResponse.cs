
using Firu_Core.Entities;

namespace Firu.Services.Parameters.Login
{
    public class GetLoggedResponse
    {
        public bool Login { get; set; }
    
        public UserInfoDto UserLogged { get; set; }
    }
}