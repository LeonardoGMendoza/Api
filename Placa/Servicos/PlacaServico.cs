using Microsoft.EntityFrameworkCore;
using Placas.Contexto;
using Placas.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Placas.Servicos
{
    public class PlacaServico
    {
        private readonly ContextoGeral _contextoGeral;
        public PlacaServico(ContextoGeral contextoGeral)
        {
            _contextoGeral = contextoGeral;
        }

        public async Task<InfoSinalizacao> Inserir(InfoSinalizacao infoSinalizacao)
        {

            await _contextoGeral.InfoSinalizacao.AddAsync(infoSinalizacao);
            await _contextoGeral.SaveChangesAsync();

            return await this.ObterPorId(infoSinalizacao.Rod_id);
        }


        public async Task InserirFotos(SinalizacaoFotosItens[] sinalizacaoFotosItens)
        {
            await _contextoGeral.SinalizacaoFotosItens.AddRangeAsync(sinalizacaoFotosItens);
            await _contextoGeral.SaveChangesAsync();
        }

        public async Task<InfoSinalizacao> ObterPorId(int? Rod_id)
        {
            var retornoUnico = await _contextoGeral.InfoSinalizacao
                .Include(n => n.Sentido)
                .Include(n => n.Posicao)
                .Include(n => n.Localizacao)
                .Include(n => n.EstadoConservacao)
                .Include(n => n.AtendimentoEspecificacoes)
                .Include(n => n.TipoPista)
                .Include(n => n.TipoRegional)
                .Include(n => n.Sinalizacao)
                .AsNoTracking().FirstOrDefaultAsync(n => n.Rod_id == Rod_id);

            retornoUnico.SinalizacaoFotosItens = await this._contextoGeral.SinalizacaoFotosItens.Where(n => n.Rod_Id == retornoUnico.Rod_id).ToListAsync();

            return retornoUnico;
        }

        public async Task<IEnumerable<InfoSinalizacao>> ObterTodos()
        {
            var listaInfoSinalizacao =  await _contextoGeral.InfoSinalizacao
                .Include(n => n.Sentido)
                .Include(n => n.Posicao)
                .Include(n => n.Localizacao)
                .Include(n => n.EstadoConservacao)
                .Include(n => n.AtendimentoEspecificacoes)
                .Include(n => n.TipoPista)
                .Include(n => n.TipoRegional)
                .Include(n => n.Sinalizacao)
                .AsNoTracking().ToListAsync();

            foreach (var item in listaInfoSinalizacao) item.SinalizacaoFotosItens = await this._contextoGeral.SinalizacaoFotosItens.Where(n => n.Rod_Id == item.Rod_id).ToListAsync();

            return listaInfoSinalizacao;
        }

        public async Task<IEnumerable<InfoSinalizacao>> ObterPorFiltro(int Rod_Tipo, int Rod_TipoPista, string Rod_Codigo)
        {
            var query = _contextoGeral.InfoSinalizacao
                 .Include(n => n.Sentido)
                 .Include(n => n.Posicao)
                 .Include(n => n.Localizacao)
                 .Include(n => n.EstadoConservacao)
                 .Include(n => n.AtendimentoEspecificacoes)
                 .Include(n => n.TipoPista)
                 .Include(n => n.TipoRegional)
                 .Include(n => n.Sinalizacao)
                 .AsNoTracking();

            if (Rod_Tipo > 0) query = query.Where(n => n.Rod_Tipo == Rod_Tipo);

            if (Rod_TipoPista > 0) query = query.Where(n => n.Rod_TipoPista == Rod_TipoPista);

            if (!string.IsNullOrEmpty(Rod_Codigo)) query = query.Where(n => n.Rod_Codigo.Contains(Rod_Codigo));

            var listaInfoSinalizacao = await query.ToListAsync();

            foreach (var item in listaInfoSinalizacao) item.SinalizacaoFotosItens = await this._contextoGeral.SinalizacaoFotosItens.Where(n => n.Rod_Id == item.Rod_id).ToListAsync();

            return listaInfoSinalizacao;
        }
    }
}
