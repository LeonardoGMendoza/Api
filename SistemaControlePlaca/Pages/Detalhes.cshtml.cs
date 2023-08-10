using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SistemaControlePlaca.Pages.ViewModel;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SistemaControlePlaca.Pages
{
    public class DetalhesModel : PageModel
    {
        private readonly ILogger<DetalhesModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApiPlaca _apiPlaca;

        [BindProperty]
        public InfoSinalizacao Payload { get; set; }

        
        public DetalhesModel(ILogger<DetalhesModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _apiPlaca = _configuration.GetSection("ApiPlaca").Get<ApiPlaca>();
        }

        public async Task OnGetAsync(int id)
        {
            try
            {
                using var http = new HttpClient();

                Payload = await JsonSerializer.DeserializeAsync<InfoSinalizacao>(await http.GetStreamAsync($"{_apiPlaca.UrlBase}{_apiPlaca.EndPointPlacaListagem}/{id}"));
            }
            catch(Exception ex)
            {

            }
        }
    }
}
