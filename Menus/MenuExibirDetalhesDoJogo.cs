namespace GameMania.Menus;

internal class MenuExibirDetalhesDoJogo: Menu{

    public MenuExibirDetalhesDoJogo() : base("Exibir Detalhe de Jogo"){
        
    }
public override void ExecutarOpcao(){
        Console.Write("Informe o Titulo Do Jogo: ");
        
        string? titulo = Console.ReadLine();
        titulo = string.IsNullOrEmpty(titulo)? "":titulo;
        var jogo = jogoDAO.ObterJogoPorTitulo(titulo);
        if (jogo != null){
            float media = jogo.NotaMedia();
            Console.WriteLine($"A Media De Avaliacao Do Jogo {titulo} e: {media:F2}");
        }else{
            Console.WriteLine($"Nao Existe Um Jogo Com o Titulo {titulo}");
        }
    }
}