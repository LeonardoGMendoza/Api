using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Placas.Servicos;
using System.Threading.Tasks;

namespace Placas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadoConservacaoController : ControllerBase
    {
      
        private readonly ILogger<EstadoConservacaoController> _logger;
        private readonly EstadoConservacaoServico _estadoConservacaoServico;

        public EstadoConservacaoController(ILogger<EstadoConservacaoController> logger , EstadoConservacaoServico estadoConservacaoServico)
        {
            _logger = logger;
            _estadoConservacaoServico = estadoConservacaoServico;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this._estadoConservacaoServico.ObterTodos());

    }
}
