using Auxiliares;

namespace GameMania.Menus;

internal class AvaliarJogosCadastrados: Menu {
    
    public AvaliarJogosCadastrados() : base("*  Avaliar Jogos Cadastrados  *") { }

    public override bool MostrarOpcao() {
        var titulo = Validacoes.ObterStringValida("Informe o título do jogo a ser avaliado: ");
        var jogo = jogoDAO.BuscarJogo(titulo);

        if (jogo != null) {
            var nota = Validacoes.ObterNotaValida($"Sua nota para o jogo '{titulo}'? ");
            var jogoID = jogo.ID;
            
            try {
                jogo.AdicionarNota(new Avaliacao(nota));
                jogoDAO.AvaliarJogo(jogoID, nota);
            } catch (Exception ex) {
                Console.WriteLine($"Ocorreu um erro ao adicionar a nota: {ex.Message}");
            }
        } else {
            Console.WriteLine($"\nNão existe um jogo cadastrado com o título '{titulo}'");
        }

        return false;
    }
}