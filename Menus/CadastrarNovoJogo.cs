using GameMania.Modelos;
using Auxiliares;

namespace GameMania.Menus;

class CadastrarNovoJogo : Menu {
    public CadastrarNovoJogo() : base("*  Cadastrar Novo Jogo  *") { }

    public override bool MostrarOpcao() {
        Console.Write("Título do Jogo: ");
        string titulo = Validacoes.ObterStringValida("Título");
        var jogo = jogoDAO.BuscarJogo(titulo);

        if (jogo != null) {
            Console.WriteLine($"\n{titulo} já foi cadastrado.");
        } else {
            Console.Write("Gêneros do Jogo (separados por vírgula): ");
            string generosInput = Validacoes.ObterStringValida("Gênero");
            var generos = generosInput.Split(',').Select(g => g.Trim()).ToList();

            Console.Write("Estúdio do Jogo: ");
            string estudio = Validacoes.ObterStringValida("Estúdio");
            
            Console.Write("Edição do Jogo: ");
            string edicao = Validacoes.ObterStringValida("Edição", 1);

            Console.Write("Descrição do jogo (opcional): ");
            string? descricao = Console.ReadLine()?.Trim();

            Console.Write("Plataformas do Jogo (separadas por vírgula): ");
            string plataformasInput = Validacoes.ObterStringValida("Plataforma", 2);
            var plataformas = plataformasInput.Split(',').Select(p => p.Trim()).ToList();

            jogo = new Jogo(titulo, estudio, edicao);

            foreach (var genero in generos) {
                jogo.AdicionarGenero(genero);
            }

            if (!string.IsNullOrWhiteSpace(descricao)) {
                jogo.Descricao = descricao;
            }

            foreach (var plataforma in plataformas) {
                jogo.AdicionarPlataforma(plataforma);
            }

            try {
                jogoDAO.SalvarJogo(jogo);
                Console.WriteLine($"{titulo} foi adicionado com sucesso!");
            } catch (Exception e) {
                Console.WriteLine($"Ocorreu um erro ao salvar {titulo}:\n{e.Message}");
            }
        }

        return false;
    }
}