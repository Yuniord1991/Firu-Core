using System;

namespace Firu.Services.Parameters.Login
{
    public class GetCheckingExistentFieldsResponse
    {
        public Boolean? FirstName { get; set; }
        public Boolean? LastName { get; set; }
        public Boolean? UserName { get; set; }
        public Boolean? Email { get; set; }
    }
}