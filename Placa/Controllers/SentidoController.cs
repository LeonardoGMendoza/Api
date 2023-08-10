using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Placas.Servicos;
using System.Threading.Tasks;

namespace Placas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentidoController : ControllerBase
    {
      
        private readonly ILogger<SentidoController> _logger;
        private readonly SentidoServico _sentidoServico;

        public SentidoController(ILogger<SentidoController> logger , SentidoServico sentidoServico)
        {
            _logger = logger;
            _sentidoServico = sentidoServico;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this._sentidoServico.ObterTodos());

    }
}
