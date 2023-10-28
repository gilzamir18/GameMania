namespace GameMania.Menus;
using System.Globalization;
using GameMania.Dados;
internal class Menu {
    private string? titulo;
    public string? Titulo{
        get{
            return titulo;
        }
        set{
            titulo = string.IsNullOrEmpty(value)? "":value;
        }
    }
    public JogoDAO jogoDAO;
    public Menu(string titulo){
        Titulo = titulo;
        jogoDAO = JogoSQLiteDAO.GetInstance();
    }
    void ExibirTituloDaOpcao(string titulo = "", char preencher='*'){
        Console.Clear();
        string barra = string.Empty.PadLeft(titulo.Length, preencher);
        Console.WriteLine(barra);
        Console.WriteLine(titulo);
        Console.WriteLine(barra);
    }
    public virtual void ExecutarOpcao(){

    }
    void Rodape(){
        Console.WriteLine("Pressione Qualquer Tecla Para Continuar");
        Console.ReadKey();
    }    
    public void Executar(){
            Titulo = string.IsNullOrEmpty(Titulo)? "":Titulo;
            ExibirTituloDaOpcao(Titulo);
            ExecutarOpcao();
            Rodape();
    }

    public string ValidarConsulta(string? texto){
        while(string.IsNullOrEmpty(texto)){
            Console.Write("Insira Um Valor Valido: ");
            texto = Console.ReadLine();
        }
        return texto.ToLower();
    }
    public string ValidarStringParaExibicao(string texto){
        if(string.IsNullOrEmpty(texto)){
            return "";
        }else{
            TextInfo title = new CultureInfo("pt-BR").TextInfo;
            texto = title.ToTitleCase(texto);
            return texto;
        }

    }
    public int ValidarNota(string? texto){
        int n;
        while(!int.TryParse(texto, out n) || n<1 || n>10){
            Console.Write("Insira Um Numero Inteiro Valido De 1 a 10: ");
            texto = Console.ReadLine();
        }   
        return n;
    }
    public bool ValidaDisponibilidade(string? texto){
        List<string> EntradaValida = new List<string>(){"1", "s","2", "n"};
        while(string.IsNullOrEmpty(texto) || !EntradaValida.Contains(texto.ToLower())){
            Console.WriteLine("Digite Um Valor Correspondente: ");
            texto = Console.ReadLine();
        }
        if(texto == "1" || texto == "s"){
            return true;
        }else{
            return false;
        }
    }    

}