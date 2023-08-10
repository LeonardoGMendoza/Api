using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Placas.Entidades
{
    public class InfoSinalizacao
    {
        public int? Rod_id { get; set; }
        public int? Rod_Tipo { get; set; }
        public TipoRegional TipoRegional { get; set; }
        
        public string Rod_Codigo { get; set; }
        public DateTime? Rod_Data { get; set; }
        public decimal? Rod_KMInicial { get; set; }
        public decimal? Rod_KMFinal { get; set; }
        public int? Rod_TipoPista { get; set; }
        public TipoPista TipoPista { get; set; }
        public int? Rod_Sentido { get; set; }

        public Sentido Sentido { get; set; }
        public int? Rod_Posicao { get; set; }
        public Posicao Posicao { get; set; }
        public int Rod_localizacao { get; set; }

        public Localizacao Localizacao { get; set; }
        public int Rod_Ts { get; set; }
        public int? Rod_Classe { get; set; }
        public Sinalizacao  Sinalizacao { get; set; }
        
        public string Rod_Implantacao { get; set; }
        public int? Rod_Estado_Conservacao { get; set; }
        public EstadoConservacao EstadoConservacao { get; set; }
        public string Rod_Situacao { get; set; }
        public int? Rod_Atendimento_Especificacoes { get; set; }

        public AtendimentoEspecificacoes AtendimentoEspecificacoes { get; set; }
        public string Rod_Georreferencia { get; set; }
        public string Rod_dimensoes { get; set; }
        public string Rod_Cor { get; set; }
        public string Rod_Cadencia_Intervalo { get; set; }
        public int? Rod_Retrorr_Obtida { get; set; }
        public int? Rod_Retrorr_Referencia { get; set; }
        public string Rod_Qr_Code { get; set; }
        public string Rod_Observacao { get; set; }
        public IEnumerable<SinalizacaoFotosItens> SinalizacaoFotosItens { get; set; }

    }


    internal class InfoSinalizacaoMapper : IEntityTypeConfiguration<InfoSinalizacao>
    {
        public void Configure(EntityTypeBuilder<InfoSinalizacao> builder)
        {
            builder.ToTable("Tab_Info_Sinalizacao");
            builder.HasKey(n => n.Rod_id);
            builder.HasOne(n => n.EstadoConservacao).WithMany().HasForeignKey(n => n.Rod_Estado_Conservacao);
            builder.HasOne(n => n.Posicao).WithMany().HasForeignKey(n => n.Rod_Posicao);
            builder.HasOne(n => n.AtendimentoEspecificacoes).WithMany().HasForeignKey(n => n.Rod_Atendimento_Especificacoes);
            builder.HasOne(n => n.TipoPista).WithMany().HasForeignKey(n => n.Rod_TipoPista);
            builder.HasOne(n => n.Localizacao).WithMany().HasForeignKey(n => n.Rod_localizacao);
            builder.HasOne(n => n.Sentido).WithMany().HasForeignKey(n => n.Rod_Sentido);
            builder.HasOne(n => n.TipoRegional).WithMany().HasForeignKey(n => n.Rod_Tipo);
            builder.HasOne(n => n.Sinalizacao).WithMany().HasForeignKey(n => n.Rod_Classe);
            builder.Ignore(n => n.SinalizacaoFotosItens);

            // CONSTRATINT FK_EstadoConservacao FOREIGN KEY(Rod_Estado_Conservacao) REFERENCES Estado_Conservacao(Con_id)
        }
    }
}
