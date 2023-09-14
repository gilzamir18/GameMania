namespace GameMania.Menus;

using GameMania.Modelos;

internal class MenuExibirDetalhesDoJogo: Menu
{
    public MenuExibirDetalhesDoJogo(): base("Exibindo detalhes do jogo"){}
    public override bool MostrarOpcao(Dictionary<string, Jogo> jogosRegistrados)
    {
        Console.Write("Informe o título do jogo: ");
        string titulo = Console.ReadLine();
        if (jogosRegistrados.ContainsKey(titulo))
        {
            var jogo = jogosRegistrados[titulo];
            Console.WriteLine($"A média de avaliação do jogo {titulo} é: {jogo.NotaMedia}");
        }
        else
        {
            Console.WriteLine($"Não existe um jogo com o título {titulo}");
        }
        return false;
    }
}