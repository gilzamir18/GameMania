namespace GameMania.Menus;

using GameMania.Modelos;
//using OpenAI_API;

class MenuCadastrarNovoJogo: Menu {
    public MenuCadastrarNovoJogo() : base("*  Cadastrar Novo Jogo  *") { }

    public override bool MostrarOpcao() {
        Console.Write("Qual o título do jogo? ");
        var titulo = Console.ReadLine();
        Console.Write("Qual o genero do jogo? ");
        var genero = Console.ReadLine();
        Console.Write("Qual studio desenvolveu o jogo? ");
        var studio = Console.ReadLine();
        Console.Write("Qual a edição do jogo? ");
        var edicao = Console.ReadLine();
        jogoDAO.SalvarJogo(new Jogo(titulo, genero, studio, edicao));
        Console.WriteLine("Jogo Adicionado com sucesso");
        return false;
    }

/* ========== VERSÃO USANDO OpenIA API ==========

    public override bool MostrarOpcao() {
        Console.Write("Qual o título do jogo? ");
        var titulo = Console.ReadLine();
        Jogo jogo = null;
        char key = ' ';
        string genero = "";
        string studio = "";
        string edicao = "";
        string descricao = "";
        string plataformas = "";

        try {
            var client = new OpenAI_API.OpenAIAPI("TokenPessoal");
            var chat = client.Chat.CreateConversation();
            string request = $"Retorne no formato \"titulo:genero:studio:edicao:descricao:plataformas\" os dados do jogo {titulo}, onde titulo é o título do jogo, edicao é a edição do jogo (por exemplo, GTA 5 para o jogo GTA, onde a edição deve conter o último lançamento do jogo), plataformas é o conjunto de plataformas separadas por espaço (por exemplo 'XBoxLive PlayStation') que suportam este jogo e descricão é um breve resumo jogo em uma linguagem descontraída.";
            chat.AppendSystemMessage(request);
            string resposta = chat.GetResponseFromChatbotAsync().Result;
            string[] tokens = resposta.Split(':');
            genero = tokens[1].Trim();
            studio = tokens[2].Trim();
            edicao = tokens[3].Trim();
            descricao = tokens[4].Trim();
            plataformas = tokens[5].Trim();

            jogo = new Jogo(titulo, genero, studio, edicao);
            jogo.Descricao = descricao;

            string[] plats = plataformas.Split(' ');
            foreach (var p in plats) {
                jogo.AdicionarPlataforma(p);
            }

            Console.WriteLine("Como este título, preenchemos os seguintes dados: ");
            jogo.ExibirFichaTecnica();
            Console.WriteLine();
            Console.Write("Você confirma estes dados (pressione S) ou deseja preencher manualmente (qualquer tecla).");
            key = Console.ReadKey().KeyChar;
        } catch (Exception e) { 

        }

        if ((jogo == null || key == null) || (key != 'S' && key != 's')) {
            Console.Write("Qual o genero do jogo? ");
            var genero = Console.ReadLine();
            Console.Write("Qual studio desenvolveu o jogo? ");
            var studio = Console.ReadLine();
            Console.Write("Qual a edição do jogo? ");
            var edicao = Console.ReadLine();
        }
        
        jogosRegistrados.Add(titulo, new Jogo(titulo, genero, studio, edicao));
        Console.WriteLine("Jogo Adicionado com sucesso");
        
        return false;
    } */
}