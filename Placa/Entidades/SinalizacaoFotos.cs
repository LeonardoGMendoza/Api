using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Placas.Entidades
{
    public class SinalizacaoFotos
    {

        public int Fot_id { get; set; }

        public int Rod_id { get; set; }

        public int Ite_Foto { get; set; }
    }

    internal class SinalizacaoFotosMapper : IEntityTypeConfiguration<SinalizacaoFotos>
    {
        public void Configure(EntityTypeBuilder<SinalizacaoFotos> builder)
        {
            builder.ToTable("Sinalizacao_Fotos");
            builder.HasKey(n => n.Fot_id);
        }
    }
}
