namespace GameMania.Menus;
using GameMania.Modelos;

class MenuCadastrarNovoJogo: Menu{

    public MenuCadastrarNovoJogo(): base("Cadastrar Novo Jogo"){

    }

public override void ExecutarOpcao(){
        Console.Write("Nome: ");
        string? nome = Console.ReadLine();
        nome = string.IsNullOrEmpty(nome)? "":nome;

        Console.Write("Edicao: ");
        string? edicao = Console.ReadLine();    
        edicao = string.IsNullOrEmpty(edicao)? "":edicao;

        Console.Write("Descricao: ");
        string? descricao = Console.ReadLine();    
        descricao = string.IsNullOrEmpty(descricao)? "":descricao;   

        Console.Write("Genero: ");
        string? genero = Console.ReadLine();
        genero = string.IsNullOrEmpty(genero)? "":genero;

        Console.Write("Studio: ");
        string? estudio = Console.ReadLine();
        estudio = string.IsNullOrEmpty(estudio)? "":estudio;

        Console.Write("Plataforma: ");
        string? plataforma = Console.ReadLine();
        plataforma = string.IsNullOrEmpty(plataforma)? "":plataforma;

        Console.Write("Nota: ");
        string? aux = Console.ReadLine();
        aux = string.IsNullOrEmpty(aux)? "":aux;
        int nota;
        int.TryParse(aux, out nota);
        List<int> notas = new List<int>(){nota};

        jogoDAO.SalvarJogo(new Jogo(nome:nome,
                                    edicao:edicao,
                                    descricao:descricao,
                                    genero:genero,
                                    estudio:estudio,
                                    plataforma:plataforma,
                                    nota:notas
                                    ));
        Console.WriteLine("Jogo Adicionado Com Sucesso");
    }
}
