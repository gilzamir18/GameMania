class Jogo
{
    public string titulo {get; set;}
    string genero;
    string studio;
    string edicao;
    string Descricao {get;}
    bool disponibilidade;
    string plataformas;

    public Jogo(string descricao)
    {
        
        this.Descricao = descricao;
    }


    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Título: {titulo}");
        Console.WriteLine($"Genero: {genero}");
        Console.WriteLine($"Título: {studio}");
        Console.WriteLine($"Edição: {edicao}");
        Console.WriteLine($"Título: {plataformas}");
        if (disponibilidade)
        {
            Console.WriteLine("Este jogo não está disponível para avaliação.");
        }
        else
        {
            Console.WriteLine("Este jogo não está disponível para avaliação.");
        }
    }
}
