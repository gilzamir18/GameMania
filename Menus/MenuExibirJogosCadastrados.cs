namespace GameMania.Menus;
using GameMania.Modelos;

internal class MenuExibirJogosCadastrados: Menu{
    public MenuExibirJogosCadastrados():base(titulo:"Exibir Jogos Cadastrados"){

    }    
    public override void ExecutarOpcao(Dictionary<string, Jogo> jogosRegistrados){
        foreach (Jogo jogo in jogosRegistrados.Values){
            Console.WriteLine($"{jogo.Titulo}");
        }
    }
    }
}