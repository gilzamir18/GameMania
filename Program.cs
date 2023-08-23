List<string> jogos = new List<string>();
int opcao;
do{

    Console.WriteLine("-------------------- GAMEMANIA --------------------");
    Console.WriteLine("1 - Cadastrar novo Jogo");
    Console.WriteLine("2 - Exibir jogos cadastrados ");
    Console.WriteLine("3 - Mostrar detalhes dos jogos");
    Console.WriteLine("4 - Avaliar jogo");
    Console.WriteLine("5 - Sair");

    var input = Console.ReadLine();
    opcao = int.Parse(input);

    switch (opcao){
        case 1:
            Console.WriteLine("Informe o nome do jogo");
            var nomeDoJogo = Console.ReadLine();
            jogos.Add(nomeDoJogo);
            Console.WriteLine("Jogo Adicionado com sucesso");
            break;
        case 2:
            Console.WriteLine("Exibindo jogos cadastrados");
            foreach (var jogo in jogos){
                Console.WriteLine(jogo);
            }
            break;
        case 3:
            Console.WriteLine("Detalhes do jogo selecionado!");
            break;
        case 4:
            Console.WriteLine("Avaliação do jogo selecionado!");
            break;
        case 5:
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Volte sempre!");
            break;
    }


} while (opcao != 5);
