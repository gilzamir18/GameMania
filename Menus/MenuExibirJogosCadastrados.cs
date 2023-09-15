namespace GameMania.Menus;

using GameMania.Modelos;

internal class MenuExibirJogosCadastrados: Menu {
    public MenuExibirJogosCadastrados() : base("*  Jogos Cadastrados  *") { }

    public override bool MostrarOpcao() {
        var jogos = jogoDAO.ObterTodosOsJogo();

        foreach (var jogo in jogos)
            jogo.ExibirFichaTecnica();
        
        return false;
    }
}