using GameMania.Modelos;
using GameMania.Dados;
namespace GameMania.Menus;

internal class Menu 
{

    public string Titulo {get;}

    protected IJogoDAO jogoDAO;

    public Menu(string titulo)
    {
        Titulo = titulo;
        jogoDAO = JogoMemDAO.GetInstance();
    }

    public bool Executar()
    {
            ExibirTituloDaOpcao("Cadastrar novo Jogo");
            bool sair = MostrarOpcao();
            if (!sair)
            {
                Rodape();
            }
            return sair;
    }

    void Rodape()
    {
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
    }

    public virtual bool MostrarOpcao()
    {
        return false;
    }

    void ExibirTituloDaOpcao(string titulo, char preencher='*')
    {
        Console.Clear();
        var barra = string.Empty.PadLeft(titulo.Length, preencher);
        Console.WriteLine(barra);
        Console.WriteLine(titulo);
        Console.WriteLine(barra);
    }

}