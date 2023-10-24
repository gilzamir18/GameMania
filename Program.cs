using GameMania.Menus;

Dictionary<string, Menu> opcoes = new Dictionary<string, Menu>();
opcoes["-1"] = new MenuSair();
opcoes["1"] = new MenuCadastrarNovoJogo();
opcoes["2"] = new MenuExibirJogoCadastrado();
opcoes["3"] = new MenuExibirDetalhesDoJogo();
opcoes["4"] = new MenuAvaliarJogosCadastrados();

void ExibirMensagemBoasVindas(){
    Console.Clear();
    Console.WriteLine(@"
 ██████   █████  ███    ███ ███████ ███    ███  █████  ███   ██ ██  █████ 
██       ██   ██ ████  ████ ██      ████  ████ ██   ██ ████  ██ ██ ██   ██
██   ███ ███████ ██ ████ ██ █████   ██ ████ ██ ███████ ██ ██ ██ ██ ███████
██    ██ ██   ██ ██  ██  ██ ██      ██  ██  ██ ██   ██ ██  ████ ██ ██   ██
 ██████  ██   ██ ██      ██ ███████ ██      ██ ██   ██ ██   ███ ██ ██   ██");
}


void MenuPrincipal(){
    string? opcao = "0";
    while (opcao != "-1"){
        ExibirMensagemBoasVindas();
        Console.WriteLine("-1 - Sair");
        Console.WriteLine(" 1 - Cadastrar Novo Jogo");
        Console.WriteLine(" 2 - Listar Jogos Cadastrados ");
        Console.WriteLine(" 3 - Mostrar Detalhe de Jogo");
        Console.WriteLine(" 4 - Avaliar Jogo Disponivel");
        opcao = Console.ReadLine();
        opcao = string.IsNullOrEmpty(opcao)? "":opcao;
        if (opcoes.ContainsKey(opcao)){   
            opcoes[opcao].Executar();
        }else{
            Console.WriteLine("Opcao Invalida (Pressione qualquer tecla para continuar)");
            Console.ReadKey();
        }
    }
}

MenuPrincipal();
