namespace GameMania.Menus;
using GameMania.Modelos;
internal class Menu {
    public string Titulo {get;set;}
    public Menu(string titulo = ""){
        Titulo = titulo;
    }
    public virtual void ExecutarMenu(Dictionary<string, Jogo> jogosRegistrados){
        ExibirTituloDaOpcao(Titulo);
        ExecutarOpcao(jogosRegistrados);
        Rodape();
    }
    public virtual void ExecutarOpcao(Dictionary<string, Jogo> jogosRegistrados){
        Task.Delay(0);//apenas para retirar o warning
    }          
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
        float value = 11;
        while (!float.TryParse(aux, out value) || value>10) {
            Console.Write("Tente Novamente: ");
            aux = Console.ReadLine();
        }
        return value;
    }

}