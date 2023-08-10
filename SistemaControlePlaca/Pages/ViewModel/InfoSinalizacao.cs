using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SistemaControlePlaca.Pages.ViewModel
{
    public class InfoSinalizacao
    {
        [JsonPropertyName("rod_id")]
        public int? Rod_id { get; set; }

        [JsonPropertyName("rod_Tipo")]
        public int? Rod_Tipo { get; set; }

        [JsonPropertyName("tipoRegional")]
        public TipoRegional TipoRegional { get; set; }

        [JsonPropertyName("rod_Codigo")]
        public string Rod_Codigo { get; set; }

        [JsonPropertyName("rod_Data")]
        public DateTime? Rod_Data { get; set; }

        [JsonPropertyName("rod_KMInicial")]
        public decimal? Rod_KMInicial { get; set; }

        [JsonPropertyName("rod_KMFinal")]
        public decimal? Rod_KMFinal { get; set; }

        [JsonPropertyName("rod_TipoPista")]
        public int? Rod_TipoPista { get; set; }

        [JsonPropertyName("tipoPista")]
        public TipoPista TipoPista { get; set; }

        [JsonPropertyName("rod_Sentido")]
        public int? Rod_Sentido { get; set; }

        [JsonPropertyName("sentido")]
        public Sentido Sentido { get; set; }

        [JsonPropertyName("rod_Posicao")]
        public int? Rod_Posicao { get; set; }

        [JsonPropertyName("posicao")]
        public Posicao Posicao { get; set; }

        [JsonPropertyName("rod_localizacao")]
        public int Rod_localizacao { get; set; }

        [JsonPropertyName("localizacao")]
        public Localizacao Localizacao { get; set; }

        [JsonPropertyName("rod_Ts")]
        public int Rod_Ts { get; set; }

        [JsonPropertyName("rod_Classe")]
        public int? Rod_Classe { get; set; }

        [JsonPropertyName("sinalizacao")]
        public Sinalizacao Sinalizacao { get; set; }

        [JsonPropertyName("rod_Implantacao")]
        public string Rod_Implantacao { get; set; }

        [JsonPropertyName("rod_Estado_Conservacao")]
        public int? Rod_Estado_Conservacao { get; set; }

        [JsonPropertyName("estadoConservacao")]
        public EstadoConservacao EstadoConservacao { get; set; }

        [JsonPropertyName("rod_Situacao")]
        public string Rod_Situacao { get; set; }
        
        [JsonPropertyName("rod_Atendimento_Especificacoes")]
        public int? Rod_Atendimento_Especificacoes { get; set; }

        [JsonPropertyName("atendimentoEspecificacoes")]
        public AtendimentoEspecificacoes AtendimentoEspecificacoes { get; set; }

        [JsonPropertyName("rod_Georreferencia")]
        public string Rod_Georreferencia { get; set; }

        [JsonPropertyName("rod_dimensoes")]
        public string Rod_dimensoes { get; set; }

        [JsonPropertyName("rod_Cor")]
        public string Rod_Cor { get; set; }

        [JsonPropertyName("rod_Cadencia_Intervalo")]
        public string Rod_Cadencia_Intervalo { get; set; }

        [JsonPropertyName("rod_Retrorr_Obtida")]
        public int? Rod_Retrorr_Obtida { get; set; }

        [JsonPropertyName("rod_Retrorr_Referencia")]
        public int? Rod_Retrorr_Referencia { get; set; }

        [JsonPropertyName("rod_Qr_Code")]
        public string Rod_Qr_Code { get; set; }

        [JsonPropertyName("rod_Observacao")]
        public string Rod_Observacao { get; set; }

        [JsonPropertyName("sinalizacaoFotosItens")]
        public IEnumerable<SinalizacaoFotosItens> SinalizacaoFotosItens { get; set; }

        public List<IFormFile> Foto { get; set; }

    }
}
