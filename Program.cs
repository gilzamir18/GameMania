using GameMania.Menus;

Dictionary<string, Menu> opcoes = new Dictionary<string, Menu>(){
    {"0", new MenuSair()},
    {"1", new MenuCadastrarNovoJogo()},
    {"2", new MenuExibirJogosCadastrados()},
    {"3", new MenuExibirDetalheDoJogo()},
    {"4", new MenuAvaliarJogosCadastrados()}
};

void ExibirMensagemBoasVindas(){
    Console.Clear();
    Console.WriteLine(@"
 █████   ████  ██      ██ █████ ██      ██  ████  ██    ██ ██  ████ 
██      ██  ██ ███    ███ ██    ███    ███ ██  ██ ███   ██ ██ ██  ██
██  ███ ██████ ██ █  █ ██ ████  ██ █  █ ██ ██████ ██ ██ ██ ██ ██████
██   ██ ██  ██ ██  ██  ██ ██    ██  ██  ██ ██  ██ ██   ███ ██ ██  ██
 █████  ██  ██ ██      ██ █████ ██      ██ ██  ██ ██    ██ ██ ██  ██");
}

void MenuPrincipal(){
    string? opcao = "";
    while (opcao != "0"){
        ExibirMensagemBoasVindas();
        Console.WriteLine("0 - Sair");
        Console.WriteLine("1 - Cadastrar Novo Jogo");
        Console.WriteLine("2 - Listar Jogos Cadastrados ");
        Console.WriteLine("3 - Mostrar Detalhe de Jogo");
        Console.WriteLine("4 - Avaliar Jogo Disponivel");
        Console.Write(" Comando: ");
        opcao = Console.ReadLine();
        opcao = string.IsNullOrEmpty(opcao)? "":opcao;//Warning
        if (opcoes.ContainsKey(opcao)){   
            opcoes[opcao].Executar();
        }else{
            Console.Write("Opcao Invalida (Pressione qualquer tecla para continuar)");
            Console.ReadKey();
        }
    }
}
MenuPrincipal();
