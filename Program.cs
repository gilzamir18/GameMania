using GameMania.Menus;
using GameMania.Modelos;

var opcoes = new Dictionary<string, Menu> {
    ["1"] = new MenuCadastrarNovoJogo(),
    ["2"] = new MenuCadastrarNovoJogoGPT(),
    ["3"] = new MenuExibirJogosCadastrados(),
    ["4"] = new MenuExibirDetalhesDoJogo(),
    ["5"] = new MenuAvaliarJogosCadastrados(),
    ["0"] = new MenuSair()
};

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
        Console.WriteLine("1 - Cadastrar novo Jogo Manualmente");
        Console.WriteLine("2 - Cadastrar novo Jogo com GPT");
        Console.WriteLine("3 - Exibir jogos cadastrados ");
        Console.WriteLine("4 - Exibir detalhes dos jogos");
        Console.WriteLine("5 - Avaliar jogo");
        Console.WriteLine("0 - Sair");
        string opcao = Console.ReadLine();

        if (opcoes.ContainsKey(opcao)) {   
            bool sair = opcoes[opcao].Executar();

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