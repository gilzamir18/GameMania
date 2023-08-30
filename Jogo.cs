class Jogo {
    private string? titulo;
    public string? Titulo {
        get{ 
            return string.IsNullOrEmpty(titulo)?"":titulo;
        } 
        set{ 
            titulo = string.IsNullOrEmpty(value)?"":value;
        }
    }
    private string? genero;
    public string? Genero {
        get{ 
            return string.IsNullOrEmpty(genero)?"":genero;
        } 
        set{ 
            genero = string.IsNullOrEmpty(value)?"":value;
        }
    }
    private string? studio;
    public string? Studio {
        get{ 
            return string.IsNullOrEmpty(studio)?"":studio;
        } 
        set{ 
            studio = string.IsNullOrEmpty(value)?"":value;
        }
    }
    private string? edicao;
    public string? Edicao {
        get{ 
            return string.IsNullOrEmpty(edicao)?"":edicao;
        } 
        set{ 
            edicao = string.IsNullOrEmpty(value)?"":value;
        }
    }
    private string? descricao;
    public string? Descricao {
        get{ 
            return string.IsNullOrEmpty(descricao)?$"{Titulo} - {Studio}":"";
        } 
    }
    private bool disponibilidade;
    public bool Disponibilidade {
        get{ 
            return disponibilidade;
        } 
        set{ 
            disponibilidade = value;
        }
    }
    private string? plataformas;
    public string? Plataformas {
        get{ 
            return string.IsNullOrEmpty(plataformas)?"":plataformas;
        } 
        set{ 
            plataformas = string.IsNullOrEmpty(value)?"":value;
        }
    }
    private List<float> notas = new();
    public List<float>? Notas {
        get{ 
            return notas==null ? new List<float>{}:notas;
        } 
        set{ 
            notas = value==null ? new List<float>{}:value;
        }
    }
    public Jogo(string? titulo="", string? genero="", string? studio="", string? edicao="", string? descricao="", bool disponibilidade=false, string? plataformas="", List<float>? notas = null){
        Titulo = titulo;
        Genero = genero;
        Studio = studio;
        Edicao = edicao;
        this.descricao = descricao;
        Disponibilidade = disponibilidade;
        Plataformas = plataformas;
        Notas = notas ?? new List<float>(){};
    }

    public float AvaliacaoMedia {
        get {
            Notas = (Notas==null)?new List<float>{0}:Notas;
            if (Notas.Count == 0) {
                return 0;
            }
            float soma = 0;
            foreach (float nota in Notas) {
                soma += nota;
            }
            return soma/Notas.Count;
        }    
    }
    public void ExibirFichaTecnica() {
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Gênero: {Genero}");
        Console.WriteLine($"Estúdio: {Studio}");
        Console.WriteLine($"Edição: {Edicao}");
        Console.WriteLine($"Descricao: {Descricao}");
        Console.WriteLine($"Plataformas: {Plataformas}");
        Console.Write($"Notas: ");
        Notas = (Notas==null)?new List<float>{0}:Notas;
        foreach (float? nota in Notas){
            if(nota.HasValue){
                Console.Write(nota + " ");
            }
        }
        Console.WriteLine($"\nMedia: {AvaliacaoMedia:F2}");
        if(Disponibilidade) {
            Console.WriteLine("Disponível para avaliação.");
        } else {
            Console.WriteLine("Não disponível para avaliação.");
        }
    }

}



