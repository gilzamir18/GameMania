namespace GameMania.Modelos;

public class Jogo {
    public string Titulo { get; set; }
    private List<string> Generos;
    public string Estudio { get; set; }
    public string Edicao { get; set; }
    public string? Descricao { get; set; } 
    public bool Disponibilidade { get; }
    private List<string> Plataformas;
    private List<Avaliacao> Notas;

    public float NotaMedia {
        get {
            return Notas.Count > 0 ? (float) Notas.Average(a => a.Nota) : 0;
        }
    }

    public Jogo(string titulo, string estudio, string edicao, bool disponilidade = true) {
        Titulo = titulo;
        Generos = new();
        Estudio = estudio;
        Edicao = edicao;
        Disponibilidade = disponilidade;
        Plataformas = new();
        Notas = new();
    }

    public void ExibirFichaTecnica() {
        Console.WriteLine($"Título: {Titulo}.");

        Console.Write($"Gênero{(Generos.Count >= 2 ? "s" : "")}: ");
        var generosStr = string.Join(", ", Generos);
        Console.WriteLine($"{generosStr[..]}.");

        Console.WriteLine($"Estudio: {Estudio}.");

        Console.WriteLine($"Edição: {Edicao}.");

        if (Descricao != null && !string.IsNullOrWhiteSpace(Descricao)) {
            Console.WriteLine($"Descrição: {Descricao}");
        }

        Console.Write($"Plataforma{(Plataformas.Count >= 2 ? "s" : "")}: ");
        var plataformasStr = string.Join(", ", Plataformas);
        Console.WriteLine($"{plataformasStr[..]}.");

        if (Disponibilidade) {
            if (NotaMedia > 0) {
                Console.WriteLine($"Nota Média: {NotaMedia:N2}.");
            }

            Console.WriteLine($"\n{Titulo} está disponível para avaliação.");
        } else {
            Console.WriteLine($"\n{Titulo} não está disponível para avaliação.");
        }
    }

    public int QtdGeneros {
        get { return Generos.Count; }
    }

    public int QtdNotas {
        get { return Notas.Count; }
    }

    public int QtdPlataformas {
        get { return Plataformas.Count; }
    }

    public string GetGenero(int idx) {
        return Generos[idx];
    }

    public Avaliacao GetAvaliacao(int idx) {
        return Notas[idx];
    }

    public string GetPlataforma(int idx) {
        return Plataformas[idx];
    }

    public void AdicionarGenero(string genero) {
        Generos.Add(genero);
    }

    public void AdicionarNota(Avaliacao nota) {
        Notas.Add(nota);
    }

    public void AdicionarPlataforma(string plataforma) {
        Plataformas.Add(plataforma);
    }
}