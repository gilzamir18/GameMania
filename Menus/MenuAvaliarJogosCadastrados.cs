namespace GameMania.Menus;
internal class MenuAvaliarJogosCadastrados: Menu {

    public MenuAvaliarJogosCadastrados() : base("*  Avaliar Jogos Cadastrados  *") { }

    public override bool MostrarOpcao() {
        Console.Write("Informe o título do jogo a ser avaliado: ");
        var titulo = Console.ReadLine();
        var jogo = jogoDAO.ObterJogoPorTitulo(titulo);

        if (jogo != null) {
            Console.Write($"Qual nota você dá ao jogo {titulo}? ");
            try {
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine());
                jogo.AdicionarNota(nota);
            } catch(FormatException e) {
                Console.WriteLine(e.Message);
            }
        } else {
            Console.WriteLine($"Não existe jogo cadastrado com o título {titulo}");
        }
        return false;
    }
}