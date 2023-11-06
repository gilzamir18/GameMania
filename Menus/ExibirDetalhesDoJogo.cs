using Auxiliares;

namespace GameMania.Menus;

internal class ExibirDetalhesDoJogo: Menu {

    public ExibirDetalhesDoJogo() : base("*  Exibir Detalhes de Jogo  *") { }

    public override bool MostrarOpcao() {
        string titulo = Validacoes.ObterStringValida("Informe o título do jogo: ", "Título");
        var jogo = jogoDAO.BuscarJogo(titulo);

        Console.WriteLine();
        if (jogo != null) {
            jogo.ExibirFichaTecnica();
        } else {
            Console.WriteLine($"'{titulo}' não existe ou não foi cadastrado!");
        }

        return false;
    }
}