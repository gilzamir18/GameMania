namespace GameMania.Menus;

internal class MenuExibirDetalhesDoJogo: Menu{

    public MenuExibirDetalhesDoJogo() : base("Exibir Detalhe de Jogo"){
        
    }

    public override bool MostrarOpcao(){
        Console.Write("Informe o título do jogo: ");
        
        string? titulo = Console.ReadLine();
        titulo = string.IsNullOrEmpty(titulo)? "":titulo;
        var jogo = jogoDAO.ObterJogoPorTitulo(titulo);
        if (jogo != null){
            Console.WriteLine($"A média de avaliação do jogo {titulo} é: {jogo.NotaMedia}");
        }else{
            Console.WriteLine($"Não existe um jogo com o título {titulo}");
        }
        return false;
    }
}