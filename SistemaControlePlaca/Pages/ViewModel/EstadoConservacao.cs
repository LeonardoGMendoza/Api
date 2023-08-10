using System.Text.Json.Serialization;

namespace SistemaControlePlaca.Pages.ViewModel
{
    public class EstadoConservacao
    {
        [JsonPropertyName("con_id")]
        public int Con_id { get; set; }

        [JsonPropertyName("con_Cod")]
        public string Con_Cod { get; set; }

        [JsonPropertyName("con_Descricao")]
        public string Con_Descricao { get; set; }
        
    }
}
