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
        jogoDAO = JogoMemDAO.GetInstance();
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
        string aux;
        while(string.IsNullOrEmpty(texto)){
            Console.Write("Insira Um Nome Valido: ");
            texto = Console.ReadLine();
        }
        aux = texto.ToLower();
        return aux;
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

}