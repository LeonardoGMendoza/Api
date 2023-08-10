using System.Text.Json.Serialization;

namespace SistemaControlePlaca.Pages.ViewModel
{
    public class Sinalizacao
    {
        [JsonPropertyName("sin_id")]
        public int Sin_id { get; set; }

        [JsonPropertyName("sin_Cod")]
        public string Sin_Cod { get; set; }

        [JsonPropertyName("sin_Descricao")]
        public string Sin_Descricao { get; set; }
    }
}
