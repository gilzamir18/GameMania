namespace GameMania.Menus;
using GameMania.Modelos;

internal class MenuAvaliarJogosCadastrados: Menu{
    public MenuAvaliarJogosCadastrados() : base("Avaliar Jogo Cadastrado"){

    }
    public override void ExecutarOpcao(){
        Console.Write("Informe o Nome Do Jogo a Ser Avaliado: ");
        string? nome = Console.ReadLine();
        nome = string.IsNullOrEmpty(nome)?"":nome;
        Jogo? jogo = jogoDAO.ObterJogoPorNome(nome);
        if (jogo != null && jogo.Disponibilidade == true){
            Console.Write($"Qual Nota Voce Da ao Jogo {jogo.Nome}? ");
            try{   
                string? opcao = Console.ReadLine();
                opcao = string.IsNullOrEmpty(opcao)? "":opcao;
                int nota = int.Parse(opcao);
                jogo.Nota = jogo.Nota == null ? new List<int>():jogo.Nota;
                jogo.Nota.Add(nota);
            }catch(FormatException e){
                Console.WriteLine(e.Message);
            }
        }else{
            Console.WriteLine($"Nao Existe Jogo Cadastrado Com o Titulo {nome} ( Ou Disponivel Para Avaliacao)");
        }
    }
}
