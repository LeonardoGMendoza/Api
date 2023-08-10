using Microsoft.EntityFrameworkCore;
using Placas.Contexto;
using Placas.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Placas.Servicos
{
    public class AtendimentoEspecificacoesServico
    {
        private readonly ContextoGeral _contextoGeral;
        public AtendimentoEspecificacoesServico(ContextoGeral contextoGeral)
        {
            _contextoGeral = contextoGeral;
        }
        public async Task<IEnumerable<AtendimentoEspecificacoes>> ObterTodos() => await _contextoGeral.AtendimentoEspecificacoes.AsNoTracking().ToListAsync();
    }
}
