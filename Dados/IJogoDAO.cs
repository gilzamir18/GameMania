using GameMania.Modelos;

namespace GameMania.Dados;

public abstract class IJogoDAO {
    public abstract List<Jogo> ListarJogos();
    public abstract Jogo? BuscarJogo(string titulo);
    public abstract void AvaliarJogo(Jogo jogo, int nota);
    public abstract void SalvarJogo(Jogo jogo);
}