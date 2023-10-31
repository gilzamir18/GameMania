namespace GameMania.Menus;

internal class MenuAvaliarJogosCadastrados: Menu {
    
    public MenuAvaliarJogosCadastrados() : base("*  Avaliar Jogos Cadastrados  *") { }

    public override bool MostrarOpcao() {
        var titulo = "";

        do {
            Console.Write("Informe o título do jogo a ser avaliado: ");
            titulo = Console.ReadLine();

            if (titulo == "" || titulo.All(char.IsWhiteSpace)) {
                Console.WriteLine("O título do jogo deve ser preenchido.");
            }
        } while (titulo == "" || titulo.All(char.IsWhiteSpace));

        var jogo = jogoDAO.ObterPorTitulo(titulo);

        if (jogo != null) {
            var nota = "";
            do {
                Console.Write($"Qual nota você dá ao jogo {titulo}? ");
                nota = Console.ReadLine();

                try {
                    Avaliacao avaliacao = Avaliacao.Parse(nota);

                    if (avaliacao.Nota >= 1 && avaliacao.Nota <= 10) {
                        jogo.AdicionarNota(avaliacao);
                        break;
                    } else {
                        Console.WriteLine("\nA nota deve ser um número entre 1 e 10.");
                    }
                } catch (FormatException e) {
                    Console.WriteLine(e.Message);
                }
            } while (nota != "");
        } else {
            Console.WriteLine($"\nNão existe um jogo cadastrado com o título '{titulo}'");
        }
        return false;
    }

    /* public override bool MostrarOpcao() {
        Console.Write("Informe o título do jogo a ser avaliado: ");
        var titulo = Console.ReadLine();
        var jogo = jogoDAO.ObterPorTitulo(titulo);

        if (jogo != null) {
            Console.Write($"Qual nota você dá ao jogo {titulo}? ");
            try {
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine());
                jogo.AdicionarNota(nota);
            } 
            catch(FormatException e) {
                Console.WriteLine(e.Message);
            }
        } else {
            Console.WriteLine($"Não existe jogo cadastrado com o título {titulo}");
        }
        return false;
    } */
}