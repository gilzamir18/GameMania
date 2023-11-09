namespace GameMania.Menus;

using GameMania.Modelos;

internal class MenuAvaliarJogosCadastrados: Menu
{

    public MenuAvaliarJogosCadastrados() : base("Avaliar Jogos Cadastrados")
    {

    }

    public override bool MostrarOpcao()
    {
        string titulo = ObterTituloValido();
        var jogo = jogoDAO.ObterPorTitulo(titulo);
        if (jogo != null)
        {
            Console.Write($"Qual nota você dá ao jogo {titulo}? ");
            try
            {
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                jogo.AdicionarNota(nota);
            } 
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine($"Não existe jogo cadastrado com o título {titulo}");

        }
        return false;
    }

    private string ObterTituloValido(){
        string titulo;
        do
        {
            Console.Clear();
            Console.Write("Informe o título do jogo: ");
             titulo = Console.ReadLine()!;
        } while (string.IsNullOrWhiteSpace(titulo));

        return titulo;
    }

    
}
