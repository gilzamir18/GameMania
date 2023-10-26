namespace GameMania.Menus;
using GameMania.Modelos;

internal class MenuAvaliarJogosCadastrados: Menu{
    public MenuAvaliarJogosCadastrados() : base("Avaliar Jogo Cadastrado"){

    }
    public override void ExecutarOpcao(){
        Console.Write("Informe o Nome Do Jogo a Ser Avaliado: ");
        string nome = ValidarConsulta(Console.ReadLine());
        Jogo? jogo = jogoDAO.ObterJogoPorNome(nome);
        if (jogo != null && jogo.Disponibilidade == true){
            Console.Write($"Qual Nota Voce Da ao Jogo {jogo.Nome}? ");
                int nota = ValidarNota(Console.ReadLine());
                jogo.AdicionarNota(nota);
        }else if(jogo != null && jogo.Disponibilidade == false){
            Console.WriteLine($"Jogo NAO Disponivel Para Avaliacao");
        }else{
            Console.WriteLine($"Nao Existe Jogo Cadastrado Com o Titulo: {nome}");
        }
    }
}
