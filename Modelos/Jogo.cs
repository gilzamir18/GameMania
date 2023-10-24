namespace GameMania.Modelos;

public class Jogo{
    private string? nome;
    public string? Nome{
        get{
            return nome;
        }
        set{
            nome = string.IsNullOrEmpty(value)?"":value;
        }
    }
    private string? edicao;
    public string? Edicao{
        get{
            return edicao;
        }
        set{
            edicao = string.IsNullOrEmpty(value)? "":value;
        }
    }
    private string? descricao;
    public string? Descricao{
        get{
            return descricao;
        }
        set{
            descricao = string.IsNullOrEmpty(value)? "":value;
        }
    }    
    private bool disponibilidade = true;
    public bool Disponibilidade{
        get{
            return disponibilidade;
        }
        set{
            disponibilidade = value;
        }
    }
    private string? genero;
    public string? Genero{
        get{
            return genero;
        }
        set{
            genero = string.IsNullOrEmpty(value)? "":value;
        }
    }    
    private string? studio;
    public string? Studio{
        get{
            return studio;
        }
        set{
            studio = string.IsNullOrEmpty(value)? "":value;
        }
    }        
    private string? plataforma;
    public string? Plataforma{
        get{
            return plataforma;
        }
        set{
            plataforma = string.IsNullOrEmpty(value)? "":value;
        }
    }     
    private List<Avaliacao>? nota;
    public List<Avaliacao>? Nota{
        get{
            return nota;
        }
        set{
            if(value == null){
                nota = new List<Avaliacao>();
            }else{
                nota = value;
            }
        }
    }         
    public float NotaMedia{
        get{
            if(nota==null){
                nota = new List<Avaliacao>();
            }
            if (nota.Count > 0){
                return (float)nota.Average( a => a.Nota );
            }else{
                return 0;
            }

        }
    }
    public Jogo(string nome = "", 
                string edicao = "",
                string descricao = "", 
                bool disponibilidade = true,
                string genero = "", 
                string studio = "",
                string plataforma = "")
    {
        Nome = nome;
        Edicao = edicao;
        Descricao = descricao;
        Disponibilidade = disponibilidade;
        Genero = genero;
        Studio = studio;
        Plataforma = plataforma;
        Nota = new List<Avaliacao>();
    }

    public void ExibirFichaTecnica(){
        Console.WriteLine($"Titulo: {Nome}");
        Console.WriteLine($"Genero: {Genero}");
        Console.WriteLine($"Edição: {Edicao}");
        Console.WriteLine($"Plataforma: {Plataforma}");
        Console.WriteLine();
        
        if (Disponibilidade){
            Console.WriteLine("Jogo disponível para avaliação.");
        }else{
            Console.WriteLine("Este jogo não está disponível para avaliação.");
        }
    }

    public int QtdNotas{
        get{
            if(Nota==null){
                Nota = new List<Avaliacao>();
            }            
            return Nota.Count;
        }
    }

    public Avaliacao GetAvaliacao(int idx){
        if(Nota==null){
            Nota = new List<Avaliacao>();
        }             
        return Nota[idx];
    }

    public void AdicionarNota(Avaliacao nota){
        if(Nota==null){
            Nota = new List<Avaliacao>();
        }                 
        Nota.Add(nota);
    }

}
