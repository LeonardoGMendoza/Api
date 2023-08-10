using APIEstudo.Entidades;
using APIEstudo.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APIEstudo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {

        private readonly ContextoGeral _servico;
        public PessoasController(ContextoGeral servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_servico.ObterTodos());
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public IActionResult Get(Guid Id)
        {
            return Ok(_servico.ObterPorId(Id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            _servico.Inserir(pessoa);

            return Ok(new { mensagem = "Inserção Feita Com Sucesso" });
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public IActionResult Put([FromBody] Pessoa pessoa, Guid Id)
        {
            _servico.Alterar(pessoa,Id);

            return Ok(new { mensagem = "Alteração Feita Com Sucesso" });
        }


        [HttpDelete]
        [Route("{Id:Guid}")]
        public IActionResult Delete(Guid Id)
        {
            _servico.Deletar(Id);

            return Ok(new { mensagem = "Exclusão Feita Com Sucesso" });
        }
    }
}
