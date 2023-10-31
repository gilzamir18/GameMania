namespace GameMania.Menus;

using GameMania.Modelos;

class MenuCadastrarNovoJogo: Menu {

    public MenuCadastrarNovoJogo(): base("*  Cadastrar Novo Jogo  *") { }

    public override bool MostrarOpcao() {
        Console.Write("Título do jogo: ");
        var titulo = Console.ReadLine();
        Console.Write("Genero do jogo: ");
        var genero = Console.ReadLine();
        Console.Write("Studio que desenvolveu o jogo: ");
        var studio = Console.ReadLine();
        Console.Write("Edição atual do jogo: ");
        var edicao = Console.ReadLine();
        Console.Write("Descrição do jogo: ");
        var descricao = Console.ReadLine();
        jogoDAO.SalvarJogo(new Jogo(titulo, genero, studio, edicao, descricao));
        Console.WriteLine("Jogo Adicionado com sucesso");
        return false;
    }
}
