using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Placas.Servicos;
using System.Threading.Tasks;

namespace Placas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SinalizacaoController : ControllerBase
    {
      
        private readonly ILogger<SinalizacaoController> _logger;
        private readonly SinalizacaoServico _sinalizacaoServico;

        public SinalizacaoController(ILogger<SinalizacaoController> logger , SinalizacaoServico sinalizacaoServico)
        {
            _logger = logger;
            _sinalizacaoServico = sinalizacaoServico;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this._sinalizacaoServico.ObterTodos());

    }
}
