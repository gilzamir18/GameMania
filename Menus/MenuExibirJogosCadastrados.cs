namespace GameMania.Menus;
using GameMania.Modelos;

internal class MenuExibirJogosCadastrados: Menu{

    public MenuExibirJogosCadastrados() : base("Exibir Jogo Cadastrado"){

    }

    public override void ExecutarOpcao(){
        List<Jogo> jogos = jogoDAO.ListarTodosOsJogos();
        foreach (Jogo jogo in jogos){
            jogo.ExibirFichaTecnica();
        }
    }
}