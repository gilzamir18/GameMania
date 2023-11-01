namespace GameMania.Menus;

internal class MenuExibirJogosCadastrados: Menu {

    public MenuExibirJogosCadastrados() : base("*  Exibir Jogos Cadastrados  *") { }

    public override bool MostrarOpcao() {
        var jogos = jogoDAO.ObterTodosOsJogos();
        var jogosOrdenados = jogos.OrderBy(jogo => jogo.Titulo).ToList();

        foreach (var jogo in jogosOrdenados) {
            Console.WriteLine($"{jogo.Titulo}");
        }
        return false;
    }
}