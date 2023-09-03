namespace GameMania.Menus;
using GameMania.Modelos;

internal class MenuExibirDetalhesDoJogo: Menu{
    public MenuExibirDetalhesDoJogo():base(titulo:"Exibir Detalhes Do Jogo"){

    }    
    public override async Task ExecutarOpcao(Dictionary<string, Jogo> jogosRegistrados){
        string? aux = "0";
        while(aux != "-1"){
            Console.Write("Informe o Título Do Jogo | Digite -1 Para Cancelar: ");
            aux = Console.ReadLine();
            aux = string.IsNullOrEmpty(aux) ?"": aux;
            if(aux == "-1"){
                break;
            }
            if(!jogosRegistrados.ContainsKey(aux)){
                Console.WriteLine("Titulo Nao Encontrado");
            }else{
                jogosRegistrados[aux].ExibirFichaTecnica();
                Console.WriteLine("");
            }             
        }
        await Task.Delay(0);//Remover Warning
    }
}