namespace GameMania.Menus;
using GameMania.Modelos;
using GameMania.Dados;

internal class Menu {
    public string Titulo {get;set;}

    protected JogoDAO? jogoDAO;
    public Menu(string titulo = ""){
        Titulo = titulo;
        jogoDAO = SQLiteJogoDAO.GetInstance();
    }
    public virtual void ExecutarMenu(){
        ExibirTituloDaOpcao(Titulo);
        ExecutarOpcao();
        Rodape();
    }
    public virtual void ExecutarOpcao(){
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
        float value;
        while (!float.TryParse(aux, out value)) {
            Console.Write("Tente Novamente: ");
            aux = Console.ReadLine();
        }
        return value;
    }

}