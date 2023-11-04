namespace GameMania.Menus;

internal class Sair : Menu {

    public Sair() : base("*  Sair  *") { }

    public override bool MostrarOpcao() {
        Console.WriteLine("Volte sempre!!!\n");
        return true;
    }
}