using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorioSeries = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoEscolhida = ObterOpcaoUsuario();

			while (opcaoEscolhida.ToUpper() != "X")
			{
				switch (opcaoEscolhida)
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
					case "L":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}
                opcaoEscolhida = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado!!");
			Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("SeriesFlix");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("L- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoEscolhida = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoEscolhida;
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorioSeries.ExcluiPeloID(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorioSeries.RetornaPeloID(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero da Série dentre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioSeries.Atualiza(indiceSerie, atualizaSerie);
		}

        private static void ListarSeries()
		{
			Console.WriteLine("Lista das séries");

			var lista = repositorioSeries.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada :(");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaParametroExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserindo nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero da Série dentre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorioSeries.ProximoID(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioSeries.Insere(novaSerie);
		}
    }
}
