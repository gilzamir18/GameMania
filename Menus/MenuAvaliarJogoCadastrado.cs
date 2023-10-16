namespace GameMania.Menus;

using System.Diagnostics;
using GameMania.Modelos;

internal class MenuAvaliarJogoCadastrado: Menu{
    public MenuAvaliarJogoCadastrado():base(titulo:"Avaliar Jogo Cadastrado"){

    }    
    public override void ExecutarOpcao(Dictionary<string, Jogo> jogosRegistrados){
        Console.Write("Insira o Titulo do Jogo a Ser Avaliado | Digite -1 Para Cancelar: ");

        string? aux = Console.ReadLine();
        aux = string.IsNullOrEmpty(aux) ? "": aux;
        while(!jogosRegistrados.ContainsKey(aux) && aux != "-1"){
            Console.Write("Nome Invalido ou Nao Cadastrado. Tente Novamente: ");
            aux = Console.ReadLine();
            aux = string.IsNullOrEmpty(aux) ? "": aux;
        }

        if(aux != "-1"){
            Jogo? jogo = jogosRegistrados[aux];
            if(jogo.Disponibilidade == false){
                Console.WriteLine("Jogo Indisponivel Para Avaliacao.");
                return;
            }
            Console.WriteLine("Insira Notas | Digite -1 Para Cancelar: ");
            float n = 0;
            jogo.Notas = jogo.Notas == null ? new List<float>{} : jogo.Notas; //Apenas para tirar o warning
            while(n >= 0){
                aux = Console.ReadLine();
                n = ForcedValidationFloat(aux);
                if(n>=0){   
                    jogo.Notas.Add(n);
                }else{
                    n=-1;
                }
            }        
            
        }
    }
}