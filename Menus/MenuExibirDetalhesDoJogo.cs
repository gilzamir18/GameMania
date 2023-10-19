namespace GameMania.Menus;

using GameMania.Modelos;

internal class MenuExibirDetalhesDoJogo: Menu
{
    public MenuExibirDetalhesDoJogo(): base("Exibindo detalhes dos jogos"){}
    public override bool MostrarOpcao(Dictionary<string, Jogo> jogosRegistrados)
    {
        Console.Write("Informe o título do jogo: ");
        string titulo = Console.ReadLine();
        var jogo = jogoDAO.ObterPorTitulo(titulo);
        if (jogo != null)
        {
            Console.WriteLine($"A média de avaliação do jogo {titulo} é: {jogo.NotaMedia}");
        }
        else
        {
            Console.WriteLine($"Não existe um jogo com o título {titulo}");
        }
        return false;
    }
}