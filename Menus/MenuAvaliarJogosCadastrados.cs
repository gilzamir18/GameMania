namespace GameMania.Menus;

using GameMania.Modelos;

internal class MenuAvaliarJogosCadastrados: Menu
{

    public MenuAvaliarJogosCadastrados() : base("Avaliar Jogos Cadastrados") {}

    public override bool MostrarOpcao(Dictionary<string, Jogo> jogosRegistrados)
    {
        Console.Write("Informe o título do jogo a ser avaliado: ");
        var titulo = Console.ReadLine();
        if (jogosRegistrados.ContainsKey(titulo))
        {
            Console.Write($"Qual nota você dá ao jogo {titulo}? ");
            try
            {
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine());
                jogosRegistrados[titulo].AdicionarNota(nota);
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
