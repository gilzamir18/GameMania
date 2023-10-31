namespace GameMania.Menus;

using GameMania.Modelos;

class MenuCadastrarNovoJogo: Menu {

    public MenuCadastrarNovoJogo(): base("*  Cadastrar Novo Jogo  *") { }
    
    public override bool MostrarOpcao() {
        string titulo;
        do {
            Console.Write("Título do jogo: ");
            titulo = Console.ReadLine();
        } while (!ValidaEntrada(titulo));

        string genero = "";
        do {
            Console.Write("Genero do jogo: ");
            genero = Console.ReadLine();
        } while (!ValidaEntrada(genero));

        string studio = "";
        do {
            Console.Write("Studio do jogo: ");
            studio = Console.ReadLine();
        } while (!ValidaEntrada(studio));

        Console.Write("Edição atual do jogo: ");
        var edicao = Console.ReadLine();
        while (edicao == "" || edicao.All(char.IsWhiteSpace)) {
            edicao = Console.ReadLine();

            if (edicao =="" || edicao.All(char.IsWhiteSpace)) {
                Console.WriteLine("A entrada deve ser preenchida, não pode ser apenas espaço em branco e deve ter pelo menos 3 caracteres.");
            }
        }

        var jogo = new Jogo(titulo, genero, studio, edicao);

        try {
            jogoDAO.SalvarJogo(jogo);
        } catch (FormatException e) {
            Console.WriteLine($"Erro ao salvar o jogo!\n{e.Message}");
        }

        //Console.WriteLine("Jogo Adicionado com sucesso");
        
        return false;
    }

    private bool ValidaEntrada(string entrada) {
        if (entrada == "" || entrada.All(char.IsWhiteSpace) || entrada.Length < 3) {
            Console.WriteLine("Entrada Inválida!\nA entrada deve ser preenchida, não pode ser apenas espaço em branco e deve ter pelo menos 3 caracteres.");
            return false;
        }

        return true;
    }

    /* public override bool MostrarOpcao() {
        Console.Write("Título do jogo: ");
        var titulo = Console.ReadLine();
        Console.Write("Genero do jogo: ");
        var genero = Console.ReadLine();
        Console.Write("Studio que desenvolveu o jogo: ");
        var studio = Console.ReadLine();
        Console.Write("Edição atual do jogo: ");
        var edicao = Console.ReadLine();
        jogoDAO.SalvarJogo(new Jogo(titulo, genero, studio, edicao));
        Console.WriteLine("Jogo Adicionado com sucesso");
        return false;
    } */
}
