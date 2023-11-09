namespace GameMania.Menus;

using System.CodeDom;
using GameMania.Modelos;

class MenuCadastrarNovoJogo: Menu
{
    public MenuCadastrarNovoJogo(): base("Cadatrar um novo jogo"){}
    public override bool MostrarOpcao()
{
    Console.Write("Qual o título do jogo? ");
    var titulo = Console.ReadLine();
    Console.Write("Qual o genero do jogo? ");
    var genero = Console.ReadLine();
    Console.Write("Qual studio desenvolveu o jogo? ");
    var studio = Console.ReadLine();
    Console.Write("Qual a edição do jogo? ");
    var edicao = Console.ReadLine();
    Console.Write("Coloque uma descrição para o jogo? ");
    var descricao = Console.ReadLine();

    if (string.IsNullOrEmpty(titulo))
    {
        titulo = "Título Desconhecido"; // Ou outro valor padrão de sua escolha.
    }

    if (string.IsNullOrEmpty(genero))
    {
        genero = "Gênero Desconhecido"; // Valor padrão para gênero.
    }

    if (string.IsNullOrEmpty(studio))
    {
        studio = "Estúdio Desconhecido"; // Valor padrão para estúdio.
    }

    if (string.IsNullOrEmpty(edicao))
    {
        edicao = "Edição Desconhecida"; // Valor padrão para edição.
    }

    // Crie o objeto Jogo com as informações coletadas
    var jogo = new Jogo(titulo, genero, studio, edicao, descricao);

    // Colete informações sobre as plataformas
    var plataformas = new List<string>();
    string plataforma;

    // Use um loop para permitir que o usuário adicione múltiplas plataformas
    while (true)
    {
        Console.Write("Informe uma plataforma do jogo (ou pressione Enter para finalizar): ");
        plataforma = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(plataforma))
        {
            break; // Se o usuário pressionar Enter, saia do loop
        }

        plataformas.Add(plataforma);
    }

    // Adicione as plataformas ao objeto Jogo
    foreach (var plat in plataformas)
    {
        jogo.AdicionarPlataforma(plat);
    }

    // Salve o jogo no banco de dados
    jogoDAO.SalvarJogo(jogo);

    Console.WriteLine("Jogo Adicionado com sucesso");
    return false;
}

}
