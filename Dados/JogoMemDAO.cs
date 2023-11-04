using GameMania.Modelos;

namespace GameMania.Dados;

public class JogoMemDAO : IJogoDAO {
    private Dictionary<string, Jogo> jogosRegistrados;
    private static JogoMemDAO? jogoDAO;

    public static JogoMemDAO GetInstance() {
        jogoDAO ??= new JogoMemDAO();
        return jogoDAO;
    }

    private JogoMemDAO() {
        jogosRegistrados = new Dictionary<string, Jogo>();

        InicializarJogo("The Witcher", "RPG de Ação", "CD Projekt RED", "3", "Explore o mundo sombrio de The Witcher, enfrente criaturas mortais e molde seu destino. Uma jornada épica aguarda.", 1, new int[] { 10, 9, 9 }, new string[] { "PC", "Playstation", "Xbox" });

        InicializarJogo("GTA", "Ação, Aventura", "Rockstar Games", "5", "Explore a criminalidade de Los Santos, complete missões e cause caos. Se torne o maior bandido da história.", 2, new int[] { 9, 8, 9 }, new string[] { "Playstation", "Xbox", "PC" });
    }

    public override List<Jogo> ListarJogos() {
        return jogosRegistrados.Values.ToList();
    }
    
    public override Jogo? BuscarJogo(string titulo) {
        if (jogosRegistrados.ContainsKey(titulo)) {
            return jogosRegistrados[titulo];
        } else {
            return null;
        }
    }

    public override void AvaliarJogo(int jogoID, int nota) {
        var jogo = jogosRegistrados.Values.FirstOrDefault(j => j.ID == jogoID);

        if (jogo != null) {
            jogo.AdicionarNota(new Avaliacao(nota));
        } else {
            throw new InvalidOperationException($"Jogo não encontrado.");
        }
    }

    public override void SalvarJogo(Jogo jogo) {
        jogosRegistrados[jogo.Titulo] = jogo;
    }

    private void InicializarJogo(string titulo, string genero, string studio, string edicao, string descricao, int jogoID, int[] notas, string[] plataformas) {
        var jogo = new Jogo(titulo, genero, studio, edicao) {
            ID = jogoID,
            Descricao = descricao
        };

        foreach (var nota in notas) {
            jogo.AdicionarNota(new Avaliacao(nota));
        }

        foreach (var plataforma in plataformas) {
            jogo.AdicionarPlataforma(plataforma);
        }

        jogosRegistrados[titulo] = jogo;
    }
}