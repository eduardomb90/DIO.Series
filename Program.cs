﻿using System;
using DIO.Series.Enums;
using DIO.Series.Factory;

namespace DIO.Series
{
    static class Program
    {
        static IRepositorio<Serie> repositorio = RepositorioFactory.Repositorio<Serie>();
        
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			Console.WriteLine($"Tem certeza que deseja excluir a série {repositorio.RetornaPorId(indiceSerie)} ?");
            Console.WriteLine(" Digite 'S' para Sim");
            Console.WriteLine(" Digite 'N' para Não");
            var resposta = Console.ReadLine().ToUpper();

            switch (resposta)
            {
                case "S":
                    repositorio.Exclui(indiceSerie);
                    break;
                case "N":
                default:
                    break;
            }
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
			}
			var isNumber = int.TryParse(Console.ReadLine(), out int resultado);
            
            while(!isNumber){
                Console.Write("Digite o gênero entre as opções acima: ");
                isNumber = int.TryParse(Console.ReadLine(), out resultado);
            }
            int entradaGenero = resultado;

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			 isNumber = int.TryParse(Console.ReadLine(), out resultado);
            
            while(!isNumber){
                Console.Write("Digite o Ano de Início da Série: ");
                isNumber = int.TryParse(Console.ReadLine(), out resultado);
            }
            int entradaAno = resultado;

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.RetornaExcluido();
                
				Console.WriteLine($"#ID {serie.RetornaId()}: \n {serie} \n{(excluido ? "*Excluído*" : "")}");
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
            var isNumber = int.TryParse(Console.ReadLine(), out int resultado);
            
            while(!isNumber){
                Console.Write("Digite o gênero entre as opções acima: ");
                isNumber = int.TryParse(Console.ReadLine(), out resultado);
            }
            int entradaGenero = resultado;            

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
            isNumber = int.TryParse(Console.ReadLine(), out resultado);
            
            while(!isNumber){
                Console.Write("Digite o Ano de Início da Série: ");
                isNumber = int.TryParse(Console.ReadLine(), out resultado);
            }
            int entradaAno = resultado;


			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

    }
}
