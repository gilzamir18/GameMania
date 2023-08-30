

List<Jogo> listaJogos = new(){
    new Jogo("FarCry","Acao/Aventura","Ubisoft","3","3edicao",true,"AllPlatform",notas:new List<float>{10,9,8}),
    new Jogo("GTA","Acao/Aventura","RockStar","5","5edicao",true,"AllPlatform",notas:new List<float>{8,9,8})
    };

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
    Console.WriteLine("Pressione Qualquer Tecla Para Voltar ao Menu Principal...");
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

Jogo? EncontrarJogo(string? titulo) {
    if (string.IsNullOrEmpty(titulo)) {
        return null;
    }
    foreach (Jogo jogo in listaJogos) {
        if (jogo.Titulo == titulo) {
            return jogo;
        }
    }
    return null;
}

string? ForcedValidationString(string? aux){
    while(string.IsNullOrEmpty(aux)) {
        Console.Write("Tente Novamente: ");
        aux = Console.ReadLine();
    }
    return aux;
}

float ForcedValidationFloat(string? aux) {
    float floatValue;
    while (!float.TryParse(aux, out floatValue)) {
        Console.WriteLine("Tente Novamente: ");
        aux = Console.ReadLine();
    }
    return floatValue;
}

void CadastrarNovoJogo(){
    ExibirTituloDaOpcao("Cadastrar um novo Jogo - Digite -1 Para Cancelar");
    Console.Write("Insira o Titulo do Jogo: ");
    string? aux = Console.ReadLine();
    while (string.IsNullOrEmpty(aux) || EncontrarJogo(aux) != null) {
        Console.Write("Nome inválido ou já cadastrado. Tente Novamente: ");
        aux = Console.ReadLine();
    }
    if(aux != "-1"){
        Jogo? jogo = new(aux);
        Console.WriteLine("Insira Genero: ");
        aux = Console.ReadLine();
        jogo.Genero = ForcedValidationString(aux);

        Console.WriteLine("Insira Studio: ");
        aux = Console.ReadLine();
        jogo.Studio = ForcedValidationString(aux);        

        Console.WriteLine("Insira Edicao: ");
        aux = Console.ReadLine();
        jogo.Edicao = ForcedValidationString(aux);

        // ReadOnly
        // Console.WriteLine("Insira Descricao: ");
        // aux = Console.ReadLine();
        // jogo.Descricao = ForcedValidationString(aux);

        Console.WriteLine("Disponivel Para Avaliacao? (1 = Sim | 0 - Nao)");
        aux = Console.ReadLine();
        while( (aux != "0" && aux != "1") || string.IsNullOrEmpty(aux)){
            Console.Write("Tente Novamente");
            aux = Console.ReadLine();
        }
        jogo.Disponibilidade = (aux == "1")?true:false;

        Console.WriteLine("Insira Plataformas: ");
        aux = Console.ReadLine();
        jogo.Plataformas = ForcedValidationString(aux);

        List<float> notas = new();
        Console.WriteLine("Insira Notas - Digite -1 Para Cancelar");
        float n = 0;
        while(n >= 0){
            aux = Console.ReadLine();
            n = ForcedValidationFloat(aux);
            if(n>=0){
                notas.Add(n);
            }else{
                n=-1;
            }
        }
        jogo.Notas = notas;

        listaJogos.Add(jogo);
        Console.WriteLine("Jogo Adicionado Com Sucesso");        
    }else{
        Console.WriteLine("Cadastro Cancelado");
    }
    RodapeVoltarParaPrincipal();
}

void ExibirJogosCadastrados(){
    ExibirTituloDaOpcao("Exibindo Jogos");
    if(listaJogos.Count == 0){
        Console.WriteLine("Nenhum Jogo Cadastrado!");
    }else{
        foreach (Jogo jogo in listaJogos){
            Console.WriteLine(jogo.Titulo);
        }
    }
    RodapeVoltarParaPrincipal();
}

void ExibirDetalhesDoJogo(){
    ExibirTituloDaOpcao("Exibindo Detalhes do Jogo - Digite -1 Para Cancelar Busca");
    string? titulo = "0";
    while(titulo != "-1"){
        Console.Write("Informe o Título Do Jogo - Digite -1 Para Cancelar Busca: ");
        titulo = Console.ReadLine();
        titulo = (!string.IsNullOrWhiteSpace(titulo)) ? titulo : "";
        if (titulo != "-1"){
            Jogo? jogo = EncontrarJogo(titulo);
            if(jogo==null){
                Console.WriteLine("Titulo Nao Encontrado");
            }else{
                jogo.ExibirFichaTecnica();
            }             
        }  
    }
    MenuPrincipal();
}

void AvaliarJogoCadastrado(){
    ExibirTituloDaOpcao("Qual Jogo Deseja Avaliar? - Digite -1 Para Cancelar");
    Console.Write("Insira o Titulo do Jogo a Ser Avaliado: ");
    string? aux = Console.ReadLine();
    while (string.IsNullOrEmpty(aux) || EncontrarJogo(aux) == null) {
        if(aux == "-1"){
            RodapeVoltarParaPrincipal();
        }
        Console.Write("Nome inválido ou já cadastrado. Tente Novamente: ");
        aux = Console.ReadLine();
    }
    Jogo? jogo = EncontrarJogo(aux);
    if(jogo == null){//Apenas para tirar o warning
        RodapeVoltarParaPrincipal();
        jogo = (jogo == null) ? new() : jogo;
    }
    Console.WriteLine("Insira Notas - Digite -1 Para Cancelar");
    float n = 0;
    jogo.Notas = jogo.Notas == null ? new List<float>{0} : jogo.Notas; //Apenas para tirar o warning
    while(n >= 0){
        aux = Console.ReadLine();
        n = ForcedValidationFloat(aux);
        if(n>=0){   
            jogo.Notas.Add(n);
        }else{
            n=-1;
        }
    }        
    
    RodapeVoltarParaPrincipal();
}

void MenuPrincipal(){
    Console.Clear();
    string? input;
    ExibirMensagemBoasVindas();
    Console.WriteLine("0 - Sair");
    Console.WriteLine("1 - Cadastrar Novo Jogo");
    Console.WriteLine("2 - Exibir Jogos Cadastrados ");
    Console.WriteLine("3 - Mostrar Detalhes Dos Jogos");
    Console.WriteLine("4 - Avaliar Jogo");

    input = Console.ReadLine();
    input = (!string.IsNullOrWhiteSpace(input))? input: "-1";
    switch (input){
        case "0":
            Console.WriteLine("Volte sempre...");
            return;
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
            AvaliarJogoCadastrado();
            break;
        default:
            Console.WriteLine("Opção inválida: tente outra opção!");
            MenuPrincipal();
            break;
    }
          
}

MenuPrincipal();
