using System.Text.Json.Serialization;

namespace SistemaControlePlaca.Pages.ViewModel
{
    public class TipoPista
    {
        [JsonPropertyName("pis_ID")]
        public int Pis_ID { get; set; }

        [JsonPropertyName("pis_Cod")]
        public string Pis_Cod { get; set; }

        [JsonPropertyName("pis_Descricao")]
        public string Pis_Descricao { get; set; }
    }
}
