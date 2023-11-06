namespace GameMania.Menus;

internal class ExibirJogosCadastrados: Menu {
    public ExibirJogosCadastrados() : base("*  Exibir Jogos Cadastrados  *") { }

    public override bool MostrarOpcao() {
        var jogos = jogoDAO.ListarJogos();

        if (jogos.Count > 0) {
            var jogosOrdenados = jogos.OrderBy(jogo => jogo.Titulo).ToList();

            foreach (var jogo in jogosOrdenados) {
                Console.WriteLine($"{jogo.Titulo}");
            }
        } else {
            Console.WriteLine("Ainda não temos jogos cadastrados.");
        }

        return false;
    }
}