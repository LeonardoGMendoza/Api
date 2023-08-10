using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SistemaControlePlaca.Pages.ViewModel
{
    public class SinalizacaoFotosItens
    {
        [JsonPropertyName("ite_id")]
        public int Ite_id { get; set; }

        [JsonPropertyName("rod_Id")]
        public int? Rod_Id { get; set; }

        [JsonIgnore]
        public InfoSinalizacao InfoSinalizacao { get; set; }

        [JsonPropertyName("ite_foto")]
        public int? ite_foto { get; set; }

        [JsonPropertyName("caminho_foto")]
        public string Caminho_foto { get; set; }
    }
}
