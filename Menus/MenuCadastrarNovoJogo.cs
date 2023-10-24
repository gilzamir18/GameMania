namespace GameMania.Menus;
using GameMania.Modelos;

class MenuCadastrarNovoJogo: Menu{

    public MenuCadastrarNovoJogo(): base("Cadastrar Novo Jogo"){

    }

public override void ExecutarOpcao(){
        Console.Write("Qual o Titulo Do Jogo? ");
        string? titulo = Console.ReadLine();
        titulo = string.IsNullOrEmpty(titulo)? "":titulo;
        Console.Write("Qual o Genero Do Jogo? ");
        string? genero = Console.ReadLine();
        genero = string.IsNullOrEmpty(genero)? "":genero;
        Console.Write("Qual Studio Desenvolveu o Jogo? ");
        string? studio = Console.ReadLine();
        studio = string.IsNullOrEmpty(studio)? "":studio;
        Console.Write("Qual a Edicao do Jogo? ");
        string? edicao = Console.ReadLine();
        edicao = string.IsNullOrEmpty(edicao)? "":edicao;
        jogoDAO.SalvarJogo(new Jogo(nome:titulo,
                                    edicao:edicao,
                                    genero:genero,
                                    studio:studio));
        Console.WriteLine("Jogo Adicionado Com Sucesso");
    }
}
