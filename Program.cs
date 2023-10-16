using GameMania.Menus;

Dictionary<string, Menu> listaOpcoes = new(){
    ["-1"] = new MenuExibirJogosCadastrados(),
    ["1"] = new MenuCadastrarNovoJogo(),
    ["2"] = new MenuExibirJogosCadastrados(),
    ["3"] = new MenuExibirDetalhesDoJogo(),
    ["4"] = new MenuAvaliarJogoCadastrado(),
    ["5"] = new MenuPreencherDadosComGPT()
};

void TextoMenu(){
    Console.Clear();
    Console.WriteLine(@"
 ██████╗  █████╗ ███╗   ███╗███████╗███╗   ███╗ █████╗ ███╗  ██╗██╗ █████╗ 
██╔════╝ ██╔══██╗████╗ ████║██╔════╝████╗ ████║██╔══██╗████╗ ██║██║██╔══██╗
██║  ██╗ ███████║██╔████╔██║█████╗  ██╔████╔██║███████║██╔██╗██║██║███████║
██║  ╚██╗██╔══██║██║╚██╔╝██║██╔══╝  ██║╚██╔╝██║██╔══██║██║╚████║██║██╔══██║
╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗██║ ╚═╝ ██║██║  ██║██║ ╚███║██║██║  ██║
 ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚══╝╚═╝╚═╝  ╚═╝");
    Console.WriteLine("-1 - Sair");
    Console.WriteLine(" 1 - Cadastrar Novo Jogo");
    Console.WriteLine(" 2 - Exibir Jogos Cadastrados ");
    Console.WriteLine(" 3 - Mostrar Detalhes Dos Jogos");
    Console.WriteLine(" 4 - Avaliar Jogo");
    Console.WriteLine(" 5 - Preencher Dados Com GPT");
    
}
void MenuPrincipal(){
    string? aux = "";
    while(aux != "-1"){
        TextoMenu();
        aux = Console.ReadLine();
        aux = string.IsNullOrEmpty(aux)?"":aux;
        if(listaOpcoes.ContainsKey(aux) && aux!="-1"){
            listaOpcoes[aux].ExecutarMenu();
            
        }
    }    
}

MenuPrincipal();