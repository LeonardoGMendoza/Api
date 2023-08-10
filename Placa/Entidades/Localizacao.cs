using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Placas.Entidades
{
    public class Localizacao
    {

        public int Loc_id { get; set; }
        
        public string Loc_descricao { get; set; }
    }

    internal class LocalizacaoMapper : IEntityTypeConfiguration<Localizacao>
    {
        public void Configure(EntityTypeBuilder<Localizacao> builder)
        {
            builder.ToTable("Tab_Localizacao");
            builder.HasKey(n => n.Loc_id);
        }
    }
}
