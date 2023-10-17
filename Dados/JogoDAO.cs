namespace GameMania.Dados;
using GameMania.Modelos;

public abstract class JogoDAO
{
    public abstract void SalvarJogo(Jogo jogo);
    public abstract List<Jogo> ExibirJogosCadastrados();
    public abstract Jogo? JogoPorTitulo(string titulo);
    public abstract List<Jogo> FiltrarPorGenero(string genero);
}