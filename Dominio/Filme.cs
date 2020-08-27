using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Filme
    {
        public Filme(string titulo, string tituloOriginal)
        {
            Titulo = titulo;
            TituloOriginal = tituloOriginal;
            Generos = new List<Genero>();
            Diretores = new List<Pessoa>();
            Roteiristas = new List<Pessoa>();
            Elenco = new List<Pessoa>();
        }

        public string Titulo { get; set; }
        public string TituloOriginal { get; set; }
        public int AnoLancamento { get; set; }
        public string ClassificacaoEtaria { get; set; }
        public List<Genero> Generos { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Sinopse { get; set; }
        public List<Pessoa> Diretores { get; set; }
        public List<Pessoa> Roteiristas { get; set; }
        public List<Pessoa> Elenco { get; set; }
    }
}
