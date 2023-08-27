class Jogo {
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public string Studio { get; set; }
    public string Edicao { get; set; }
    public string Descricao { get; set; }
    public bool Disponibilidade { get; set; }
    public string Plataformas { get; set; }

    public Jogo(string titulo="", string genero="", string studio="", string edicao="", string descricao="", bool disponibilidade=false, string plataformas=""){
        Titulo = titulo;
        Genero = genero;
        Studio = studio;
        Edicao = edicao;
        Descricao = descricao;
        Disponibilidade = disponibilidade;
        Plataformas = plataformas;

    }

    public void ExibirFichaTecnica() {
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Gênero: {Genero}");
        Console.WriteLine($"Estúdio: {Studio}");
        Console.WriteLine($"Edição: {Edicao}");
        Console.WriteLine($"Plataformas: {Plataformas}");

        if(Disponibilidade) {
            Console.WriteLine("Este jogo está disponível para avaliação.");
        } else {
            Console.WriteLine("Este jogo não está disponível para avaliação.");
        }
    }
}
