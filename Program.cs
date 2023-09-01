using GameMania.Menus;
using GameMania.Modelos;

Dictionary< string, Jogo > jogosRegistrados = new();
jogosRegistrados["Forza"] = new Jogo("Forza", "Corrida", "XBox Game Studios", "5");
jogosRegistrados["Forza"].AdicionarNota(new Avaliacao(10));
jogosRegistrados["Forza"].AdicionarNota(new Avaliacao(5));
jogosRegistrados["Forza"].AdicionarNota(new Avaliacao(2));
jogosRegistrados["Forza"].AdicionarPlataforma("XBox360");

//List<string> jogos = new() {"GTA", "Valorant", "CounterStrike", "NeedForSpeed"} ;
/*
Dictionary< string, List<int> > jogosRegistrados = new();
jogosRegistrados["Forza"] = new List<int>(){10, 7, 8};
jogosRegistrados["Valorant"] = new List<int>(){10, 5, 7}; 
jogosRegistrados["FarCry"] = new List<int>{10, 10, 10};


Dictionary<string, Menu> opcoes = new Dictionary<string, Menu>();
opcoes["1"] = new MenuCadastrarNovoJogo();
opcoes["2"] = new MenuExibirJogosCadastrados();
opcoes["3"] = new MenuExibirDetalhesDoJogo();
opcoes["4"] = new MenuAvaliarJogosCadastrados();
opcoes["0"] = new MenuSair();

void ExibirMensagemBoasVindas() {
    Console.Clear();
    Console.WriteLine(@"
░██████╗░░█████╗░███╗░░░███╗███████╗███╗░░░███╗░█████╗░███╗░░██╗██╗░█████╗░
██╔════╝░██╔══██╗████╗░████║██╔════╝████╗░████║██╔══██╗████╗░██║██║██╔══██╗
██║░░██╗░███████║██╔████╔██║█████╗░░██╔████╔██║███████║██╔██╗██║██║███████║
██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░██║╚██╔╝██║██╔══██║██║╚████║██║██╔══██║
╚██████╔╝██║░░██║██║░╚═╝░██║███████╗██║░╚═╝░██║██║░░██║██║░╚███║██║██║░░██║
░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░╚═╝");
    Console.WriteLine("Seja bem-vindo ao GAMEMANIA!");
}


void MenuPrincipal() {

    while (true) {
        ExibirMensagemBoasVindas();
        Console.WriteLine("1 - Cadastrar novo Jogo");
        Console.WriteLine("2 - Exibir jogos cadastrados ");
        Console.WriteLine("3 - Exibir detalhes dos jogos");
        Console.WriteLine("4 - Avaliar jogo");
        Console.WriteLine("0 - Sair");
        string opcao = Console.ReadLine();

        if (opcoes.ContainsKey(opcao)) {   
            bool sair = opcoes[opcao].Executar(jogosRegistrados);

            if (sair)
                break;
                
        } else {
            Console.WriteLine("Opcao Inválida!. Tente novamente. Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

MenuPrincipal();