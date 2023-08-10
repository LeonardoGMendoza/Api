using System;

namespace APIEstudo.Entidades
{
    public class Pessoa
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime Nascimento { get; set; }

        public static implicit operator Pessoa(string linha) => new () { 
            
            Id = Guid.Parse(linha.Split(';')[0]),
            Nome = linha.Split(';')[1],
            Email = linha.Split(';')[2],
            Nascimento = DateTime.Parse(linha.Split(';')[3])

        };

        public static implicit operator string(Pessoa pessoa) 
            => $"{pessoa.Id};{pessoa.Nome};{pessoa.Email};{pessoa.Nascimento}";
    }
}
