using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SistemaControlePlaca.Pages.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SistemaControlePlaca.Pages
{
    public class ListagemModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ListagemModel> _logger;
        private readonly ApiPlaca _apiPlaca;

        [BindProperty]
        public IEnumerable<InfoSinalizacao> infoSinalizacoes { get; set; } = new List<InfoSinalizacao>();

        [BindProperty]
        public InfoSinalizacao Payload { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> TipoPistas { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> TipoRegionais { get; set; }

        public ListagemModel(ILogger<ListagemModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _apiPlaca = _configuration.GetSection("ApiPlaca").Get<ApiPlaca>();
        }

        public async Task OnGetAsync()
        {
            using var http = new HttpClient();

            await CarregarDropDown(http);

            infoSinalizacoes = await JsonSerializer.DeserializeAsync<IEnumerable<InfoSinalizacao>>(await http.GetStreamAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointPlacaListagem}"));

          
        }

        public async Task<IActionResult> OnPostAsync()
        {

            using var http = new HttpClient();

            await CarregarDropDown(http);

            infoSinalizacoes = await JsonSerializer.DeserializeAsync<IEnumerable<InfoSinalizacao>>(await http.GetStreamAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointFiltroPlaca}/{Payload.Rod_Tipo}/{Payload.Rod_TipoPista}/{Payload.Rod_Codigo}"));

            return Page();
        }

        private async Task CarregarDropDown(HttpClient http)
        {
            TipoPistas = (await JsonSerializer.DeserializeAsync<IEnumerable<TipoPista>>(await http.GetStreamAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointTipoPista}")))
         .Select(n => new SelectListItem { Text = $"{n.Pis_Cod} - {n.Pis_Descricao}", Value = n.Pis_ID.ToString() });

            TipoRegionais = (await JsonSerializer.DeserializeAsync<IEnumerable<TipoRegional>>(await http.GetStreamAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointTipoRegional}")))
               .Select(n => new SelectListItem { Text = $"{n.Reg_Tipo} - {n.Reg_Descricao}", Value = n.Reg_id.ToString() });
        }
    }
}
