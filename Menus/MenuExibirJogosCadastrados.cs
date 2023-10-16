namespace GameMania.Menus;
using GameMania.Modelos;

internal class MenuExibirJogosCadastrados: Menu{
    public MenuExibirJogosCadastrados():base(titulo:"Exibir Jogos Cadastrados"){

    }    
    public override void ExecutarOpcao(){
        List<Jogo>? jogos = jogoDAO?.ExibirJogosCadastrados();
        if (jogos != null){
            foreach (Jogo jogo in jogos){
                Console.WriteLine($"{jogo.Titulo}");
            }
        }else{
            Console.WriteLine("Nenhum jogo disponível.");
        }
    }
}