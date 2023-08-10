using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Placas.Servicos;
using System.Threading.Tasks;

namespace Placas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtendimentoEspecificacoesController : ControllerBase
    {
      
        private readonly ILogger<AtendimentoEspecificacoesController> _logger;
        private readonly AtendimentoEspecificacoesServico _atendimentoEspecificacoesServico;

        public AtendimentoEspecificacoesController(ILogger<AtendimentoEspecificacoesController> logger , AtendimentoEspecificacoesServico atendimentoEspecificacoesServico)
        {
            _logger = logger;
            _atendimentoEspecificacoesServico = atendimentoEspecificacoesServico;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this._atendimentoEspecificacoesServico.ObterTodos());

    }
}
