using System.Text.Json.Serialization;

namespace SistemaControlePlaca.Pages.ViewModel
{
    public class Sentido
    {
        [JsonPropertyName("sen_id")]
        public int Sen_id { get; set; }

        [JsonPropertyName("sen_Descricao")]
        public string Sen_Descricao { get; set; }
    }
}
