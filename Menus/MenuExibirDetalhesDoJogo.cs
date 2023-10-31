namespace GameMania.Menus;

internal class MenuExibirDetalhesDoJogo: Menu {

    public MenuExibirDetalhesDoJogo() : base("*  Exibir Detalhes de Jogo  *") { }

    public override bool MostrarOpcao() {
        string titulo = "";

        do {
            Console.Write("Informe o título do jogo: ");
            titulo = Console.ReadLine();

            if (titulo == "" || titulo.All(char.IsWhiteSpace)) {
                Console.WriteLine("O título do jogo deve ser preenchido.");
            }
        } while (titulo == "" || titulo.All(char.IsWhiteSpace));

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