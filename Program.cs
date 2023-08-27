
List<Jogo> listaJogos = new(){new Jogo("FarCry"),new Jogo("CoD")};

void ExibirMensagemBoasVindas(){
    Console.WriteLine(@"
░██████╗░░█████╗░███╗░░░███╗███████╗███╗░░░███╗░█████╗░███╗░░██╗██╗░█████╗░
██╔════╝░██╔══██╗████╗░████║██╔════╝████╗░████║██╔══██╗████╗░██║██║██╔══██╗
██║░░██╗░███████║██╔████╔██║█████╗░░██╔████╔██║███████║██╔██╗██║██║███████║
██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░██║╚██╔╝██║██╔══██║██║╚████║██║██╔══██║
╚██████╔╝██║░░██║██║░╚═╝░██║███████╗██║░╚═╝░██║██║░░██║██║░╚███║██║██║░░██║
░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░╚═╝");
}

void RodapeVoltarParaPrincipal(){
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
    MenuPrincipal();
}

void ExibirTituloDaOpcao(string titulo, char preencher='*'){
    Console.Clear();
    var barra = string.Empty.PadLeft(titulo.Length, preencher);
    Console.WriteLine(barra);
    Console.WriteLine(titulo);
    Console.WriteLine(barra);
}

void CadastrarNovoJogo(){
    ExibirTituloDaOpcao("Cadastrar um novo Jogo - Digite 0 para cancelar");
    Console.Write("Insira o Titulo do Jogo: ");
    var nomeDoJogo = Console.ReadLine();
    while(string.IsNullOrWhiteSpace(nomeDoJogo)){
        Console.Write("Tente novamente: ");
        nomeDoJogo = Console.ReadLine();
    }
    if(nomeDoJogo != "0"){
        listaJogos.Add(new Jogo(nomeDoJogo));
        Console.WriteLine("Jogo Adicionado com sucesso");        
    }else{
        Console.WriteLine("Cadastro cancelado");
    }

    RodapeVoltarParaPrincipal();
}

void ExibirJogosCadastrados(){
    ExibirTituloDaOpcao("Exibindo Jogos");
    foreach (var jogo in listaJogos){
        Console.WriteLine(jogo.Titulo);
    }
    RodapeVoltarParaPrincipal();
}

void ExibirDetalhesDoJogo(){
    ExibirTituloDaOpcao("Exibindo Detalhes do Jogo - Digite 0 para cancelar");
    var titulo = "1";
    while(titulo != "0"){
        Console.Write("Informe o título do jogo: ");
        titulo = Console.ReadLine();
        titulo = (!string.IsNullOrWhiteSpace(titulo))? titulo :"";
        bool match = false;
        foreach (var jogo in listaJogos){
            if(titulo == jogo.Titulo){
                jogo.ExibirFichaTecnica();
                match = true;
            }
        }
        if(!match && titulo != "0"){
            Console.WriteLine("Titulo nao encontrado");
        }            
    }
    RodapeVoltarParaPrincipal();
}

void MenuPrincipal(){
    var input = "1";
    ExibirMensagemBoasVindas();
    Console.WriteLine("0 - Sair");
    Console.WriteLine("1 - Cadastrar novo Jogo");
    Console.WriteLine("2 - Exibir jogos cadastrados ");
    Console.WriteLine("3 - Mostrar detalhes dos jogos");
    Console.WriteLine("4 - Avaliar jogo");

    while( input != "0"){
        input = Console.ReadLine();
        input = (!string.IsNullOrWhiteSpace(input))? input: "\n";

        switch (input){
            case "0":
                input = "0";
                Console.WriteLine("Volte sempre...");
                break;            
            case "1":
                CadastrarNovoJogo();
                break;
            case "2":
                ExibirJogosCadastrados();
                break;
            case "3":
                ExibirDetalhesDoJogo();
                break;
            case "4":
                Console.WriteLine("Avaliação do jogo selecionado!");
                break;
            default:
                Console.Write("Opção inválida: tente outra opção!\n");
                break;
        }
    }    
     
    


}

MenuPrincipal();