using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Placas.Entidades
{
    public class DispositivosAuxiliares
    {
        public int Aux_id { get; set; }

        public string Aux_Cod { get; set; }
        
        public string Aux_Descricao { get; set; }
    }

    internal class DispositivosAuxiliaresMapper : IEntityTypeConfiguration<DispositivosAuxiliares>
    {
        public void Configure(EntityTypeBuilder<DispositivosAuxiliares> builder)
        {
            builder.ToTable("Tab_Dispositivos_auxiliares");
            builder.HasKey(n => n.Aux_id);
        }
    }
}
