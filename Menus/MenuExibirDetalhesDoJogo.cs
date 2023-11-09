namespace GameMania.Menus;

using GameMania.Modelos;

internal class MenuExibirDetalhesDoJogo: Menu
{
    public MenuExibirDetalhesDoJogo(): base("Exibindo detalhes dos jogos"){}
    public override bool MostrarOpcao()
    {
        string titulo = ObterTituloValido();
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
    private string ObterTituloValido(){
        string titulo;
        do
        {
            Console.Clear();
            Console.Write("Informe o título do jogo: ");
             titulo = Console.ReadLine()!;
        } while (string.IsNullOrWhiteSpace(titulo));

        return titulo;
    }
}