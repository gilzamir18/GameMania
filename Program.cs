Dictionary< string, Jogo > jogosRegistrados = new();

void RodapeVoltarParaPrincipal(){
  Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
  Console.ReadKey();
  Console.Clear();
  MenuPrincipal();
}

void CadastrarNovoJogo(){
  ExibirTituloDaOpcao("Cadastrar um novo Jogo");

  Console.Write("Informe o título do jogo: ");
  var nomeDoJogo = Console.ReadLine()!;

  Console.Write("Informe o genero do jogo: ");
  var generoDoJogo = Console.ReadLine()!;

  Console.Write("Informe o studio do jogo: ");
  var studioDoJogo = Console.ReadLine()!;

  Console.Write("Informe a edição do jogo: ");
  var edicaoDoJogo = Console.ReadLine()!;

  Console.Write("Informe as plataformas do jogo: ");
  var plataformasDoJogo = Console.ReadLine()!;

  jogosRegistrados.Add(nomeDoJogo, new Jogo(nomeDoJogo, generoDoJogo, studioDoJogo, edicaoDoJogo, plataformasDoJogo));
  Console.WriteLine("Jogo adicionado com sucesso!");
  RodapeVoltarParaPrincipal();
}

void ExibirMensagemBoasVindas(){
  Console.WriteLine(@"
░██████╗░░█████╗░███╗░░░███╗███████╗███╗░░░███╗░█████╗░███╗░░██╗██╗░█████╗░
██╔════╝░██╔══██╗████╗░████║██╔════╝████╗░████║██╔══██╗████╗░██║██║██╔══██╗
██║░░██╗░███████║██╔████╔██║█████╗░░██╔████╔██║███████║██╔██╗██║██║███████║
██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░██║╚██╔╝██║██╔══██║██║╚████║██║██╔══██║
╚██████╔╝██║░░██║██║░╚═╝░██║███████╗██║░╚═╝░██║██║░░██║██║░╚███║██║██║░░██║
░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░╚═╝");
  Console.WriteLine("Seja bem-vindo ao GAMEMANIA!");
}

void ExibirTituloDaOpcao(string titulo, char preencher='*'){
  Console.Clear();
  var barra = string.Empty.PadLeft(titulo.Length, preencher);
  Console.WriteLine(barra);
  Console.WriteLine(titulo);
  Console.WriteLine(barra);
}

void ExibirJogosCadastrados(){
  ExibirTituloDaOpcao("Exibindo Jogos");
  if(jogosRegistrados.Count != 0)
    foreach(var jogo in jogosRegistrados.Keys)
      Console.WriteLine($"Título: {jogo}");
  else
    Console.WriteLine("Nenhum jogo cadastrado");
  RodapeVoltarParaPrincipal();
}

void ExibirDetalhesDoJogo(){
  ExibirTituloDaOpcao("Exibindo Detalhes do Jogo");
  Console.Write("Informe o título do jogo: ");
  string titulo = Console.ReadLine()!;
  if(jogosRegistrados.ContainsKey(titulo)){
    var jogo = jogosRegistrados[titulo];
    jogo.ExibirFichaTecnica();
  }
  else
    Console.WriteLine($"Não existe um jogo com o título {titulo}");
  RodapeVoltarParaPrincipal();
}

void AvaliarJogoCadastrado(){
  ExibirTituloDaOpcao("Avaliar jogo");
  Console.Write("Digite o nome do jogo que deseja avaliar: ");
  string nomeDoJogo = Console.ReadLine()!;
  if(jogosRegistrados.ContainsKey(nomeDoJogo) && jogosRegistrados[nomeDoJogo].GetDisponibilidade()){
    Console.Write($"Qual a nota que o jogo {nomeDoJogo} merece: ");
    int nota = int.Parse(Console.ReadLine()!);
    jogosRegistrados[nomeDoJogo].notas.Add(nota);
    Console.WriteLine("Jogo avaliado com sucesso!");
  }else
    Console.WriteLine($"A jogo {nomeDoJogo} não foi encontrado ou não disponivel para avaliação!");
  RodapeVoltarParaPrincipal();
}

void MenuPrincipal(){
  int opcao;
  ExibirMensagemBoasVindas();
  Console.WriteLine("1 - Cadastrar novo Jogo");
  Console.WriteLine("2 - Exibir jogos cadastrados ");
  Console.WriteLine("3 - Mostrar detalhes dos jogos");
  Console.WriteLine("4 - Avaliar jogo");
  Console.WriteLine("5 - Sair");

  var input = Console.ReadLine()!;
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
      AvaliarJogoCadastrado();
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