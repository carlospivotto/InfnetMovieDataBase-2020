using Dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace InfnetMovieDataBase_2020
{
    class Program
    {
        static List<Filme> filmes = new List<Filme>(); // Lista global de filmes. 

        static void Main(string[] args)
        {
            Povoar();
            IEnumerable<Filme> resultados;
            while (true)
            {
                Console.WriteLine("(1) Cadastrar filme");
                Console.WriteLine("(2) Buscar filme");
                Console.WriteLine("(3) Buscar filmografia");
                Console.Write("Selecione a opção desejada: ");
                var opcao = Int32.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarFilme();
                        break;
                    case 2:
                        Console.WriteLine("Informe o título de um filme:");
                        var titulo = Console.ReadLine();
                        resultados = BuscarFilme(titulo);
                        foreach (var filme in resultados)
                        {
                            // Imprimir os dados do filme: 
                            Console.WriteLine($"Título: {filme.Titulo}");
                            Console.WriteLine($"Título Original: {filme.TituloOriginal}");
                            Console.WriteLine("Elenco:");
                            foreach (var pessoa in filme.Elenco)
                            {
                                Console.WriteLine($"\t— {pessoa.Nome} {pessoa.Sobrenome}");
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Informe o nome de um(a) ator/atriz:");
                        var nome = Console.ReadLine();
                        Console.WriteLine("Informe o sobrenome de um(a) ator/atriz:");
                        var sobrenome = Console.ReadLine();
                        Pessoa p = new Pessoa(nome, sobrenome);
                        resultados = BuscarFilmografia(p);
                        ImprimirResultados(resultados);
                        break;
                }
            }

        }

        private static void ImprimirResultados(IEnumerable<Filme> resultados)
        {
            foreach (var filme in resultados)
            {
                // Imprimir os dados do filme: 
                Console.WriteLine($"Título: {filme.Titulo}");
                Console.WriteLine($"Título Original: {filme.TituloOriginal}");
                Console.WriteLine("Elenco:");
                foreach (var pessoa in filme.Elenco)
                {
                    Console.WriteLine($"\t— {pessoa.Nome} {pessoa.Sobrenome}");
                }
            }
        }

        private static IEnumerable<Filme> BuscarFilmografia(Pessoa p)
        {
            var resultado = from filme in filmes
                            from pessoa in filme.Elenco
                            where pessoa.Nome == p.Nome && pessoa.Sobrenome == p.Sobrenome
                            select filme;

            return resultado;
        }


        private static IEnumerable<Filme> BuscarFilme(string titulo)
        {
            var resultado = from filme in filmes
                            where filme.Titulo == titulo
                            select filme;

            return resultado;
        }

        private static void Povoar()
        {
            Filme f1 = new Filme("Os Vingadores", "The Avengers") { AnoLancamento = 2012, Sinopse = "Vingadores dão um pau no Loki." };
            f1.Elenco.Add(new Pessoa("Robert", "Downey Jr."));
            f1.Elenco.Add(new Pessoa("Chris", "Evans"));
            f1.Elenco.Add(new Pessoa("Mark", "Ruffalo"));
            f1.Elenco.Add(new Pessoa("Scarlett", "Johansson"));
            f1.Elenco.Add(new Pessoa("Chris", "Hemsworth"));
            f1.Elenco.Add(new Pessoa("Jeremy", "Renner"));
            filmes.Add(f1);

            Filme f2 = new Filme("Homem de Ferro 2", "Iron Man 2") { AnoLancamento = 2009, Sinopse = "Homem de Ferro contra o grandão de chicote." };
            f2.Elenco.Add(new Pessoa("Robert", "Downey Jr."));
            f2.Elenco.Add(new Pessoa("Scarlett", "Johansson"));
            filmes.Add(f2);

            Filme f3 = new Filme("Capitão América 2: Soldado Invernal", "Captain America 2: Winter Soldier") { AnoLancamento = 2010 };
            f3.Elenco.Add(new Pessoa("Chris", "Evans"));
            f3.Elenco.Add(new Pessoa("Scarlett", "Johansson"));
            filmes.Add(f3);
        }

        static void CadastrarFilme()
        {
            //1. Informar ao usuário que ele deve informar o título do filme.
            Console.Write("Informe o título do filme: ");
            //2. Fornecer o campo de input do nome do filme ao usuário.
            var titulo = Console.ReadLine();
            Console.Write("Informe o título original do filme: ");
            var tituloOriginal = Console.ReadLine();
            Console.Write("Informe a data de lançamento do filme: ");
            var data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", new CultureInfo("pt-BR"));
            //Console.Write("Informe o ano de lançamento do filme: ");
            //var ano = Int32.Parse(Console.ReadLine()); // Int32.Parse para já converter a string de entrada em um int.
            var ano = data.Year;
            // Repetir os passos 1 e 2 para outros campos simples (título original, ano lançamento)
            // Instanciar um objeto do tipo filme e atribuir os inputs do usuário ao objeto.
            Filme filme = new Filme(titulo, tituloOriginal)
            {
                AnoLancamento = ano,
                DataLancamento = data
            };

            // Cadastrar o elenco do filme:
            while (true)
            {
                filme.Elenco.Add(CadastrarIntegranteElenco());
                Console.WriteLine("Digite 'N' para encerrar o cadastro; Enter ou outra tecla para cadastrar outro(a) ator/atriz: ");
                var opcao = Console.ReadLine();
                if (opcao.ToLower() == "n".ToLower())
                {
                    break;
                }
            }

            // Adicionar este filme à lista de filmes global. 
            filmes.Add(filme);
        }

        static Pessoa CadastrarIntegranteElenco()
        {
            var nome = "";
            var sobrenome = "";

            while (nome == "" || sobrenome == "")
            {
                Console.WriteLine("Informe o nome do(a) ator/atriz: ");
                nome = Console.ReadLine();
                Console.WriteLine("Informe o sobrenome do(a) ator/atriz: ");
                sobrenome = Console.ReadLine();
                if (nome == "" || sobrenome == "")
                {
                    Console.WriteLine("Dados inválidos.");
                }
            }

            Pessoa p = new Pessoa(nome, sobrenome);
            return p;
        }
    }
}
