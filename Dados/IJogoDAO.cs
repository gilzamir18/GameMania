namespace GameMania.Dados;

using GameMania.Modelos;

public abstract class IJogoDAO {
    public abstract void SalvarJogo(Jogo jogo);
    public abstract List<Jogo> ObterTodosOsJogo();
    public abstract Jogo ObterJogoPorTitulo(string titulo);
    public abstract List<Jogo> FiltarPorGenero(string genero);
}