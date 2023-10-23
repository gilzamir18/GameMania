namespace GameMania.Menus;

using GameMania.Modelos;

class MenuCadastrarNovoJogo: Menu {

    public MenuCadastrarNovoJogo(): base("*  Cadastrar Novo Jogo  *") { }

    public override bool MostrarOpcao() {
        Console.Write("Qual o título do jogo? ");
        var titulo = Console.ReadLine();
        Console.Write("Qual o genero do jogo? ");
        var genero = Console.ReadLine();
        Console.Write("Qual studio desenvolveu o jogo? ");
        var studio = Console.ReadLine();
        Console.Write("Qual a edição do jogo? ");
        var edicao = Console.ReadLine();
        jogoDAO.SalvarJogo(new Jogo(titulo, genero, studio, edicao));
        Console.WriteLine("Jogo Adicionado com sucesso");
        return false;
    }
}
