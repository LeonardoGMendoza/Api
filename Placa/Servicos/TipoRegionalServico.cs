using Microsoft.EntityFrameworkCore;
using Placas.Contexto;
using Placas.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Placas.Servicos
{
    public class TipoRegionalServico
    {
        private readonly ContextoGeral _contextoGeral;
        public TipoRegionalServico(ContextoGeral contextoGeral)
        {
            _contextoGeral = contextoGeral;
        }

        public async Task<IEnumerable<TipoRegional>> ObterTodos() => await _contextoGeral.TipoRegional.AsNoTracking().ToListAsync();
       
    }
}
