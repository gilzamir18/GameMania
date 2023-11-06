using Auxiliares;

namespace GameMania.Menus;

internal class ExibirDetalhesDoJogo: Menu {
    public ExibirDetalhesDoJogo() : base("*  Exibir Detalhes de Jogo  *") { }

    public override bool MostrarOpcao() {
        Console.Write("Título do Jogo: ");
        string titulo = Validacoes.ObterStringValida("Título");
        var jogo = jogoDAO.BuscarJogo(titulo);

        Console.WriteLine();
        if (jogo != null) {
            jogo.ExibirFichaTecnica();
        } else {
            Console.WriteLine($"{titulo} ainda não foi cadastrado.");
        }

        return false;
    }
}