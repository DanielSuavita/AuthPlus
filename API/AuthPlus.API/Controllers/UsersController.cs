using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultaUsuarios;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegistroInicio;

namespace AuthPlus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ValidarExistenciaUsuario _UserValidator;
        private readonly ValidarInformacionUsuario _GetUserInfo;
        private readonly RegistrarUsuarios _RegisterUser;
        private readonly AsignarRol _AssignRole;

        private readonly ILogger<UsersController> _logger;

        public UsersController(
            ILogger<UsersController> logger, 
            ValidarExistenciaUsuario UserValidator,
            ValidarInformacionUsuario  UserInfo,
            RegistrarUsuarios  UserRegister,
            AsignarRol AssignRole
            )
        {
            _logger = logger;
            _UserValidator = UserValidator;
            _GetUserInfo = UserInfo;
            _RegisterUser = UserRegister;
            _AssignRole = AssignRole;
        }

        [HttpGet]
        public List<Usuario> Get()
        {
            _UserValidator.Validate();
            return _UserValidator.Response();
        }
        
        [HttpPost("UserInfo")]
        public Usuario Get(Usuario User)
        {
            _GetUserInfo.Validate(User);
            return _GetUserInfo.Response(User);
        }
        
        [HttpPost("Register")]
        public bool Register(Usuario User)
        {
            _RegisterUser.Validate(User);
            if( _RegisterUser.Response(User)){
                _AssignRole.Response(User);
                return true;
            }
            return false;
        }
    }
}
