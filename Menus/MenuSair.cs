namespace GameMania.Menus;

internal class MenuSair : Menu {

    public MenuSair() : base("*  Sair  *") { }

    public override bool MostrarOpcao() {
        Console.WriteLine("Volte sempre!!!\n");
        return true;
    }
}