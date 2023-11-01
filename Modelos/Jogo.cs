namespace GameMania.Modelos;

public class Jogo {
    public string Titulo {get; set;}
    public string Genero {get; set;}
    public string Studio{get; set;}
    public string Edicao{get; set;}
    public string Descricao {get; set;} 
    public bool Disponibilidade {get;}
    
    private List<string> plataformas;
    private List<Avaliacao> notas;

    public float NotaMedia {
        get {
            if (notas.Count > 0) {
                return (float)notas.Average( a => a.Nota );
            } else {
                return 0;
            }
        }
    }

    public Jogo(string titulo, string genero, string studio, string edicao, bool disponilidade = true) {
        Titulo = titulo;
        Genero = genero;
        Studio = studio;
        Edicao = edicao;
        Disponibilidade = disponilidade;
        plataformas = new();
        notas = new();
    }

    public void ExibirFichaTecnica() {
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Genero: {Genero}");
        Console.WriteLine($"Studio: {Studio}");
        Console.WriteLine($"Edição: {Edicao}");
        if (Descricao != null && !string.IsNullOrWhiteSpace(Descricao)) {
            Console.WriteLine($"Descrição: {Descricao}");
        }
        Console.Write("Plataformas Suportadas:\t");
        var plataformasStr = string.Join(", ", plataformas);
        Console.WriteLine($"{plataformasStr[..]}.");

        if (Disponibilidade) {
            if (NotaMedia > 0) {
                Console.WriteLine($"Nota Média: {NotaMedia:N2}");
            }

            Console.WriteLine("\nJogo disponível para avaliação.");
        } else {
            Console.WriteLine("\nEste jogo não está disponível para avaliação.");
        }
    }

    public int QtdNotas {
        get {
            return notas.Count;
        }
    }

    public int QtdPlataformas {
        get {
            return plataformas.Count;
        }
    }

    public Avaliacao GetAvaliacao(int idx) {
        return notas[idx];
    }

    public string GetPlataforma(int idx) {
        return plataformas[idx];
    }

    public void AdicionarNota(Avaliacao nota) {
        notas.Add(nota);
    }

    public void AdicionarPlataforma(string plataforma) {
        plataformas.Add(plataforma);
    }
}