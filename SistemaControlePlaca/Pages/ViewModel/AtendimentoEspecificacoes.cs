using System.Text.Json.Serialization;

namespace SistemaControlePlaca.Pages.ViewModel
{
    public class AtendimentoEspecificacoes
    {
        [JsonPropertyName("esp_id")]
        public int Esp_id { get; set; }

        [JsonPropertyName("esp_Cod")]
        public string Esp_Cod { get; set; }

        [JsonPropertyName("esp_Descricao")]
        public string Esp_Descricao { get; set; }       
    }
}
