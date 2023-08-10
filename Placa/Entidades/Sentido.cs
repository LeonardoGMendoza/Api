using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Placas.Entidades
{
    public class Sentido
    {


        public int Sen_id { get; set; }

        public string Sen_Descricao { get; set; }
    }

    internal class SentidoMapper : IEntityTypeConfiguration<Sentido>
    {
        public void Configure(EntityTypeBuilder<Sentido> builder)
        {
            builder.ToTable("Tab_Sentido");
            builder.HasKey(n => n.Sen_id);
        }
    }
}
