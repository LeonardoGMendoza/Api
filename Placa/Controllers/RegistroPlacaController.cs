using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Placas.Entidades;
using Placas.Servicos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Placas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistroPlacaController : ControllerBase
    {
      
        private readonly ILogger<RegistroPlacaController> _logger;
        private readonly PlacaServico _placaServico;
        private readonly IConfiguration _configuration;
        public RegistroPlacaController(ILogger<RegistroPlacaController> logger , PlacaServico placaServico,
            IConfiguration configuration)
        {
            _logger = logger;
            _placaServico = placaServico;
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> Post()
        {

            InfoSinalizacao infoSinalizacao = new()
            {
                Rod_Tipo = Convert.ToInt32(Request.Form["Rod_Tipo"]),
                Rod_Codigo = Request.Form["Rod_Codigo"],
                Rod_Data = Convert.ToDateTime(Request.Form["Rod_Data"]),
                Rod_KMInicial = Convert.ToDecimal(Request.Form["Rod_KMInicial"]),
                Rod_KMFinal = Convert.ToDecimal(Request.Form["Rod_KMFinal"]),
                Rod_TipoPista = Convert.ToInt32(Request.Form["Rod_TipoPista"]),
                Rod_Sentido = Convert.ToInt32(Request.Form["Rod_Sentido"]),
                Rod_Posicao = Convert.ToInt32(Request.Form["Rod_Posicao"]),
                Rod_localizacao = Convert.ToInt32(Request.Form["Rod_localizacao"]),
                Rod_Ts = Convert.ToInt32(Request.Form["Rod_Ts"]),
                Rod_Classe = Convert.ToInt32(Request.Form["Rod_Classe"]),
                Rod_Implantacao = Request.Form["Rod_Implantacao"],
                Rod_Estado_Conservacao = Convert.ToInt32(Request.Form["Rod_Estado_Conservacao"]),
                Rod_Situacao = Request.Form["Rod_Situacao"],
                Rod_Atendimento_Especificacoes = Convert.ToInt32(Request.Form["Rod_Atendimento_Especificacoes"]),
                Rod_Georreferencia = Request.Form["Rod_Georreferencia"],
                Rod_dimensoes = Request.Form["Rod_dimensoes"],
                Rod_Cor = Request.Form["Rod_Cor"],
                Rod_Cadencia_Intervalo = Request.Form["Rod_Cadencia_Intervalo"],
                Rod_Retrorr_Obtida = Convert.ToInt32(Request.Form["Rod_Retrorr_Obtida"]),
                Rod_Retrorr_Referencia = Convert.ToInt32(Request.Form["Rod_Retrorr_Referencia"]),
                Rod_Qr_Code = Request.Form["Rod_Qr_Code"],
                Rod_Observacao = Request.Form["Rod_Observacao"]
            };

            var retornoInfoSinalizacao = await this._placaServico.Inserir(infoSinalizacao);
            var arquivos = Request.Form.Files;

            if(!arquivos.Any()) return Ok(new { mensagem = "Sucesso", retornoInfoSinalizacao });

            List<SinalizacaoFotosItens> listaSinalizacaoFotosItens = new();
            var contador = 1;

            foreach (var arquivo in arquivos)
            {
                using var ms = new MemoryStream();
                ms.Position = 0;
                await arquivo.CopyToAsync(ms);
                var caminhoBase = _configuration.GetValue<string>("CaminhoBaseFoto");

                var caminho = $@"{caminhoBase}{retornoInfoSinalizacao.Rod_id}\{retornoInfoSinalizacao.TipoRegional.Reg_Descricao}\img{contador}.jpg";

                listaSinalizacaoFotosItens.Add(new() { Rod_Id = retornoInfoSinalizacao.Rod_id, ite_foto = contador , Caminho_foto = caminho });

                if (!Directory.Exists(@$"{caminhoBase}{retornoInfoSinalizacao.Rod_id}\{retornoInfoSinalizacao.TipoRegional.Reg_Descricao}")) Directory.CreateDirectory(@$"{caminhoBase}{retornoInfoSinalizacao.Rod_id}\{retornoInfoSinalizacao.TipoRegional.Reg_Descricao}");

                await System.IO.File.WriteAllBytesAsync($@"{caminhoBase}{retornoInfoSinalizacao.Rod_id}\{retornoInfoSinalizacao.TipoRegional.Reg_Descricao}\img{contador}.jpg", ms.ToArray());

                contador++;
            }

            if (listaSinalizacaoFotosItens.Any()) await this._placaServico.InserirFotos(listaSinalizacaoFotosItens.ToArray());

            var objetoRetorno = new { retornoInfoSinalizacao, listaSinalizacaoFotosItens };

            return Ok(new { mensagem = "Sucesso" , objetoRetorno });
        }


        [HttpGet]
        [Route("PlacaListagem")]
        public async Task<IActionResult> Get()
        {
            var listaPlacas = await this._placaServico.ObterTodos();

            return Ok(listaPlacas);
        }


        [HttpGet]
        [Route("PlacaListagem/{Rod_id}")]
        public async Task<IActionResult> Get(int Rod_id)
        {
            var listaPlacas = await this._placaServico.ObterPorId(Rod_id);

            return Ok(listaPlacas);
        }


        [HttpGet]
        [Route("FiltroPlaca/{Rod_Tipo:int}/{Rod_TipoPista:int}/{Rod_Codigo?}")]
        public async Task<IActionResult> FiltroPlaca(int Rod_Tipo,int Rod_TipoPista, string Rod_Codigo)
        {
            var listaPlacas = await this._placaServico.ObterPorFiltro(Rod_Tipo, Rod_TipoPista, Rod_Codigo);

            return Ok(listaPlacas);
        }
    }
}
