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

        InicializarJogo("The Witcher", new string[] { "RPG", "Ação" }, "CD Projekt RED", "3", "Explore o mundo sombrio de The Witcher, enfrente criaturas mortais e molde seu destino. Uma jornada épica aguarda.", new string[] { "PC", "Playstation", "Xbox" }, new int[] { 10, 9, 9 });

        InicializarJogo("GTA", new string[] { "Ação", "Aventura" }, "Rockstar Games", "5", "Explore a criminalidade de Los Santos, complete missões e cause caos. Se torne o maior bandido da história.", new string[] { "Playstation", "Xbox", "PC" }, new int[] { 7, 8, 9 });
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

    public override void AvaliarJogo(Jogo jogo, int nota) {
        if (jogo != null) {
            jogo.AdicionarNota(new Avaliacao(nota));
        } else {
            throw new InvalidOperationException($"Jogo não encontrado.");
        }
    }

    public override void SalvarJogo(Jogo jogo) {
        if (jogosRegistrados.ContainsKey(jogo.Titulo)) {
            Console.WriteLine($"{jogo.Titulo} já foi cadastrado.");
        } else {
            jogosRegistrados[jogo.Titulo] = jogo;
            Console.WriteLine($"{jogo.Titulo} cadastrado com sucesso.");
        }
    }

    private void InicializarJogo(string titulo, string[] generos,  string estudio, string edicao, string descricao, string[] plataformas, int[] notas) {
        var jogo = new Jogo(titulo, estudio, edicao) {
            Descricao = descricao
        };

        foreach (var genero in generos) {
            jogo.AdicionarGenero(genero);
        }

        foreach (var nota in notas) {
            jogo.AdicionarNota(new Avaliacao(nota));
        }

        foreach (var plataforma in plataformas) {
            jogo.AdicionarPlataforma(plataforma);
        }

        jogosRegistrados[titulo] = jogo;
    }
}