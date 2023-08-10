using Microsoft.EntityFrameworkCore;
using Placas.Entidades;

namespace Placas.Contexto
{
    public class ContextoGeral : DbContext
    {
        public ContextoGeral(DbContextOptions<ContextoGeral> options) : base(options)
        {

        }

        public DbSet<AtendimentoEspecificacoes> AtendimentoEspecificacoes { get; set; }

       // public DbSet<DispositivosAuxiliares> DispositivosAuxiliares { get; set; }

        public DbSet<EstadoConservacao> EstadoConservacao { get; set; }

        public DbSet<InfoSinalizacao> InfoSinalizacao { get; set; }

        public DbSet<Localizacao> Localizacao { get; set; }

        public DbSet<Posicao> Posicao { get; set; }

        public DbSet<Sentido> Sentido { get; set; }

        public DbSet<Sinalizacao> Sinalizacao { get; set; }

        //public DbSet<SinalizacaoFotos> SinalizacaoFotos { get; set; }

        public DbSet<SinalizacaoFotosItens> SinalizacaoFotosItens { get; set; }

        public DbSet<TipoPista> TipoPista { get; set; }

        public DbSet<TipoRegional> TipoRegional { get; set; }

        #region Implementacao da configuracao
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoPistaMapper());
            modelBuilder.ApplyConfiguration(new TipoRegionalMapper());
            modelBuilder.ApplyConfiguration(new SinalizacaoFotosItensMapper());
            //modelBuilder.ApplyConfiguration(new SinalizacaoFotosMapper());
            modelBuilder.ApplyConfiguration(new PosicaoMapper());
            modelBuilder.ApplyConfiguration(new LocalizacaoMapper());
            //modelBuilder.ApplyConfiguration(new DispositivosAuxiliaresMapper());
            modelBuilder.ApplyConfiguration(new SinalizacaoMapper());
            modelBuilder.ApplyConfiguration(new SentidoMapper());
            modelBuilder.ApplyConfiguration(new EstadoConservacaoMapper());
            modelBuilder.ApplyConfiguration(new InfoSinalizacaoMapper());
            modelBuilder.ApplyConfiguration(new AtendimentoEspecificacoesMapper());
        }

        #endregion
    }
}
