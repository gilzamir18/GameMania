namespace GameMania.Menus;
using GameMania.Modelos;
internal class Menu {
    public string Titulo {get;set;}
    public Menu(string titulo = ""){
        Titulo = titulo;
    }
    public virtual async Task ExecutarMenu(Dictionary<string, Jogo> jogosRegistrados){
        ExibirTituloDaOpcao(Titulo);
        await ExecutarOpcao(jogosRegistrados);
        Rodape();
    }
    public virtual async Task ExecutarOpcao(Dictionary<string, Jogo> jogosRegistrados){
        await Task.Delay(0);//apenas para retirar o warning
    }       
    // public async Task ExecutarMenuAsync(Dictionary<string, Jogo> jogosRegistrados){
    //     ExibirTituloDaOpcao(Titulo);
    //     await ExecutarOpcaoAsync(jogosRegistrados);
    //     Rodape();
    // }    

    // public virtual async Task ExecutarOpcaoAsync(Dictionary<string, Jogo> jogosRegistrados){
    //     await Task.Delay(0);//apenas para retirar o warning
    // }        
    void Rodape(){
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
    void ExibirTituloDaOpcao(string titulo, char preencher='*'){
        if(!string.IsNullOrEmpty(titulo)){
            Console.Clear();
            var barra = string.Empty.PadLeft(titulo.Length, preencher);
            Console.WriteLine(barra);
            Console.WriteLine(titulo);
            Console.WriteLine(barra);
        }else{
            Console.Clear();
        }

    }

    public string ForcedValidationString(string? aux){
        while(string.IsNullOrEmpty(aux)) {
            Console.Write("Tente Novamente: ");
            aux = Console.ReadLine();
        }
        return aux;
    }

    public float ForcedValidationFloat(string? aux) {
        float value;
        while (!float.TryParse(aux, out value)) {
            Console.Write("Tente Novamente: ");
            aux = Console.ReadLine();
        }
        return value;
    }

}