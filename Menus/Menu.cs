namespace GameMania.Menus;
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
    protected JogoDAO jogoDAO;
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







}