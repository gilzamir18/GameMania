namespace GameMania.Menus;
using GameMania.Modelos;

internal class MenuExibirDetalhesDoJogo: Menu{
    public MenuExibirDetalhesDoJogo():base(titulo:"Exibir Detalhes Do Jogo"){

    }    
    public override void ExecutarOpcao(){
        string? aux = "0";
        while(aux != "-1"){
            Console.Write("Informe o Título Do Jogo | Digite -1 Para Cancelar: ");
            aux = Console.ReadLine();
            aux = string.IsNullOrEmpty(aux) ?"": aux;
            if(aux == "-1"){
                break;
            }
            Jogo? jogo = jogoDAO?.JogoPorTitulo(aux);
            if(jogo == null){
                Console.WriteLine("Titulo Nao Encontrado");
            }else{
                jogo.ExibirFichaTecnica();
                Console.WriteLine("");
            }             
        }
    }
}