using GameMania.Dados;

namespace GameMania.Menus;
internal class Menu {
    public string Titulo {get;}

    protected IJogoDAO jogoDAO;

    public Menu(string titulo) {
        Titulo = titulo;
        jogoDAO = SQLiteDAO.GetInstance();
    }

    public bool Executar() {
        ExibirTituloDaOpcao(Titulo);
        bool sair = MostrarOpcao();

        if (!sair)
            Rodape();
        
        return sair;
    }

    static void Rodape() {
        Console.Write("Pressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
    }

    public virtual bool MostrarOpcao() {
        return false;
    }

    static void ExibirTituloDaOpcao(string titulo, char preencher = '*') {
        Console.Clear();
        var barra = string.Empty.PadLeft(titulo.Length, preencher);
        Console.WriteLine(barra);
        Console.WriteLine(titulo);
        Console.WriteLine(barra);
        Console.WriteLine();
    }
}