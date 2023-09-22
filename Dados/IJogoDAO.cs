namespace GameMania.Dados;

using GameMania.Modelos;

public abstract class IJogoDAO {
    public abstract void SalvarJogo(Jogo jogo);
    public abstract List<Jogo> ObterTodosOsJogos();
    public abstract Jogo ObterJogoPorTitulo(string titulo);
    public abstract List<Jogo> FiltrarPorGenero(string genero);
}