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
    private string? estudio;
    public string? Estudio{
        get{
            return estudio;
        }
        set{
            estudio = string.IsNullOrEmpty(value)? "":value;
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
    private List<int>? nota;
    public List<int>? Nota{
        get{
            return nota;
        }
        set{
            if(value == null){
                nota = new List<int>();
            }else{
                nota = value;
            }
        }
    }         

    public Jogo(string nome = "", 
                string edicao = "",
                string descricao = "", 
                bool disponibilidade = true,
                string genero = "", 
                string estudio = "",
                string plataforma = "",
                List<int>? nota = null)
    {
        Nome = nome;
        Edicao = edicao;
        Descricao = descricao;
        Disponibilidade = disponibilidade;
        Genero = genero;
        Estudio = estudio;
        Plataforma = plataforma;
        Nota = nota;
    }     

    public void ExibirFichaTecnica(){
        Console.WriteLine($"Titulo: {Nome}");
        Console.WriteLine($"Edicao: {Edicao}");
        Console.WriteLine($"Descricao: {Descricao}");
        Console.WriteLine($"Genero: {Genero}");
        Console.WriteLine($"Estudio: {Estudio}");
        Console.WriteLine($"Edição: {Edicao}");
        Console.WriteLine($"Plataforma: {Plataforma}");
        if (Disponibilidade == true){
            Console.WriteLine("Jogo Disponivel Para Avaliacao");
        }else{
            Console.WriteLine("Jogo NAO Disponivel Para Avaliacao");
        }
        Console.WriteLine();
    }

    public float NotaMedia(){
        if(Nota == null){
            Console.WriteLine("Nao Ha Notas Cadastradas");
            return 0;
        }
        float soma = 0;
        if(Nota.Count > 0){
            foreach (int nota in Nota){
                soma += nota;
            }
            soma /=Nota.Count;
            return soma;
        }else{
            Console.WriteLine("Nao Ha Notas Cadastradas");
        }
        return 0;
    }

}
