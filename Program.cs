using System;

namespace DIO.Games
{
    class Program
    {
        static GamesRepositorio repositorio = new GamesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarGames();
                        break;
                    case "2":
                        InserirGame();
                        break;
                    case "3":
                        AtualizarGame();
                        break;
                    case "4":
                        ExcluirGame();
                        break;
                    case "5":
                        VisualizarGame();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                    
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar os nossos serviços.");
            Console.ReadLine();
        }

    

    private static void ListarGames()
    {
        Console.WriteLine("Listar Games");

        var lista = repositorio.Lista();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum game cadastrado.");
            return;
        }

        foreach (var games in lista)
        {
                var excluido = games.retornaExcluido();
            Console.WriteLine("#ID {0}: - {1} {2}", games.retornaId(), games.retornaTitulo(), (excluido ? "*Excluido*" : ""));
        }
    }

    private static void InserirGame()
    {
        Console.WriteLine("Inserir novo Game");

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} = {1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título do Game: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Lançamento do Game: ");
        int entradaAno = int.Parse(Console.ReadLine());
        
        Console.Write("Digite a Descrição do Game: ");
        string entradaDescricao = Console.ReadLine();

        Games novoGame = new Games(id: repositorio.ProximoId(),
                                   genero: (Genero)entradaGenero,
                                   titulo: entradaTitulo,
                                   ano: entradaAno,
                                   descricao: entradaDescricao);

        repositorio.Insere(novoGame);

        Console.Write("Novo game cadastrado!");
    }

    private static void AtualizarGame()
	{
        Console.Write("Digite o id do game: ");
        int indiceGame = int.Parse(Console.ReadLine());

        foreach(int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o título do game: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Lançamento do Game: ");
        int entradaAno = int.Parse(Console.ReadLine());
        
        Console.Write("Digite a Descrição do Game: ");
        string entradaDescricao = Console.ReadLine();

        Games atualizaGame = new Games(id: indiceGame,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorio.Atualiza(indiceGame, atualizaGame);
        }
    
    private static void ExcluirGame()
    {
        Console.Write("Digite o id do game: ");
		int indiceGame = int.Parse(Console.ReadLine());

		repositorio.Exclui(indiceGame);
        
    }

    private static void VisualizarGame()
    {
        Console.Write("Digite o id do game: ");
        int indiceGame = int.Parse(Console.ReadLine());

        var game = repositorio.RetornaPorId(indiceGame);

        Console.WriteLine(game);
    }
    

    private static string ObterOpcaoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("DIO Games, trazendo as novidades no mundo dos Games!");
        Console.WriteLine("Informe a opção desejada:");

        Console.WriteLine("1- Listar games");
        Console.WriteLine("2- Inserir novo game");
        Console.WriteLine("3- Atualizar game");
        Console.WriteLine("4- Excluir game");
        Console.WriteLine("5- Visualizar game");
        Console.WriteLine("C- Limpar Tela");
        Console.WriteLine("X- Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
    }
  }
}