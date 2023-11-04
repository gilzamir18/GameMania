namespace GameMania.Menus;

internal class ExibirJogosCadastrados: Menu {

    public ExibirJogosCadastrados() : base("*  Exibir Jogos Cadastrados  *") { }

    public override bool MostrarOpcao() {
        var jogos = jogoDAO.ListarJogos();
        var jogosOrdenados = jogos.OrderBy(jogo => jogo.Titulo).ToList();

        foreach (var jogo in jogosOrdenados) {
            Console.WriteLine($"{jogo.Titulo}");
        }
        return false;
    }
}