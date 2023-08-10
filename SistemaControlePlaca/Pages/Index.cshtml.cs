using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SistemaControlePlaca.Pages.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SistemaControlePlaca.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApiPlaca _apiPlaca;

        [BindProperty]
        public InfoSinalizacao Payload { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> AtendimentoEspecificacoes { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> Sinalizacoes { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> Posicoes { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> Sentidos { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> TipoPistas { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> TipoRegionais { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> Localizacoes { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> EstadoConservacoes { get; set; }


        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _apiPlaca = _configuration.GetSection("ApiPlaca").Get<ApiPlaca>();
        }

        public async Task OnGetAsync()
        {
            try
            {
                using var http = new HttpClient();

                AtendimentoEspecificacoes = (await JsonSerializer.DeserializeAsync<IEnumerable<AtendimentoEspecificacoes>>(await http.GetStreamAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointAtendimentoEspecificacoes}")))
                    .Select(n => new SelectListItem { Text = $"{n.Esp_Cod} - {n.Esp_Descricao}", Value = n.Esp_id.ToString() });

                Posicoes = (await JsonSerializer.DeserializeAsync<IEnumerable<Posicao>>(await http.GetStreamAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointPosicao}")))
                   .Select(n => new SelectListItem { Text = $"{n.Pos_Cod} - {n.Pos_Descricao}", Value = n.Pos_ID.ToString() });

                Localizacoes = (await JsonSerializer.DeserializeAsync<IEnumerable<Localizacao>>(await http.GetStreamAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointLocalizacao}")))
                   .Select(n => new SelectListItem { Text = $"{n.Loc_descricao}", Value = n.Loc_id.ToString() });

                TipoPistas = (await JsonSerializer.DeserializeAsync<IEnumerable<TipoPista>>(await http.GetStreamAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointTipoPista}")))
                   .Select(n => new SelectListItem { Text = $"{n.Pis_Cod} - {n.Pis_Descricao}", Value = n.Pis_ID.ToString() });

                TipoRegionais = (await JsonSerializer.DeserializeAsync<IEnumerable<TipoRegional>>(await http.GetStreamAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointTipoRegional}")))
                   .Select(n => new SelectListItem { Text = $"{n.Reg_Tipo} - {n.Reg_Descricao}", Value = n.Reg_id.ToString() });

                EstadoConservacoes = (await JsonSerializer.DeserializeAsync<IEnumerable<EstadoConservacao>>(await http.GetStreamAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointEstadoConservacao}")))
                   .Select(n => new SelectListItem { Text = $"{n.Con_Cod} - {n.Con_Descricao}", Value = n.Con_id.ToString() });

                Sinalizacoes = (await JsonSerializer.DeserializeAsync<IEnumerable<Sinalizacao>>(await http.GetStreamAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointSinalizacao}")))
                   .Select(n => new SelectListItem { Text = $"{n.Sin_Cod} - {n.Sin_Descricao}", Value = n.Sin_id.ToString() });

                Sentidos = (await JsonSerializer.DeserializeAsync<IEnumerable<Sentido>>(await http.GetStreamAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointSentido}")))
                   .Select(n => new SelectListItem { Text = $"{n.Sen_Descricao}", Value = n.Sen_id.ToString() });
            }catch(Exception ex)
            {

            }
        }

        public async Task<IActionResult> OnPostAsync()
        {

            using var http = new HttpClient();

            var multiPart = new MultipartFormDataContent
            {
                { new StringContent(Payload.Rod_Tipo.ToString()), nameof(Payload.Rod_Tipo) },
                { new StringContent(Payload.Rod_Codigo), nameof(Payload.Rod_Codigo) },
                { new StringContent(Payload.Rod_Data.ToString()), nameof(Payload.Rod_Data) },
                { new StringContent(Payload.Rod_KMInicial.ToString()), nameof(Payload.Rod_KMInicial) },
                { new StringContent(Payload.Rod_KMFinal.ToString()), nameof(Payload.Rod_KMFinal) },
                { new StringContent(Payload.Rod_TipoPista.ToString()), nameof(Payload.Rod_TipoPista) },
                { new StringContent(Payload.Rod_Sentido.ToString()), nameof(Payload.Rod_Sentido) },
                { new StringContent(Payload.Rod_Posicao.ToString()), nameof(Payload.Rod_Posicao) },
                { new StringContent(Payload.Rod_localizacao.ToString()), nameof(Payload.Rod_localizacao) },
                { new StringContent(Payload.Rod_Ts.ToString()), nameof(Payload.Rod_Ts) },
                { new StringContent(Payload.Rod_Classe.ToString()), nameof(Payload.Rod_Classe) },
                { new StringContent(Payload.Rod_Implantacao.ToString()), nameof(Payload.Rod_Implantacao) },
                { new StringContent(Payload.Rod_Estado_Conservacao.ToString()), nameof(Payload.Rod_Estado_Conservacao) },
                { new StringContent(Payload.Rod_Situacao), nameof(Payload.Rod_Situacao) },
                { new StringContent(Payload.Rod_Atendimento_Especificacoes.ToString()), nameof(Payload.Rod_Atendimento_Especificacoes) },
                { new StringContent(Payload.Rod_Georreferencia), nameof(Payload.Rod_Georreferencia) },
                { new StringContent(Payload.Rod_dimensoes), nameof(Payload.Rod_dimensoes) },
                { new StringContent(Payload.Rod_Cor), nameof(Payload.Rod_Cor) },
                { new StringContent(Payload.Rod_Cadencia_Intervalo), nameof(Payload.Rod_Cadencia_Intervalo) },
                { new StringContent(Payload.Rod_Retrorr_Obtida.ToString()), nameof(Payload.Rod_Retrorr_Obtida) },
                { new StringContent(Payload.Rod_Retrorr_Referencia.ToString()), nameof(Payload.Rod_Retrorr_Referencia) },
                { new StringContent(Payload.Rod_Qr_Code), nameof(Payload.Rod_Qr_Code) },
                { new StringContent(Payload.Rod_Observacao), nameof(Payload.Rod_Observacao) }
            };

            foreach (var item in Payload.Foto)
            {
                using var ms = new MemoryStream();
                await item.CopyToAsync(ms);
                multiPart.Add(new ByteArrayContent(ms.ToArray()),item.Name,item.FileName);
            }

            await http.PostAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointPlaca}", multiPart);

            return  RedirectToPage("Listagem");
        }

    }
}
