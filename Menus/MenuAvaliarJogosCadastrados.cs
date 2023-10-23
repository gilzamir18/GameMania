namespace GameMania.Menus;

using GameMania.Modelos;

internal class MenuAvaliarJogosCadastrados: Menu
{

    public MenuAvaliarJogosCadastrados() : base("Avaliar Jogos Cadastrados")
    {

    }

    public override bool MostrarOpcao()
    {
        Console.Write("Informe o título do jogo a ser avaliado: ");
        var titulo = Console.ReadLine();
        titulo = string.IsNullOrEmpty(titulo)? "":titulo;
        var jogo = jogoDAO.ObterPorTitulo(titulo);
        if (jogo != null)
        {
            Console.Write($"Qual nota você dá ao jogo {titulo}? ");
            try
            {   var opcao = Console.ReadLine();
                opcao = string.IsNullOrEmpty(opcao)? "":opcao;
                Avaliacao nota = Avaliacao.Parse(opcao);
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
}
