using APIEstudo.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace APIEstudo.Servicos
{
    public class ContextoGeral
    {
        private readonly List<Pessoa> Pessoas;
        private readonly string CaminhoArquivo;
        public ContextoGeral() {
            this.CaminhoArquivo = @"D:\Projetos\Peruano\API\APIEstudo\APIEstudo\DB\Pessoas.csv";
            this.Pessoas = CarregarAquivo().ToList();
        }
        private IEnumerable<Pessoa> CarregarAquivo()
        {
            var linhas = File.ReadLines(this.CaminhoArquivo);
            
            foreach (var pessoa in linhas) yield return pessoa;
        }

        public List<Pessoa> ObterTodos() => this.Pessoas;

        public Pessoa ObterPorId(Guid Id) => this.Pessoas.FirstOrDefault(x => x.Id == Id);

        public void Inserir(Pessoa pessoa)
        {
            this.Pessoas.Add(pessoa);
            this.SalvarArquivo();
        }

        public void Alterar(Pessoa pessoa, Guid Id)
        {
            var pessoaAtual = this.ObterPorId(Id);
          
            this.Pessoas.Remove(pessoaAtual);

            pessoaAtual.Nome = pessoa.Nome ?? pessoaAtual.Nome;
            pessoaAtual.Email = pessoa.Email ?? pessoaAtual.Email;
            pessoaAtual.Nascimento = pessoa.Nascimento == DateTime.MinValue ? pessoaAtual.Nascimento : pessoa.Nascimento;

            this.Pessoas.Add(pessoaAtual);

            this.SalvarArquivo();
        }

        public void Deletar(Guid Id)
        {
            var pessoaAtual = this.ObterPorId(Id);
            this.Pessoas.Remove(pessoaAtual);

            this.SalvarArquivo();
        }

        private void SalvarArquivo()
        {
            List<string> listaRegistro = new();

            foreach(var pessoa in this.Pessoas) listaRegistro.Add(pessoa);

            File.WriteAllLines(CaminhoArquivo, listaRegistro);
        }
    }
}
