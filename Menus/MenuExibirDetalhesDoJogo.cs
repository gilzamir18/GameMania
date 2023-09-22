namespace GameMania.Menus;

using GameMania.Modelos;

internal class MenuExibirDetalhesDoJogo: Menu {
    public MenuExibirDetalhesDoJogo() : base("*  Detalhes do Jogo  *") { }

    public override bool MostrarOpcao() {
        var jogos = jogoDAO.ObterTodosOsJogos();

        foreach (var jogo in jogos) {
            jogo.ExibirFichaTecnica();
        }
        
        return false;
    }
}