using GameMania.Menus;

var opcoes = new Dictionary<string, Menu> {
    ["1"] = new CadastrarNovoJogo(),
    ["2"] = new ExibirJogosCadastrados(),
    ["3"] = new ExibirDetalhesDoJogo(),
    ["4"] = new AvaliarJogosCadastrados(),
    ["0"] = new Sair()
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
    Console.WriteLine("\nBEM VINDO(A)!\nSelecione uma das opções abaixo:\n");
}

void MenuPrincipal() {
    while (true) {
        ExibirMensagemBoasVindas();
        Console.WriteLine("1. Cadastrar novo Jogo");
        Console.WriteLine("2. Exibir jogos cadastrados ");
        Console.WriteLine("3. Mostrar detalhes dos jogos");
        Console.WriteLine("4. Avaliar jogo");
        Console.WriteLine("0. Sair");
        string? opcao = Console.ReadLine()?.Trim();

        if (!string.IsNullOrEmpty(opcao)) {
            if (opcoes.ContainsKey(opcao)) {
                bool sair = opcoes[opcao].Executar();

                if (sair) {
                    break;
                }
            } else {
                Console.Write("\nOpção Inválida!\nSelecione uma das opções válidas. (itens 0 -> 4).\nPressione qualquer tecla para continuar.");
                Console.ReadKey();
                Console.Clear();
            }
        } else {
            Console.Write("\nOpção tem que ser preenchida.\nSelecione uma das opções válidas. (itens 0 -> 4).\nPressione qualquer tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

MenuPrincipal();