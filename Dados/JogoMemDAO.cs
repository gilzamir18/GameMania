namespace GameMania.Dados;
using GameMania.Modelos;

public class JogoMemDAO : JogoDAO{

    private Dictionary<string, Jogo> jogosRegistrados;

    private static JogoMemDAO? jogoDAO;

    public static JogoMemDAO GetInstance(){
        if (jogoDAO == null){
            jogoDAO = new JogoMemDAO();
        }
        return jogoDAO;
    }

    private JogoMemDAO(){
        jogosRegistrados = new();
        jogosRegistrados["Forza"] = new Jogo("Forza", "Corrida", "XBox Game Studios");
        jogosRegistrados["Forza"].AdicionarNota(new Avaliacao(10));
        jogosRegistrados["Forza"].AdicionarNota(new Avaliacao(5));
        jogosRegistrados["Forza"].AdicionarNota(new Avaliacao(2));

        jogosRegistrados["Valorant"] = new Jogo("Valorant", "Tático", "Riot Games");
        jogosRegistrados["Valorant"].AdicionarNota(new Avaliacao(10));
        jogosRegistrados["Valorant"].AdicionarNota(new Avaliacao(8));
        jogosRegistrados["Valorant"].AdicionarNota(new Avaliacao(9));
    }


    public override void SalvarJogo(Jogo jogo){
        jogo.Nome = string.IsNullOrEmpty(jogo.Nome)?"":jogo.Nome;
        jogosRegistrados[jogo.Nome] = jogo;
    }

    public override List<Jogo> ListarTodosOsJogos(){
        return jogosRegistrados.Values.ToList();
    }
    
    public override Jogo? ObterJogoPorTitulo(string titulo){
        if (jogosRegistrados.ContainsKey(titulo)){
            return jogosRegistrados[titulo];
        }else{
            return null;
        }
    }
    
    public override List<Jogo> FiltrarPorGenero(string genero){
        return jogosRegistrados.Values.Where( j => j.Genero == genero  ).ToList();
    }
}
