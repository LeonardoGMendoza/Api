using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Placas.Entidades
{
    public class AtendimentoEspecificacoes
    {

        public int Esp_id { get; set; }

        public string Esp_Cod { get; set; }

        public string Esp_Descricao { get; set; }

       
            
    }

    internal class AtendimentoEspecificacoesMapper : IEntityTypeConfiguration<AtendimentoEspecificacoes>
    {
        public void Configure(EntityTypeBuilder<AtendimentoEspecificacoes> builder)
        {
            builder.ToTable("Tab_Atendimento_Especificacoes");
            builder.HasKey(n => n.Esp_id);
        }
    }
}
