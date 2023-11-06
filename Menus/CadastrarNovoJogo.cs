using GameMania.Modelos;
using Auxiliares;

namespace GameMania.Menus;

class CadastrarNovoJogo : Menu {

    public CadastrarNovoJogo() : base("*  Cadastrar Novo Jogo  *") { }

    public override bool MostrarOpcao() {
        string titulo = Validacoes.ObterStringValida("Título do jogo: ", "Título");
        var jogo = jogoDAO.BuscarJogo(titulo);

        if (jogo != null) {
            Console.WriteLine($"Já existe um jogo com o título '{titulo}' cadastrado.");
        } else {
            string generosInput = Validacoes.ObterStringValida("Gêneros do jogo (Separados por vírgula): ", "Gênero");
            var generos = generosInput.Split(',').Select(g => g.Trim()).ToList();

            string estudio = Validacoes.ObterStringValida("Estúdio do jogo: ", "Estúdio");
            
            string edicao = Validacoes.ObterStringValida("Edição do jogo: ", "Edição", 1);

            Console.Write("Descrição do jogo (opcional): ");
            string? descricao = Console.ReadLine()?.Trim();

            string plataformasInput = Validacoes.ObterStringValida("Plataformas do jogo (separadas por vírgula): ", "Plataforma", 2);
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
                Console.WriteLine("Jogo adicionado com sucesso!");
            } catch (Exception e) {
                Console.WriteLine($"Erro ao salvar o jogo!\n{e.Message}");
            }
        }

        return false;
    }
}