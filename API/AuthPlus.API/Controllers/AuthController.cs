using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultaUsuarios;
using Entities;
using InicioSesion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthPlus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IniciarSesion _LoginRegister;
        private readonly RegistrarLog _LogRegister;

        private readonly ILogger<AuthController> _logger;

        public AuthController(
            ILogger<AuthController> logger, 
            IniciarSesion UserValidator,
            RegistrarLog LogRegister
            )
        {
            _logger = logger;
            _LoginRegister = UserValidator;
            _LogRegister = LogRegister;
        }

        [HttpPost]
        public bool Login(Usuario User)
        {
            _LoginRegister.Validate(User);
            var IsAuthenticated = _LoginRegister.Response(User);
            if(_LoginRegister.Response(User)){
                _LoginRegister.Response(User);
                return true;
            }
            return false;
        }
    }
}
