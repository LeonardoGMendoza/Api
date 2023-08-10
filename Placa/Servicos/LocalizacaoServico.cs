using Microsoft.EntityFrameworkCore;
using Placas.Contexto;
using Placas.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Placas.Servicos
{
    public class LocalizacaoServico
    {
        private readonly ContextoGeral _contextoGeral;
        public LocalizacaoServico(ContextoGeral contextoGeral)
        {
            _contextoGeral = contextoGeral;
        }

        public async Task<IEnumerable<Localizacao>> ObterTodos() => await _contextoGeral.Localizacao.AsNoTracking().ToListAsync();

    }
}
