using Newtonsoft.Json;

namespace Firu.Services.Parameters.Login
{
    public class PostUserRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}