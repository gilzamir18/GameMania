namespace GameMania.Menus;

internal class MenuExibirJogosCadastrados: Menu {

    public MenuExibirJogosCadastrados() : base("Exibir Jogos Cadastrados") { }

    public override bool MostrarOpcao() {
        var jogos = jogoDAO.ObterTodosOsJogos();

        foreach (var jogo in jogos) {
            jogo.ExibirFichaTecnica();
        }
        return false;
    }
}