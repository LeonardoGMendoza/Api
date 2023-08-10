using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Placas.Entidades
{
    public class TipoPista
    {

        public int Pis_ID { get; set; }


        public string Pis_Cod { get; set; }

        public string Pis_Descricao { get; set; }
    }

    internal class TipoPistaMapper : IEntityTypeConfiguration<TipoPista>
    {
        public void Configure(EntityTypeBuilder<TipoPista> builder)
        {
            builder.ToTable("Tab_Tipo_Pista");
            builder.HasKey(n => n.Pis_ID);
        }
    }
}
