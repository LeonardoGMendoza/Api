using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Placas.Entidades
{
    public class EstadoConservacao
    {
        public int Con_id { get; set; }

        //public string Cod { get; set; } exemplo se fosse outro nome de coluna no banco

        public string Con_Cod { get; set; }
        public string Con_Descricao { get; set; }
        
    }

    internal class EstadoConservacaoMapper : IEntityTypeConfiguration<EstadoConservacao>
    {
        public void Configure(EntityTypeBuilder<EstadoConservacao> builder)
        {
            builder.ToTable("Tab_Estado_Conservacao");
            builder.HasKey(n => n.Con_id);
            //builder.Property(n => n.Cod).HasColumnName("Con_Cod").HasMaxLength(4);
        }
    }
}
