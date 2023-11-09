namespace GameMania.Menus;

using System.CodeDom;
using GameMania.Modelos;

class MenuCadastrarNovoJogo: Menu
{
    public MenuCadastrarNovoJogo(): base("Cadatrar um novo jogo"){}
    public override bool MostrarOpcao()
    {
        
        Console.Write("Qual o título do jogo? ");
        var titulo = Console.ReadLine();
        Console.Write("Qual o genero do jogo? ");
        var genero = Console.ReadLine();
        Console.Write("Qual studio desenvolveu o jogo? ");
        var studio = Console.ReadLine();
        Console.Write("Qual a edição do jogo? ");
        var edicao = Console.ReadLine();
         if (string.IsNullOrEmpty(titulo))
        {
            titulo = "Título Desconhecido"; // Ou outro valor padrão de sua escolha.
        }

        if (string.IsNullOrEmpty(genero))
        {
            genero = "Gênero Desconhecido"; // Valor padrão para gênero.
        }

        if (string.IsNullOrEmpty(studio))
        {
            studio = "Estúdio Desconhecido"; // Valor padrão para estúdio.
        }

        if (string.IsNullOrEmpty(edicao))
        {
            edicao = "Edição Desconhecida"; // Valor padrão para edição.
        }
        jogoDAO.SalvarJogo(new Jogo(titulo, genero, studio, edicao));
        Console.WriteLine("Jogo Adicionado com sucesso");
        return false;
    }
}
