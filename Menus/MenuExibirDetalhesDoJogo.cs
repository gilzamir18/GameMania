namespace GameMania.Menus;

using GameMania.Modelos;

internal class MenuExibirDetalhesDoJogo: Menu {
    public MenuExibirDetalhesDoJogo() : base("*  Detalhes do Jogo  *") { }

    public override bool MostrarOpcao(Dictionary<string, Jogo> jogosRegistrados) {
        Console.Write("Informe o título do jogo: ");
        string titulo = Console.ReadLine();

        if (jogosRegistrados.ContainsKey(titulo)) {
            var jogo = jogosRegistrados[titulo];
            Console.WriteLine($"{jogo.Titulo} é um jogo do genero {jogo.Genero}, desenvolvido pelo studio {jogo.Studio}.\nA sua nota média de avaliação é de {jogo.NotaMedia}");
        } else {
            Console.WriteLine($"Não existe um jogo com o título {titulo}");
        }
        
        return false;
    }
}