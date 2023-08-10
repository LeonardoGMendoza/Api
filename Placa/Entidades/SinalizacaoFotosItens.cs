using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Placas.Entidades
{
    public class SinalizacaoFotosItens
    {
        public int Ite_id { get; set; }
        public int? Rod_Id { get; set; }
        public InfoSinalizacao InfoSinalizacao { get; set; }
        public int? ite_foto { get; set; }
        public string Caminho_foto { get; set; }
    }

    internal class SinalizacaoFotosItensMapper : IEntityTypeConfiguration<SinalizacaoFotosItens>
    {
        public void Configure(EntityTypeBuilder<SinalizacaoFotosItens> builder)
        {
            builder.ToTable("Tab_Sinalizacao_fotos_itens");
            builder.HasKey(n => n.Ite_id);
            builder.HasOne(n => n.InfoSinalizacao).WithMany().HasForeignKey(n => n.Rod_Id);
        }
    }
}
