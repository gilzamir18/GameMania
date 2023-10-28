namespace GameMania.Dados;
using GameMania.Modelos;
public abstract class JogoDAO{
    public abstract void SalvarJogo(Jogo jogo);
    public abstract List<Jogo> ListarTodosOsJogos();
    public abstract Jogo? ObterJogoPorNome(string titulo);
    public abstract void AdicionarNota(Jogo jogo, int nota);
    
}