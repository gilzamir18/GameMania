List<string> jogos = new() {"GTA", "Valorant", "CounterStrike", "NeedForSpeed"} ;


void ExibirMensagemBoasVindas()
{
    Console.WriteLine("**************************************************");
    Console.WriteLine(@"
░██████╗░░█████╗░███╗░░░███╗███████╗███╗░░░███╗░█████╗░███╗░░██╗██╗░█████╗░
██╔════╝░██╔══██╗████╗░████║██╔════╝████╗░████║██╔══██╗████╗░██║██║██╔══██╗
██║░░██╗░███████║██╔████╔██║█████╗░░██╔████╔██║███████║██╔██╗██║██║███████║
██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░██║╚██╔╝██║██╔══██║██║╚████║██║██╔══██║
╚██████╔╝██║░░██║██║░╚═╝░██║███████╗██║░╚═╝░██║██║░░██║██║░╚███║██║██║░░██║
░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░╚═╝");
    Console.WriteLine("Seja bem-vindo ao GAMEMANIA!");
    Console.WriteLine("**************************************************");
}

void RodapeVoltarParaPrincipal()
{
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
    Console.ReadKey();
    //Thread.Sleep(1000);
    Console.Clear();
    MenuPrincipal();
}

void CadastrarNovoJogo()
{

    ExibirTituloDaOpcao("Cadastrar um novo Jogo");
    var nomeDoJogo = Console.ReadLine();
    jogos.Add(nomeDoJogo);
    Console.WriteLine("Jogo Adicionado com sucesso");
    RodapeVoltarParaPrincipal();
}

void ExibirTituloDaOpcao(string titulo)
{
    Console.Clear();
    Console.WriteLine("**********************************************");
    Console.WriteLine(titulo);
    Console.WriteLine("**********************************************");
}

void ExibirJogosCadastrados()
{
    ExibirTituloDaOpcao("Exibindo Jogos Cadastrados");
    foreach (var jogo in jogos)
    {
        Console.WriteLine(jogo);
    }
    RodapeVoltarParaPrincipal();
}


void MenuPrincipal()
{
    int opcao;
    ExibirMensagemBoasVindas();
    Console.WriteLine("1 - Cadastrar novo Jogo");
    Console.WriteLine("2 - Exibir jogos cadastrados ");
    Console.WriteLine("3 - Mostrar detalhes dos jogos");
    Console.WriteLine("4 - Avaliar jogo");
    Console.WriteLine("5 - Sair");

    var input = Console.ReadLine();
    opcao = int.Parse(input);

    switch (opcao){
        case 1:
            CadastrarNovoJogo();
            break;
        case 2:
            ExibirJogosCadastrados();
            break;
        case 3:
            Console.WriteLine("Detalhes do jogo selecionado!");
            break;
        case 4:
            Console.WriteLine("Avaliação do jogo selecionado!");
            break;
        case 5:
            Console.WriteLine("Volte sempre...");
            break;
        default:
            Console.WriteLine("Opção inválida: tente outra opção!");
            break;
    }
}

MenuPrincipal();