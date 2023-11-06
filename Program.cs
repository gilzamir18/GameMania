using GameMania.Menus;

var opcoes = new Dictionary<string, Menu> {
    ["1"] = new CadastrarNovoJogo(),
    ["2"] = new ExibirJogosCadastrados(),
    ["3"] = new ExibirDetalhesDoJogo(),
    ["4"] = new AvaliarJogoCadastrado(),
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
    Console.WriteLine("BEM VINDO(A)!\nSelecione uma das opções abaixo:\n");
}

void MenuPrincipal() {
    while (true) {
        ExibirMensagemBoasVindas();
        Console.WriteLine("1 - Cadastrar novo jogo.");
        Console.WriteLine("2 - Exibir jogos cadastrados.");
        Console.WriteLine("3 - Exibir detalhes do jogo.");
        Console.WriteLine("4 - Avaliar jogo.");
        Console.WriteLine("0 - Sair.");
        string? opcao = Console.ReadLine()?.Trim();

        if (!string.IsNullOrEmpty(opcao)) {
            if (opcoes.ContainsKey(opcao)) {
                bool sair = opcoes[opcao].Executar();

                if (sair) {
                    break;
                }
            } else {
                Console.Write($"Opção Inválida!\nSelecione uma das opções válidas. (itens 0 -> {opcoes.Count - 1}).\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        } else {
            Console.Write($"Opção deve ser preenchida!\nSelecione uma das opções válidas. (itens 0 -> {opcoes.Count - 1}).\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

MenuPrincipal();