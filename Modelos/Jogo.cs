namespace GameMania.Modelos;
using System.Globalization;

public class Jogo{
    private string? nome;
    public string? Nome{
        get{
            nome = string.IsNullOrEmpty(nome)?"":nome;
            return nome;
        }
        set{
            nome = string.IsNullOrEmpty(value)?"":value.ToLower();
        }
    }
    private string? edicao;
    public string? Edicao{
        get{
            edicao = string.IsNullOrEmpty(edicao)?"":edicao;
            return edicao;
        }
        set{
            edicao = string.IsNullOrEmpty(value)? "":value.ToLower();
        }
    }
    private string? descricao;
    public string? Descricao{
        get{
            descricao = string.IsNullOrEmpty(descricao)?"":descricao;
            return descricao;
        }
        set{
            descricao = string.IsNullOrEmpty(value)? "":value.ToLower();
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
            genero = string.IsNullOrEmpty(genero)?"":genero;
            return genero;
        }
        set{
            genero = string.IsNullOrEmpty(value)? "":value.ToLower();
        }
    }    
    private string? estudio;
    public string? Estudio{
        get{
            estudio = string.IsNullOrEmpty(estudio)?"":estudio;
            return estudio;
        }
        set{
            estudio = string.IsNullOrEmpty(value)? "":value.ToLower();
        }
    }        
    private string? plataforma;
    public string Plataforma{
        get{
            plataforma = string.IsNullOrEmpty(plataforma)?"":plataforma;
            return plataforma;
        }
        set{
            plataforma = string.IsNullOrEmpty(value)? "":value.ToLower();
        }
    }     
    private List<int>? nota;
    public List<int>? Nota{
        get{
            nota = nota == null? new List<int>():nota;
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
        Nome = nome.ToLower();
        Edicao = edicao;
        Descricao = descricao;
        Disponibilidade = disponibilidade;
        Genero = genero;
        Estudio = estudio;
        Plataforma = plataforma;
        Nota = nota;
    }     

    public void ExibirFichaTecnica(){
        TextInfo txt = new CultureInfo("pt-BR").TextInfo;
        Nome = string.IsNullOrEmpty(Nome)?"":Nome;
        Console.WriteLine($"Titulo: {txt.ToTitleCase(Nome)}");

        Edicao = string.IsNullOrEmpty(Edicao)?"":Edicao;
        Console.WriteLine($"Edicao: {txt.ToTitleCase(Edicao)}");

        Descricao = string.IsNullOrEmpty(Descricao)?"":Descricao;
        Console.WriteLine($"Descricao: {txt.ToTitleCase(Descricao)}");

        Genero = string.IsNullOrEmpty(Genero)?"":Genero;
        Console.WriteLine($"Genero: {txt.ToTitleCase(Genero)}");

        Estudio = string.IsNullOrEmpty(Estudio)?"":Estudio;
        Console.WriteLine($"Estudio: {txt.ToTitleCase(Estudio)}");

        Plataforma = string.IsNullOrEmpty(Plataforma)?"":Plataforma;
        Console.WriteLine($"Plataforma: {txt.ToTitleCase(Plataforma)}");

        if (Disponibilidade == true){
            Console.WriteLine("Jogo Disponivel Para Avaliacao");
        }else{
            Console.WriteLine("Jogo NAO Disponivel Para Avaliacao");
        }
        Console.WriteLine();
    }

    public void AdicionarNota(int nota){
        Nota = Nota == null ? new List<int>():Nota; //Warning
        Nota.Add(nota);
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
            soma /= Nota.Count;
            return (int)Math.Round(soma);
        }else{
            Console.WriteLine("Nao Ha Notas Cadastradas");
        }
        return 0;
    }

 

}
