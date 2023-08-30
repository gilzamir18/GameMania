

List<Jogo> listaJogos = new(){
    new Jogo("FarCry","Acao/Aventura","Ubisoft","3","3edicao",true,"AllPlatform",notas:new List<float>{9,8,8}),
    new Jogo("GTA","Acao/Aventura","RockStar","5","5edicao",true,"AllPlatform",notas:new List<float>{9,8,9}),
    new Jogo("Skyrim","RPG","Bethesda","5","5edicao",false,"AllPlatform",notas:new List<float>{10,10,10}),
    new Jogo("Valorant","FPS","Riot","1","1edicao",false,"AllPlatform",notas:new List<float>{0,0,0})
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

Jogo EncontraJogo(string? aux) {
    if (string.IsNullOrEmpty(aux)) {
        return new();
    }else{
        foreach (Jogo jogo in listaJogos) {
            if (jogo.Titulo == aux) {
                return jogo;
            }
        }
    }
    return new();
}

string ForcedValidationString(string? aux){
    while(string.IsNullOrEmpty(aux)) {
        Console.Write("Tente Novamente: ");
        aux = Console.ReadLine();
    }
    return aux;
}

float ForcedValidationFloat(string? aux) {
    float value;
    while (!float.TryParse(aux, out value)) {
        Console.Write("Tente Novamente: ");
        aux = Console.ReadLine();
    }
    return value;
}

void CadastrarNovoJogo(){
    ExibirTituloDaOpcao("Cadastrar Um Novo Jogo | Digite -1 Para Cancelar: ");
    Console.Write("Insira o Titulo do Jogo: ");

    string? aux = Console.ReadLine();
    Jogo? jogo = EncontraJogo(aux);

    while(aux==jogo.Titulo && aux != "-1"){
        Console.Write("Nome Invalido Ou Ja Cadastrado. Tente Novamente: ");
        aux = Console.ReadLine();
        jogo = EncontraJogo(aux);
    }
    
    if(aux != "-1"){
        jogo = new(aux);
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
        while( aux != "1" || aux != "0" || string.IsNullOrEmpty(aux)){
            Console.Write("Tente Novamente: ");
            aux = Console.ReadLine();
        }
        jogo.Disponibilidade = (aux == "1")?true:false;

        Console.WriteLine("Insira Plataformas: ");
        aux = Console.ReadLine();
        jogo.Plataformas = ForcedValidationString(aux);

        jogo.Notas = new List<float>{};//Evitar Warning
        Console.WriteLine("Insira Notas - Digite -1 Para Cancelar");
        float n = 0;
        while(n >= 0){
            aux = Console.ReadLine();
            n = ForcedValidationFloat(aux);
            if(n>=0){
                jogo.Notas.Add(n);
            }else{
                n=-1;
            }
        }

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
    ExibirTituloDaOpcao("Exibindo Detalhes do Jogo | Digite -1 Para Cancelar: ");
    string? aux = "0";
    while(aux != "-1"){
        Console.Write("Informe o Título Do Jogo | Digite -1 Para Cancelar: ");
        aux = Console.ReadLine();
        Jogo? jogo = EncontraJogo(aux);
        if(string.IsNullOrEmpty(jogo.Titulo)){
            Console.WriteLine("Titulo Nao Encontrado");
        }else{
            jogo.ExibirFichaTecnica();
            Console.WriteLine("");
        }             
    }
    RodapeVoltarParaPrincipal();
}

void AvaliarJogoCadastrado(){
    ExibirTituloDaOpcao("Qual Jogo Deseja Avaliar? | Digite -1 Para Cancelar: ");
    Console.Write("Insira o Titulo do Jogo a Ser Avaliado: ");

    string? aux = Console.ReadLine();
    Jogo? jogo = EncontraJogo(aux);

    while(string.IsNullOrEmpty(aux) || aux!=jogo.Titulo || !string.IsNullOrEmpty(jogo.Titulo) && jogo.Disponibilidade==false && aux != "-1"){
        if(!string.IsNullOrEmpty(jogo.Titulo)){
            Console.Write("Jogo Indisponvel Para Avaliacao. Tente Novamente: ");
        }else{
            Console.Write("Nome Invalido Ou Nao Cadastrado. Tente Novamente: ");
        }
        aux = Console.ReadLine();
        jogo = EncontraJogo(aux);
    }
    
    if(aux != "-1"){
        Console.WriteLine("Insira Notas | Digite -1 Para Cancelar: ");
        float n = 0;
        jogo.Notas = jogo.Notas == null ? new List<float>{} : jogo.Notas; //Apenas para tirar o warning
        while(n >= 0){
            aux = Console.ReadLine();
            n = ForcedValidationFloat(aux);
            if(n>=0){   
                jogo.Notas.Add(n);
            }else{
                n=-1;
            }
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
