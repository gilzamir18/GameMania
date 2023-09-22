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
        jogosRegistrados["The Witcher"] = new Jogo("The Wicther", "RPG de Ação", "CD Projeckt RED", "3");
        jogosRegistrados["The Witcher"].AdicionarNota(new Avaliacao(10));
        jogosRegistrados["The Witcher"].AdicionarNota(new Avaliacao(9));
        jogosRegistrados["The Witcher"].AdicionarNota(new Avaliacao(9));
        jogosRegistrados["The Witcher"].AdicionarPlataforma("PC");
        jogosRegistrados["The Witcher"].AdicionarPlataforma("Playstation");
        jogosRegistrados["The Witcher"].AdicionarPlataforma("Xbox");
        jogosRegistrados["The Witcher"].Descricao = "Prepare-se para entrar em uma jornada épica no mundo sombrio e perigoso de The Witcher. Explore terras deslumbrantes, enfrente criaturas mortais e faça escolhas difíceis que moldarão o seu destino. Com gráficos deslumbrantes e uma história envolvente, The Witcher é um jogo imperdível para os fãs de RPG de ação.";

        jogosRegistrados["GTA"] = new Jogo("GTA", "Ação, Aventura", "Rockstar Games", "5");
        jogosRegistrados["GTA"].AdicionarNota(new Avaliacao(10));
        jogosRegistrados["GTA"].AdicionarNota(new Avaliacao(8));
        jogosRegistrados["GTA"].AdicionarNota(new Avaliacao(9));
        jogosRegistrados["GTA"].AdicionarPlataforma("Playstation");
        jogosRegistrados["GTA"].AdicionarPlataforma("Xbox");
        jogosRegistrados["GTA"].AdicionarPlataforma("PC");
        jogosRegistrados["GTA"].Descricao = "Caos, criminalidade e muita diversão. Jogue como um criminoso em Los Santos, explore uma cidade vibrante, faça missões e cause estragos com seus amigos no modo online. Prepare-se para enfrentar a polícia, dominar o mercado de drogas e se tornar o maior bandido da história.";
    }

    public override void SalvarJogo(Jogo jogo) {
        jogosRegistrados[jogo.Titulo] = jogo;
    }

    public override List<Jogo> ObterTodosOsJogos() {
        return jogosRegistrados.Values.ToList();
    }

    public override Jogo ObterJogoPorTitulo(string titulo) {
        if (jogosRegistrados.ContainsKey(titulo))
            return jogosRegistrados[titulo];
        else
            return null;
    }

    public override List<Jogo> FiltrarPorGenero(string genero) {
        return jogosRegistrados.Values.Where(j => j.Genero == genero).ToList();
    }
}