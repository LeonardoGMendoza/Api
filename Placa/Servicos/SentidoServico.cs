using Microsoft.EntityFrameworkCore;
using Placas.Contexto;
using Placas.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Placas.Servicos
{
    public class SentidoServico
    {
        private readonly ContextoGeral _contextoGeral;
        public SentidoServico(ContextoGeral contextoGeral)
        {
            _contextoGeral = contextoGeral;
        }

        public async Task<IEnumerable<Sentido>> ObterTodos() => await _contextoGeral.Sentido.AsNoTracking().ToListAsync();
    }
}
