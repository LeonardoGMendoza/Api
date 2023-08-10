using Microsoft.EntityFrameworkCore;
using Placas.Contexto;
using Placas.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Placas.Servicos
{
    public class TipoPistaServico
    {
        private readonly ContextoGeral _contextoGeral;
        public TipoPistaServico(ContextoGeral contextoGeral)
        {
            _contextoGeral = contextoGeral;
        }

        public async Task<IEnumerable<TipoPista>> ObterTodos() => await _contextoGeral.TipoPista.AsNoTracking().ToListAsync();
    }
}
