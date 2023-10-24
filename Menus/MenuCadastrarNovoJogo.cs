namespace GameMania.Menus;
using GameMania.Modelos;

class MenuCadastrarNovoJogo: Menu{

    public MenuCadastrarNovoJogo(): base("Cadastrar Novo Jogo"){

    }

public override void ExecutarOpcao(){
        Console.Write("Qual o título do jogo? ");
        string? titulo = Console.ReadLine();
        titulo = string.IsNullOrEmpty(titulo)? "":titulo;
        Console.Write("Qual o genero do jogo? ");
        string? genero = Console.ReadLine();
        genero = string.IsNullOrEmpty(genero)? "":genero;
        Console.Write("Qual studio desenvolveu o jogo? ");
        string? studio = Console.ReadLine();
        studio = string.IsNullOrEmpty(studio)? "":studio;
        Console.Write("Qual a edição do jogo? ");
        string? edicao = Console.ReadLine();
        edicao = string.IsNullOrEmpty(edicao)? "":edicao;
        jogoDAO.SalvarJogo(new Jogo(nome:titulo,
                                    edicao:edicao,
                                    genero:genero,
                                    studio:studio));
        Console.WriteLine("Jogo Adicionado com sucesso");
    }
}
