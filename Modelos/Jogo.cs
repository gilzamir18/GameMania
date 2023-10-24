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
    }  

    public Jogo(List<int> nota,
                string nome = "", 
                string edicao = "",
                string descricao = "", 
                bool disponibilidade = true,
                string genero = "", 
                string studio = "",
                string plataforma = "")
    {
        Nota = nota;
        Nome = nome;
        Edicao = edicao;
        Descricao = descricao;
        Disponibilidade = disponibilidade;
        Genero = genero;
        Studio = studio;
        Plataforma = plataforma;
    }      

    public void ExibirFichaTecnica(){
        Console.WriteLine($"Titulo: {Nome}");
        Console.WriteLine($"Edicao: {Edicao}");
        Console.WriteLine($"Descricao: {Descricao}");
        Console.WriteLine($"Genero: {Genero}");
        Console.WriteLine($"Studio: {Studio}");
        Console.WriteLine($"Edição: {Edicao}");
        Console.WriteLine($"Plataforma: {Plataforma}");
        if (Disponibilidade == true){
            Console.WriteLine("Jogo disponível para avaliação.");
        }else{
            Console.WriteLine("Este jogo não está disponível para avaliação.");
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
    public int QtdNotas{
        get{
            if(Nota==null){
                Nota = new List<int>();
            }            
            return Nota.Count;
        }
    }

    public List<int> GetAvaliacao(int idx){
        if(Nota==null){
            Nota = new List<int>();
        }             
        return Nota;
    }

    public void AdicionarNota(int nota){
        if(Nota==null){
            Nota = new List<int>();
        }                 
        Nota.Add(nota);
    }

}
