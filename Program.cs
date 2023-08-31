﻿Dictionary< string, Jogo > jogosRegistrados = new();
jogosRegistrados["Minecraft"] = new Jogo("Minecraft", "Sandbox", "Mojang", "1");
jogosRegistrados["Minecraft"].AdicionarPlataforma("PC");
jogosRegistrados["Minecraft"].AdicionarPlataforma("PS4");
jogosRegistrados["Minecraft"].AdicionarPlataforma("XBox360");

jogosRegistrados["Forza"] = new Jogo("Forza", "Corrida", "XBox Game Studios", "5");
jogosRegistrados["Forza"].AdicionarNota(10);
jogosRegistrados["Forza"].AdicionarNota(5);
jogosRegistrados["Forza"].AdicionarNota(2);
jogosRegistrados["Forza"].AdicionarPlataforma("XBox360");

jogosRegistrados["Valorant"] = new Jogo("Valorant", "Tático", "Riot Games", "6");
jogosRegistrados["Valorant"].AdicionarNota(10);
jogosRegistrados["Valorant"].AdicionarNota(8);
jogosRegistrados["Valorant"].AdicionarNota(9);
jogosRegistrados["Valorant"].AdicionarPlataforma("PS4");
jogosRegistrados["Valorant"].AdicionarPlataforma("XBox360");
jogosRegistrados["Valorant"].AdicionarPlataforma("PC");

char preencher = '*';

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

void RodapeVoltarParaPrincipal()
{
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
    Console.ReadKey();
    MenuPrincipal();
}

void CadastrarNovoJogo()
{

    ExibirTituloDaOpcao("Cadastrar um novo Jogo");
    Console.Write("Qual o título do jogo? ");
    var titulo = Console.ReadLine();
    Console.Write("Qual o genero do jogo? ");
    var genero = Console.ReadLine();
    Console.Write("Qual studio desenvolveu o jogo? ");
    var studio = Console.ReadLine();
    Console.Write("Qual a edição do jogo? ");
    var edicao = Console.ReadLine();
    jogosRegistrados.Add(titulo, new Jogo(titulo, genero, studio, edicao));
    Console.WriteLine("Jogo Adicionado com sucesso");
    RodapeVoltarParaPrincipal();
}

void ModificarExibirTituloDaOpcao()
{
    Console.WriteLine($"O caractere atual é {preencher}")
    Console.WriteLine("Insira a seguir o caractere que será utilizado ou digite 1 para cancelar.");
    char novo = Console.ReadLine();
    if (novo == '1')
    {
        Console.WriteLine($"Operação cancelada. O caractere atual permanece {preencher}")
    }
    else
    {
        preencher = novo;
        Console.WriteLine($"O novo caractere de destaque é {preencher}");
    }
    RodapeVoltarParaPrincipal();
}

void ExibirTituloDaOpcao(string titulo)
{
    Console.Clear();
    var barra = string.Empty.PadLeft(titulo.Length, preencher);
    Console.WriteLine(barra);
    Console.WriteLine(titulo);
    Console.WriteLine(barra);
}

void ExibirDetalhesDoJogo()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo Detalhes do Jogo");
    Console.Write("Informe o título do jogo: ");
    string titulo = Console.ReadLine();
    if (jogosRegistrados.ContainsKey(titulo))
    {
        if (jogo.NotaMedia == 0)
        {
            var jogo = jogosRegistrados[titulo];
            Console.WriteLine($"O jogo {titulo} não possui avaliações o suficiente.");
            Console.WriteLine($"A média de avaliação é: {jogo.NotaMedia}");
        }
        else
        {
            var jogo = jogosRegistrados[titulo];
            Console.WriteLine($"A média de avaliação do jogo {titulo} é: {jogo.NotaMedia}");
        }
    }
    else
    {
        Console.WriteLine($"Não existe um jogo com o título {titulo}");
    }
    RodapeVoltarParaPrincipal();
}


void AvaliarJogoCadastrado()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliando um jogo cadastrado.");
    Console.Write("Informe o título do jogo a ser avaliado: ");
    var titulo = Console.ReadLine();
    if (jogosRegistrados.ContainsKey(titulo))
    {
        Console.Write($"Qual nota você dá ao jogo {titulo}? ");
        int nota;

        while (!EntradaDeInteiro(out nota))
        {
            Console.WriteLine("Você digitou uma nova inválida!");
            Console.Write("Tente um valor inteiro: ");
        }
        jogosRegistrados[titulo].AdicionarNota(nota);
    }
    else
    {
        Console.WriteLine($"Não existe jogo cadastrado com o título {titulo}");
    }
    RodapeVoltarParaPrincipal();
}

void MenuPrincipal()
{
    ExibirMensagemBoasVindas();
    Console.WriteLine("1 - Cadastrar novo Jogo");
    Console.WriteLine("2 - Exibir jogos cadastrados ");
    Console.WriteLine("3 - Mostrar detalhes dos jogos");
    Console.WriteLine("4 - Avaliar jogo");
    Console.WriteLine("5 - Modificar Caractere de Destaque");
    Console.WriteLine("6 - Sair");

    int opcao;   
    EntradaDeInteiro(out opcao);

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
            AvaliarJogoCadastrado();
            break;
        case 5:
            ModificarExibirTituloDaOpcao();
            break;
        case 6:
            Console.WriteLine("Volte sempre...");
            break;
        default:
            Console.WriteLine("Opção inválida: tente outra opção!");
            RodapeVoltarParaPrincipal();
            break;
    }
}

void ExibirJogosRegistrados()
{
    if (jogosRegistrados.Count > 0)
    {
        ExibirTituloDaOpcao("Exibindo Jogos");
        foreach (var jogo in jogosRegistrados.Keys)
        {
            var notas = jogosRegistrados[jogo];
            Console.WriteLine($"Título: {jogo}");
        }
        RodapeVoltarParaPrincipal();
    }
    else
    {
        Console.WriteLine("Nenhum Jogo Cadastrado!");
    }
}


bool EntradaDeInteiro(out int valor)
{
    try
    {
        valor = int.Parse(Console.ReadLine());
        return true;
    }   
    catch(FormatException e)
    {
        valor = 0;
        return false;
    } 
}

MenuPrincipal();
