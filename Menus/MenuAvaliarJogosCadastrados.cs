using Auxiliares;

namespace GameMania.Menus;

internal class MenuAvaliarJogosCadastrados: Menu {
    
    public MenuAvaliarJogosCadastrados() : base("*  Avaliar Jogos Cadastrados  *") { }

    public override bool MostrarOpcao() {
        var titulo = Validacoes.ObterStringValida("Informe o título do jogo a ser avaliado: ");
        var jogo = jogoDAO.ObterPorTitulo(titulo);

        if (jogo != null) {
            var nota = Validacoes.ObterNotaValida($"Qual nota você dá ao jogo {titulo}? ");
            jogo.AdicionarNota(new Avaliacao(nota));
        } else {
            Console.WriteLine($"\nNão existe um jogo cadastrado com o título '{titulo}'");
        }

        return false;
    }
}