using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Placas.Entidades
{
    public class Posicao
    {

        public int Pos_ID { get; set; }

        public string Pos_Cod { get; set; }

        public string Pos_Descricao { get; set; }
    }

    internal class PosicaoMapper : IEntityTypeConfiguration<Posicao>
    {
        public void Configure(EntityTypeBuilder<Posicao> builder)
        {
            builder.ToTable("Tab_Posicao");
            builder.HasKey(n => n.Pos_ID);
        }
    }
}
