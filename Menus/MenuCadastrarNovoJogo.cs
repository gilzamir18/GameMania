using GameMania.Modelos;
using Auxiliares;

namespace GameMania.Menus;

class MenuCadastrarNovoJogo: Menu {

    public MenuCadastrarNovoJogo(): base("*  Cadastrar Novo Jogo  *") { }

    public override bool MostrarOpcao() {
        string titulo = Validacoes.ObterStringValida("Título do jogo: ");
        string genero = Validacoes.ObterStringValida("Gênero do jogo: ");
        string studio = Validacoes.ObterStringValida("Estúdio do jogo: ");
        string edicao = Validacoes.ObterEdicaoValida("Edição do jogo: ");
        
        Console.Write("Descrição do jogo (opcional): ");
        string descricao = Console.ReadLine()?.Trim();

        Console.Write("Plataformas do jogo (separadas por vírgula): ");
        string plataformasInput = Validacoes.ObterStringValida("Plataformas do jogo (separadas por vírgula): ");

        var plataformas = string.IsNullOrWhiteSpace(plataformasInput)
            ? new List<string>()
            : plataformasInput.Split(',').Select(s => s.Trim()).ToList();

        var jogo = new Jogo(titulo, genero, studio, edicao);

        if (!string.IsNullOrWhiteSpace(descricao)) {
            jogo.Descricao = descricao;
        }

        foreach (var plataforma in plataformas) {
            jogo.AdicionarPlataforma(plataforma);
        }

        try {
            jogoDAO.SalvarJogo(jogo);
            Console.WriteLine("Jogo adicionado com sucesso!");
        } catch (FormatException e) {
            Console.WriteLine($"Erro ao salvar o jogo!\n{e.Message}");
        }

        return false;
    }
}