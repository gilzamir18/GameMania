namespace GameMania.Menus;
using GameMania.Modelos;
internal class Menu {
    public string Titulo {get;set;}
    public Menu(string titulo){
        Titulo = titulo;
    }
    public void ExecutarMenu(Dictionary<string, Jogo> jogosRegistrados){
        ExibirTituloDaOpcao(Titulo);
        ExecutarOpcao(jogosRegistrados);
        Rodape();
    }
    public virtual void ExecutarOpcao(Dictionary<string, Jogo> jogosRegistrados){
        
    }    
    void Rodape(){
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
    void ExibirTituloDaOpcao(string titulo, char preencher='*'){
        Console.Clear();
        var barra = string.Empty.PadLeft(titulo.Length, preencher);
        Console.WriteLine(barra);
        Console.WriteLine(titulo);
        Console.WriteLine(barra);
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