using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultaUsuarios;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthPlus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ValidarLogsRecientesUsuario _GetRecentLogs;
        private readonly ValidarLogsTotalesUsuario _GetTotalLogs;

        private readonly ILogger<LogsController> _logger;

        public LogsController(
            ILogger<LogsController> logger, 
            ValidarLogsRecientesUsuario GetRecentLogs,
            ValidarLogsTotalesUsuario GetTotalLogs
            )
        {
            _logger = logger;
            _GetRecentLogs = GetRecentLogs;
            _GetTotalLogs = GetTotalLogs;
        }

        [HttpPost("Recent")]
        public List<Log> GetRecent(Usuario User)
        {
            _GetRecentLogs.Validate(User);
            return _GetRecentLogs.Response(User);
        }
        
        [HttpPost("All")]
        public List<Log> GetTotal(Usuario User)
        {
            _GetTotalLogs.Validate(User);
            return _GetTotalLogs.Response(User);
        }
    }
}
