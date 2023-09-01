using GameMania.Modelos;

namespace GameMania.Menus;

internal class Menu {

    public string Titulo {get;}

    public Menu(string titulo) {
        Titulo = titulo;
    }

    public bool Executar(Dictionary<string, Jogo> jogosRegistrados) {
        ExibirTituloDaOpcao("Cadastrar novo Jogo");
        bool sair = MostrarOpcao(jogosRegistrados);

        if (!sair)
            Rodape();
        
        return sair;
    }

    void Rodape() {
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
    }

    public virtual bool MostrarOpcao(Dictionary<string, Jogo> jogosRegistrados) {
        return false;
    }

    void ExibirTituloDaOpcao(string titulo, char preencher = '*') {
        Console.Clear();
        var barra = string.Empty.PadLeft(titulo.Length, preencher);
        Console.WriteLine(barra);
        Console.WriteLine(titulo);
        Console.WriteLine(barra);
    }
}