namespace GameMania.Menus;
using GameMania.Modelos;

internal class MenuAvaliarJogosCadastrados: Menu{
    public MenuAvaliarJogosCadastrados() : base("Avaliar Jogo Cadastrado"){

    }
    public override void ExecutarOpcao(){
        Console.Write("Informe o Titulo Do Jogo a Ser Avaliado: ");
        string? titulo = Console.ReadLine();
        titulo = string.IsNullOrEmpty(titulo)? "":titulo;
        Jogo? jogo = jogoDAO.ObterJogoPorTitulo(titulo);
        if (jogo != null && jogo.Disponibilidade == true){
            Console.Write($"Qual Nota Voce Da ao Jogo {titulo}? ");
            try{   
                var opcao = Console.ReadLine();
                opcao = string.IsNullOrEmpty(opcao)? "":opcao;
                int nota = int.Parse(opcao);
                jogo.Nota = jogo.Nota == null ? new List<int>():jogo.Nota;
                jogo.Nota.Add(nota);
            }catch(FormatException e){
                Console.WriteLine(e.Message);
            }
        }else{
            Console.WriteLine($"Nao Existe Jogo Cadastrado Com o Titulo {titulo} ( Ou Disponivel Para Avaliacao)");
        }
    }
}
