using Microsoft.EntityFrameworkCore;
using Placas.Contexto;
using Placas.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Placas.Servicos
{
    public class SinalizacaoServico
    {
        private readonly ContextoGeral _contextoGeral;
        public SinalizacaoServico(ContextoGeral contextoGeral)
        {
            _contextoGeral = contextoGeral;
        }

        public async Task<IEnumerable<Sinalizacao>> ObterTodos() => await _contextoGeral.Sinalizacao.AsNoTracking().ToListAsync();
    }
}
