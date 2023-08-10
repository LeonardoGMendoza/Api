using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Placas.Entidades
{
    public class Sinalizacao
    {
        public int Sin_id { get; set; }


        public string Sin_Cod { get; set; }

        public string Sin_Descricao { get; set; }
    }

    internal class SinalizacaoMapper : IEntityTypeConfiguration<Sinalizacao>
    {
        public void Configure(EntityTypeBuilder<Sinalizacao> builder)
        {
            builder.ToTable("Tab_Sinalizacao");
            builder.HasKey(n => n.Sin_id);
        }
    }
}
