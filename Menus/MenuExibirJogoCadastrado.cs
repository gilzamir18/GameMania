namespace GameMania.Menus;
using GameMania.Modelos;

internal class MenuExibirJogoCadastrado: Menu{

    public MenuExibirJogoCadastrado() : base("Exibir Jogo Cadastrado"){

    }

    public override void ExecutarOpcao(){
        List<Jogo> jogos = jogoDAO.ListarTodosOsJogos();
        foreach (Jogo jogo in jogos){
            jogo.ExibirFichaTecnica();
        }
    }
}