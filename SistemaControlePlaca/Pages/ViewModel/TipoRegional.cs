using System.Text.Json.Serialization;

namespace SistemaControlePlaca.Pages.ViewModel
{
    public class TipoRegional
    {
        [JsonPropertyName("reg_id")]
        public int Reg_id { get; set; }

        [JsonPropertyName("reg_Tipo")]
        public string Reg_Tipo { get; set; }

        [JsonPropertyName("reg_Descricao")]
        public string Reg_Descricao { get; set; }
    }

}
