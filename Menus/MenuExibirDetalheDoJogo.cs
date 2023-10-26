namespace GameMania.Menus;
using GameMania.Modelos;
internal class MenuExibirDetalheDoJogo: Menu{

    public MenuExibirDetalheDoJogo() : base("Exibir Detalhe de Jogo"){
        
    }
public override void ExecutarOpcao(){
        Console.Write("Informe o Titulo Do Jogo: ");
        string nome = ValidarConsulta(Console.ReadLine());
        Jogo? jogo = jogoDAO.ObterJogoPorNome(nome);
        if (jogo != null){
            Console.WriteLine($"A Media De Avaliacao Do Jogo {jogo.Nome} e: {jogo.NotaMedia()}");
        }else{
            Console.WriteLine($"Nao Existe Jogo Com o Titulo {nome}");
        }
    }
}