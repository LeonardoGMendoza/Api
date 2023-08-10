using Microsoft.EntityFrameworkCore;
using Placas.Contexto;
using Placas.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Placas.Servicos
{
    public class PosicaoServico
    {
        private readonly ContextoGeral _contextoGeral;
        public PosicaoServico(ContextoGeral contextoGeral)
        {
            _contextoGeral = contextoGeral;
        }

        public async Task<IEnumerable<Posicao>> ObterTodos() => await _contextoGeral.Posicao.AsNoTracking().ToListAsync();
    }
}
