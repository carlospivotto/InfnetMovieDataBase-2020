using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Pessoa
    {
        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Funcoes = new List<Funcao>();
            Filmografia = new List<Filme>();
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Biografia { get; set; }
        public List<Funcao> Funcoes { get; set; }
        public List<Filme> Filmografia { get; set; }
    }
}