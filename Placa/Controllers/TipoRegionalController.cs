using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Placas.Servicos;
using System.Threading.Tasks;

namespace Placas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoRegionalController : ControllerBase
    {
      
        private readonly ILogger<TipoRegionalController> _logger;
        private readonly TipoRegionalServico _tipoRegionalServico;

        public TipoRegionalController(ILogger<TipoRegionalController> logger , TipoRegionalServico tipoRegionalServico)
        {
            _logger = logger;
            _tipoRegionalServico = tipoRegionalServico;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this._tipoRegionalServico.ObterTodos());

    }
}
