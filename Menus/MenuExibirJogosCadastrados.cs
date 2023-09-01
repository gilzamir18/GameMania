namespace GameMania.Menus;

using GameMania.Modelos;

internal class MenuExibirJogosCadastrados: Menu {
    public override bool MostrarOpcao(Dictionary<string, Jogo> jogosRegistrados) {
        foreach (var jogo in jogosRegistrados.Keys) {
            var notas = jogosRegistrados[jogo];
            Console.WriteLine($"Título: {jogo}");
        }
        
        return false;
    }
}