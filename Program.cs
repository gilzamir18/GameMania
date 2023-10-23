
using GameMania.Menus;
using GameMania.Modelos;
using GameMania.Dados;
// int tempo = 0;
// bool estaMenuPrincipal = true;
Dictionary<string, Menu> opcoes = new Dictionary<string, Menu>();
opcoes["1"] = new MenuCadastrarNovoJogo();
opcoes["2"] = new MenuExibirJogosCadastrados();
opcoes["3"] = new MenuExibirDetalhesDoJogo();
opcoes["4"] = new MenuAvaliarJogosCadastrados();
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
    //estaMenuPrincipal = true;
    //CancellationTokenSource cts = new CancellationTokenSource();

    //MostrarRelogio();
    //Task t = MostrarAlerta();
    while (true)
    {
        ExibirMensagemBoasVindas();
        Console.WriteLine("1 - Cadastrar novo Jogo");
        Console.WriteLine("2 - Exibir jogos cadastrados ");
        Console.WriteLine("3 - Mostrar detalhes dos jogos");
        Console.WriteLine("4 - Avaliar jogo");
        Console.WriteLine("0 - Sair");
        string? opcao = Console.ReadLine();
        opcao = string.IsNullOrEmpty(opcao)? "":opcao;
        if (opcoes.ContainsKey(opcao))
        {   
            //estaMenuPrincipal = false;
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

// async void MostrarRelogio()
// {
//     int contagem = 0;
//     while (true)
//     {
//         Console.Write("                                                \r");
//         await Task.Delay(100);
//         contagem += 100;
//         if (contagem % 1000 == 0)
//         {
//             tempo ++;
//         }
//         Console.Write($"Tempo: {tempo}s");
//     }
// }

// async Task MostrarAlerta()
// {
//     int contagem = 0;
//     while (true)
//     {
//         if (!estaMenuPrincipal)
//         {
//             contagem = 0;
//             tempo = 0;
//             await Task.Delay(500);
//         }
//         else
//         {
//             await Task.Delay(500);
//             Console.Write("\r");
//             contagem += 500;
//             if (contagem % 8000 == 0)
//             {
//                 tempo = 0;
//                 contagem = 0;
//                 Console.Write("Está demorando muito!");
//             }
//         }
//     }
// }

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
