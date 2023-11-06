using Auxiliares;

namespace GameMania.Menus;

internal class AvaliarJogoCadastrado: Menu {
    public AvaliarJogoCadastrado() : base("*  Avaliar Jogos Cadastrados  *") { }

    public override bool MostrarOpcao() {
        Console.Write("Título do Jogo: ");
        var titulo = Validacoes.ObterStringValida("Título");
        var jogo = jogoDAO.BuscarJogo(titulo);

        if (jogo != null) {
            Console.Write($"Nota para {titulo}: ");
            var nota = Validacoes.ObterNotaValida();
            
            try {
                jogo.AdicionarNota(new Avaliacao(nota));
                jogoDAO.AvaliarJogo(jogo, nota);
            } catch (Exception e) {
                Console.WriteLine($"\nOcorreu um erro ao adicionar a nota:\n{e.Message}");
            }
        } else {
            Console.WriteLine($"\n{titulo} ainda não foi cadastrado.");
        }

        return false;
    }
}