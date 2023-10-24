namespace GameMania.Menus;

internal class MenuExibirJogoCadastrado: Menu{

    public MenuExibirJogoCadastrado() : base("Exibir Jogo Cadastrado"){

    }

    public override void ExecutarOpcao(){
        var jogos = jogoDAO.ListarTodosOsJogos();
        foreach (var jogo in jogos){
            jogo.ExibirFichaTecnica();
        }
    }
}