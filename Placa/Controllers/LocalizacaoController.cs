using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Placas.Servicos;
using System.Threading.Tasks;

namespace Placas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalizacaoController : ControllerBase
    {
      
        private readonly ILogger<LocalizacaoController> _logger;
        private readonly LocalizacaoServico _localizacaoServico;

        public LocalizacaoController(ILogger<LocalizacaoController> logger , LocalizacaoServico localizacaoServico)
        {
            _logger = logger;
            _localizacaoServico = localizacaoServico;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await this._localizacaoServico.ObterTodos());

    }
}
