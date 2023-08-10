using System.Text.Json.Serialization;

namespace SistemaControlePlaca.Pages.ViewModel
{
    public class Localizacao
    {

        [JsonPropertyName("loc_id")]
        public int Loc_id { get; set; }

        [JsonPropertyName("loc_descricao")]
        public string Loc_descricao { get; set; }
    }

}
