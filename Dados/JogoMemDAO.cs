namespace GameMania.Dados;

using GameMania.Modelos;

public class JogoMemDAO : IJogoDAO {
    private Dictionary<string, Jogo> jogosRegistrados;

    private static JogoMemDAO jogoDAO;

    public static JogoMemDAO GetInstance() {
        if (jogoDAO == null) {
            jogoDAO = new JogoMemDAO();
        }
        return jogoDAO;
    }

    private JogoMemDAO() {
        jogosRegistrados = new();
        jogosRegistrados["Forza"] = new Jogo("Forza", "Corrida", "XBox Game Studios", "5");
        jogosRegistrados["Forza"].AdicionarNota(new Avaliacao(10));
        jogosRegistrados["Forza"].AdicionarNota(new Avaliacao(5));
        jogosRegistrados["Forza"].AdicionarNota(new Avaliacao(2));
        jogosRegistrados["Forza"].AdicionarPlataforma("Xbox");
        jogosRegistrados["Forza"].AdicionarPlataforma("PC");

        jogosRegistrados["GTA"] = new Jogo("GTA", "Ação, Aventura", "Rockstar Games", "5");
        jogosRegistrados["GTA"].AdicionarNota(new Avaliacao(10));
        jogosRegistrados["GTA"].AdicionarNota(new Avaliacao(8));
        jogosRegistrados["GTA"].AdicionarNota(new Avaliacao(9));
        jogosRegistrados["GTA"].AdicionarPlataforma("Playstation");
        jogosRegistrados["GTA"].AdicionarPlataforma("Xbox");
        jogosRegistrados["GTA"].AdicionarPlataforma("PC");
    }

    public override void SalvarJogo(Jogo jogo) {
        jogosRegistrados[jogo.Titulo] = jogo;
    }

    public override List<Jogo> ObterTodosOsJogo() {
        return jogosRegistrados.Values.ToList();
    }

    public override Jogo ObterJogoPorTitulo(string titulo) {
        if (jogosRegistrados.ContainsKey(titulo))
            return jogosRegistrados[titulo];
        else
            return null;
    }

    public override List<Jogo> FiltarPorGenero(string genero) {
        return jogosRegistrados.Values.Where(j => j.Genero == genero).ToList();
    }
}