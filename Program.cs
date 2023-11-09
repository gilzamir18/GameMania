
using GameMania.Menus;
using GameMania.Modelos;
using GameMania.Dados;


Dictionary<string, Menu> opcoes = new Dictionary<string, Menu>();
opcoes["1"] = new MenuCadastrarNovoJogo();
opcoes["2"] = new MenuExibirJogosCadastrados();
opcoes["3"] = new MenuExibirDetalhesDoJogo();
opcoes["4"] = new MenuExibirDetalhesDoJogoPorFiltro();
opcoes["5"] = new MenuAvaliarJogosCadastrados();
opcoes["0"] = new MenuSair();

void ExibirMensagemBoasVindas()
{
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


void MenuPrincipal()
{
    //MostrarRelogio();
    // Task t = MostrarAlerta();
    while (true)
    {
        ExibirMensagemBoasVindas();
        Console.WriteLine("1 - Cadastrar novo Jogo");
        Console.WriteLine("2 - Exibir jogos cadastrados ");
        Console.WriteLine("3 - Mostrar detalhes dos jogos");
        Console.WriteLine("4 - Mostrar detalhes dos jogos por filtro");
        Console.WriteLine("5 - Avaliar jogo");
        Console.WriteLine("0 - Sair");
        string opcao = Console.ReadLine()!;
        if (opcoes.ContainsKey(opcao))
        {   
            
            bool sair = opcoes[opcao].Executar();
            if (sair)
            {
                break;
            }
        }
        else
        {
            Console.WriteLine("Opcao Inválida!. Tente novamente. Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

MenuPrincipal();

/*async void MostrarRelogio()
{
    int contagem = 0;
    while (true)
    {
        Console.Write("                                                \r");
        await Task.Delay(100);
        contagem += 100;
        if (contagem % 1000 == 0)
        {
            tempo ++;
        }
        Console.Write($"Tempo: {tempo}s");
    }
}

async Task MostrarAlerta()
{
    while (true)
    {
        try
        {
            await Task.Delay(TimeSpan.FromMinutes(1), cts.Token);

            if (estaMenuPrincipal)
            {
                Console.WriteLine("Alerta: Você está na tela do menu principal por mais de 1 minuto!");
            }
        }
        catch (TaskCanceledException)
        {
            // O token de cancelamento foi acionado, então a contagem regressiva foi cancelada
        }
    }
}*/


/*
IJogoDAO dao = SQLiteJogoDAO.GetInstance();
Jogo jogo = new Jogo("Valorant", "FPS", "Riot", "1");
jogo.AdicionarNota(new Avaliacao(10));
jogo.AdicionarNota(new Avaliacao(10));
jogo.AdicionarNota(new Avaliacao(8));
jogo.AdicionarPlataforma("XBoxLive");
jogo.AdicionarPlataforma("PC");
jogo.AdicionarPlataforma("PS");
dao.SalvarJogo(jogo);

List<Jogo> jogos = dao.ObterTodosOsJogos();
foreach (Jogo jogo in jogos)
{
    jogo.ExibirFichaTecnica();
}*/
