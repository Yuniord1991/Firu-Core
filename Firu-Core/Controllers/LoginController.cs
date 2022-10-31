using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firu_Core.Models;
using Firu.Services.Services;
using Firu.Services.Interfaces;
using Firu.Services.Parameters.Login;

namespace Firu_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly FiruDBContext _context;
        private readonly ILoginService _loginService;

        public LoginController(FiruDBContext context, ILoginService loginService)
        {
            _context = context;
            _loginService = loginService;
        }
        [HttpGet]
        [Route("GetLogged")]
        public async Task<ActionResult> Get([FromQuery] GetLoggedRequest request)
        {
            var response = await _loginService.Get(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetCheckingExistentFields")]
        public async Task<ActionResult> Get([FromQuery] GetCheckingExistentFieldsRequest request)
        {
            var response = await _loginService.Get(request);

            return Ok(response);
        }

        // LE COLOQUE COMO GET PORQUE SI LE DEJO EL POST, LOS VALORES DEL REQUEST NO PASAN Y QUEDAN EN "NULL"
        [HttpPost]
        [Route("PostUser")]
        public async Task<IActionResult> Post([FromBody] PostUserRequest request)
        {
            var response = await _loginService.Post(request);

            return Ok(response);
        }
    }
}
