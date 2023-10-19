namespace GameMania.Menus;

using GameMania.Modelos;

internal class MenuExibirDetalhesDoJogoPorFiltro: Menu
{

    public MenuExibirDetalhesDoJogoPorFiltro() : base("Exibir Detalhe de Jogo por Filtro")
    {
        
    }

    public override bool MostrarOpcao()
    {
        Console.Write("Escolha um filtro, entre Gênero, Studio, Disponibilidade: ");
        string filtro = Console.ReadLine();

        List<Jogo> jogos = new List<Jogo>();

        if (filtro.ToLower() == "gênero")
        {
            Console.Write("Informe o valor do filtro de Gênero: ");
            string valor = Console.ReadLine();
            jogos = jogoDAO.SelectJogoPorCampo("Genero", valor);
        }
        else if (filtro.ToLower() == "studio")
        {
            Console.Write("Informe o valor do filtro de Studio: ");
            string valor = Console.ReadLine();
            jogos = jogoDAO.SelectJogoPorCampo("Studio",valor);
        }
        else if (filtro.ToLower() == "disponibilidade")
        {
            Console.Write("Informe o valor do filtro de Disponibilidade (1 para disponível, 0 para indisponível): ");
            string valor = Console.ReadLine();
            jogos = jogoDAO.SelectJogoPorCampo("Disponilidade", valor);
        }
        else
        {
            Console.WriteLine("Filtro inválido.");
        }

         if (jogos != null && jogos.Count > 0)
    {
        foreach (Jogo jogo in jogos)
        {
            Console.WriteLine("Título " + jogo.Titulo);
            Console.WriteLine("Studio " + jogo.Studio);
            Console.WriteLine("Disponibilidade " + jogo.Disponibilidade);
            Console.WriteLine("Edição " + jogo.Edicao);

        }
    }
    else
    {
        Console.WriteLine("Nenhum jogo encontrado para o filtro especificado.");
    }

    
        
        return false;
    
    }
}