namespace GameMania.Menus;

internal class MenuExibirDetalhesDoJogo: Menu {

    public MenuExibirDetalhesDoJogo() : base("*  Exibir Detalhes de Jogo  *") { }

    public override bool MostrarOpcao() {
        Console.Write("Informe o título do jogo: ");
        string titulo = Console.ReadLine();
        var jogo = jogoDAO.ObterPorTitulo(titulo);

        Console.WriteLine();
        jogo.ExibirFichaTecnica();

        /* if (jogo != null) {
            Console.WriteLine($"O jogo {titulo} tem média de avaliação: {jogo.NotaMedia}");
        } else {
            Console.WriteLine($"O jogo {titulo} não existe ou não foi cadastrado!");
        } */
        return false;
    }
}