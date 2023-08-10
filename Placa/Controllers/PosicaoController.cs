using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Placas.Servicos;
using System.Threading.Tasks;

namespace Placas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PosicaoController : ControllerBase
    {
      
        private readonly ILogger<PosicaoController> _logger;
        private readonly PosicaoServico _posicaoServico;

        public PosicaoController(ILogger<PosicaoController> logger , PosicaoServico posicaoServico)
        {
            _logger = logger;
            _posicaoServico = posicaoServico;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this._posicaoServico.ObterTodos());

    }
}
