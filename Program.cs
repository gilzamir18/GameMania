

//List<string> jogos = new() {"GTA", "Valorant", "CounterStrike", "NeedForSpeed"} ;

Dictionary< string, List<int> > jogosRegistrados = new();
jogosRegistrados["Forza"] = new List<int>(){10, 7, 8};
jogosRegistrados["Valorant"] = new List<int>(){10, 5, 7}; 
jogosRegistrados["FarCry"] = new List<int>{10, 10, 10};

void ExibirMensagemBoasVindas()
{
    Console.WriteLine(@"
░██████╗░░█████╗░███╗░░░███╗███████╗███╗░░░███╗░█████╗░███╗░░██╗██╗░█████╗░
██╔════╝░██╔══██╗████╗░████║██╔════╝████╗░████║██╔══██╗████╗░██║██║██╔══██╗
██║░░██╗░███████║██╔████╔██║█████╗░░██╔████╔██║███████║██╔██╗██║██║███████║
██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░██║╚██╔╝██║██╔══██║██║╚████║██║██╔══██║
╚██████╔╝██║░░██║██║░╚═╝░██║███████╗██║░╚═╝░██║██║░░██║██║░╚███║██║██║░░██║
░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░╚═╝");
    Console.WriteLine("Seja bem-vindo ao GAMEMANIA!");
}

void RodapeVoltarParaPrincipal()
{
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
    Console.ReadKey();
    //Thread.Sleep(1000);
    Console.Clear();
    MenuPrincipal();
}
void ExibirTituloDaOpcao(string titulo, char preencher = '*')
{
    Console.Clear();
    var barra = string.Empty.PadLeft(titulo.Length, preencher);
    Console.WriteLine(barra);
    Console.WriteLine(titulo);
    Console.WriteLine(barra);
}


void CadastrarNovoJogo()
{

    ExibirTituloDaOpcao("Cadastrar um novo Jogo");
    var nomeDoJogo = Console.ReadLine();
    jogosRegistrados.Add(nomeDoJogo, new List<int>());
    Console.WriteLine("Jogo Adicionado com sucesso");
    RodapeVoltarParaPrincipal();
}


void ExibirJogosCadastrados()
{
    ExibirTituloDaOpcao("Exibindo Jogos");
    foreach (var jogo in jogosRegistrados.Keys)
    {
        var notas = jogosRegistrados[jogo];
        Console.WriteLine($"Título: {jogo}");
    }
    RodapeVoltarParaPrincipal();
}

void AvaliarJogo()
{
    ExibirTituloDaOpcao("Avaliar jogo");
    Console.Write("Digite o nome do jogo: ");
    string titulo = Console.ReadLine();
    if (jogosRegistrados.ContainsKey(titulo))
    {
        Console.Write("Digite a nota: ");
        var notaString = Console.ReadLine();
        int nota = int.Parse(notaString);
        if((nota >= 0) && (nota <= 10))
        {
            jogosRegistrados[titulo].Add(nota);
        }
        else
        {
            Console.WriteLine("Nota fora dos padrões");
        }
        
    }

    RodapeVoltarParaPrincipal();
}

void ExibirDetalhesDoJogo()
{
    ExibirTituloDaOpcao("Exibindo Detalhes do Jogo");
    Console.Write("Informe o título do jogo: ");
    string titulo = Console.ReadLine();
    if (jogosRegistrados.ContainsKey(titulo))
    {
        var notas = jogosRegistrados[titulo];
        if(notas.Count == 0) 
        {
            Console.WriteLine($"A média de avaliação do jogo {titulo} é: 0");
        }
        else
        {
            Console.WriteLine($"A média de avaliação do jogo {titulo} é: {notas.Average()}");
        }
       
    }
    else
    {
        Console.WriteLine($"Não existe um jogo com o título {titulo}");
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
            ExibirDetalhesDoJogo();
            break;
        case 4:
            AvaliarJogo();
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
