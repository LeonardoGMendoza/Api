using System.Text.Json.Serialization;

namespace SistemaControlePlaca.Pages.ViewModel
{
    public class Posicao
    {

        [JsonPropertyName("pos_ID")]
        public int Pos_ID { get; set; }

        [JsonPropertyName("pos_Cod")]
        public string Pos_Cod { get; set; }

        [JsonPropertyName("pos_Descricao")]
        public string Pos_Descricao { get; set; }
    }
}
