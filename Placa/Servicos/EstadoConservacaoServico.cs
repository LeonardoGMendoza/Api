using Microsoft.EntityFrameworkCore;
using Placas.Contexto;
using Placas.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Placas.Servicos
{
    public class EstadoConservacaoServico
    {
        private readonly ContextoGeral _contextoGeral;
        public EstadoConservacaoServico(ContextoGeral contextoGeral)
        {
            _contextoGeral = contextoGeral;
        }
        public async Task<IEnumerable<EstadoConservacao>> ObterTodos() => await _contextoGeral.EstadoConservacao.AsNoTracking().ToListAsync();
    }
}
