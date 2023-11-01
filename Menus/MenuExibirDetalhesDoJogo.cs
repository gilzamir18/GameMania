using Auxiliares;

namespace GameMania.Menus;

internal class MenuExibirDetalhesDoJogo: Menu {

    public MenuExibirDetalhesDoJogo() : base("*  Exibir Detalhes de Jogo  *") { }

    public override bool MostrarOpcao() {
        string titulo = Validacoes.ObterStringValida("Informe o título do jogo: ");

        var jogo = jogoDAO.ObterPorTitulo(titulo);

        Console.WriteLine();

        if (jogo != null) {
            jogo.ExibirFichaTecnica();
        } else {
            Console.WriteLine($"'{titulo}' não existe ou não foi cadastrado!");
        }

        return false;
    }
}