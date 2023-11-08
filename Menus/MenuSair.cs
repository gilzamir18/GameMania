using GameMania.Modelos;

namespace GameMania.Menus;


internal class MenuSair : Menu
{
    public MenuSair(): base("Saindo da aplicação"){}
    public override bool MostrarOpcao()
    {
        Console.WriteLine("Volte sempre!!!");
        return true;
    }
}
