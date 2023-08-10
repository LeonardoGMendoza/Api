using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Placas.Entidades
{
    public class TipoRegional
    {

        public int Reg_id { get; set; }


        public string Reg_Tipo { get; set; }

        public string Reg_Descricao { get; set; }
    }

    internal class TipoRegionalMapper : IEntityTypeConfiguration<TipoRegional>
    {
        public void Configure(EntityTypeBuilder<TipoRegional> builder)
        {
            builder.ToTable("Tab_Tipo_Regional");
            builder.HasKey(n => n.Reg_id);
        }

    }

}
