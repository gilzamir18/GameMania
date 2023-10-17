namespace GameMania.Menus;

using System.Diagnostics;
using GameMania.Modelos;

internal class MenuAvaliarJogoCadastrado: Menu{
    public MenuAvaliarJogoCadastrado():base(titulo:"Avaliar Jogo Cadastrado"){

    }    
    public override void ExecutarOpcao(){
        Console.Write("Insira o Titulo do Jogo a Ser Avaliado | Digite -1 Para Cancelar: ");

        string? aux = Console.ReadLine();
        aux = string.IsNullOrEmpty(aux) ? "": aux;
        while((jogoDAO?.JogoPorTitulo(aux) == null) && aux != "-1"){
            Console.Write("Nome Invalido ou Nao Cadastrado. Tente Novamente: ");
            aux = Console.ReadLine();
            aux = string.IsNullOrEmpty(aux) ? "": aux;
        }

        if(aux != "-1"){
            Jogo? jogo = jogoDAO?.JogoPorTitulo(aux);
            if(jogo?.Disponibilidade == false){
                Console.WriteLine("Jogo Indisponivel Para Avaliacao.");
                return;
            }
            Console.WriteLine("Insira Notas | Digite -1 Para Cancelar: ");
            var n = 0;
            
            while(n >= 0){
                aux = Console.ReadLine();
                int.TryParse(aux, out n);
                if(n>=0){
                    Avaliacao avaliacao = new Avaliacao(n);
                    jogo.notas.Add(avaliacao);
                }else{
                    n=-1;
                }
            }
            jogoDAO?.SalvarJogo(jogo);   
            
        }
    }
}