using GameMania.Menus;
using GameMania.Modelos;

Dictionary<string, Jogo> listaJogos = new(){
    ["FarCry"] = new Jogo("FarCry", "Acao/Aventura", "Ubisoft", "3", "3edicao", true, "AllPlatform", notas: new List<float> { 9, 8, 8 }),
    ["GTA"] = new Jogo("GTA", "Acao/Aventura", "RockStar", "5", "5edicao", true, "AllPlatform", notas: new List<float> { 9, 8, 9 }),
    ["Skyrim"] = new Jogo("Skyrim", "RPG", "Bethesda", "5", "5edicao", false, "AllPlatform", notas: new List<float> { 10, 10, 10 }),
    ["Valorant"] = new Jogo("Valorant", "FPS", "Riot", "1", "1edicao", false, "AllPlatform", notas: new List<float> { 0, 0, 0 })
};

Dictionary<string, Menu> listaOpcoes = new(){
    ["-1"] = new MenuExibirJogosCadastrados(),
    ["1"] = new MenuCadastrarNovoJogo(),
    ["2"] = new MenuExibirJogosCadastrados(),
    ["3"] = new MenuExibirDetalhesDoJogo(),
    ["4"] = new MenuAvaliarJogoCadastrado()
};

void TextoMenu(){
    Console.Clear();
    Console.WriteLine(@"
░██████╗░░█████╗░███╗░░░███╗███████╗███╗░░░███╗░█████╗░███╗░░██╗██╗░█████╗░
██╔════╝░██╔══██╗████╗░████║██╔════╝████╗░████║██╔══██╗████╗░██║██║██╔══██╗
██║░░██╗░███████║██╔████╔██║█████╗░░██╔████╔██║███████║██╔██╗██║██║███████║
██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░██║╚██╔╝██║██╔══██║██║╚████║██║██╔══██║
╚██████╔╝██║░░██║██║░╚═╝░██║███████╗██║░╚═╝░██║██║░░██║██║░╚███║██║██║░░██║
░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░╚═╝");
    Console.WriteLine("-1 - Sair");
    Console.WriteLine(" 1 - Cadastrar Novo Jogo");
    Console.WriteLine(" 2 - Exibir Jogos Cadastrados ");
    Console.WriteLine(" 3 - Mostrar Detalhes Dos Jogos");
    Console.WriteLine(" 4 - Avaliar Jogo");
}
void MenuPrincipal(){
    string? aux = "";
    TextoMenu();
    while(aux != "-1"){
        TextoMenu();
        aux = Console.ReadLine();
        aux = string.IsNullOrEmpty(aux)?"":aux;
        if(listaOpcoes.ContainsKey(aux) && aux!="-1"){
            listaOpcoes[aux].ExecutarMenu(listaJogos);
        }
    }    
}

MenuPrincipal();
