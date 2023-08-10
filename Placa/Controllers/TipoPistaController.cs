using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Placas.Servicos;
using System.Threading.Tasks;

namespace Placas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoPistaController : ControllerBase
    {
      
        private readonly ILogger<TipoPistaController> _logger;
        private readonly TipoPistaServico _tipoPistaServico;

        public TipoPistaController(ILogger<TipoPistaController> logger , TipoPistaServico tipoPistaServico)
        {
            _logger = logger;
            _tipoPistaServico = tipoPistaServico;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this._tipoPistaServico.ObterTodos());

    }
}
