namespace GameMania.Dados;
using GameMania.Modelos;

public class JogoMemDAO : IJogoDAO
{

    private Dictionary< string, Jogo > jogosRegistrados;

    private static JogoMemDAO jogoDAO;

    public static JogoMemDAO GetInstance()
    {
        if (jogoDAO == null)
        {
            jogoDAO = new JogoMemDAO();
        }
        return jogoDAO;
    }

    private JogoMemDAO()
    {
        jogosRegistrados = new();
        jogosRegistrados["Forza"] = new Jogo("Forza", "Corrida", "XBox Game Studios", "5");
        jogosRegistrados["Forza"].AdicionarNota(new Avaliacao(10));
        jogosRegistrados["Forza"].AdicionarNota(new Avaliacao(5));
        jogosRegistrados["Forza"].AdicionarNota(new Avaliacao(2));
        jogosRegistrados["Forza"].AdicionarPlataforma("XBox360");

        jogosRegistrados["Valorant"] = new Jogo("Valorant", "Tático", "Riot Games", "6");
        jogosRegistrados["Valorant"].AdicionarNota(new Avaliacao(10));
        jogosRegistrados["Valorant"].AdicionarNota(new Avaliacao(8));
        jogosRegistrados["Valorant"].AdicionarNota(new Avaliacao(9));
        jogosRegistrados["Valorant"].AdicionarPlataforma("PS4");
        jogosRegistrados["Valorant"].AdicionarPlataforma("XBox360");
        jogosRegistrados["Valorant"].AdicionarPlataforma("PC");
    }


    public override void SalvarJogo(Jogo jogo)
    {
        jogosRegistrados[jogo.Titulo] = jogo;
    }

    public override List<Jogo> ObterTodosOsJogos()
    {
        return jogosRegistrados.Values.ToList();
    }
    
    public override Jogo ObterPorTitulo(string titulo)
    {
        if (jogosRegistrados.ContainsKey(titulo))
        {
            return jogosRegistrados[titulo];
        }
        else
        {
            return null;
        }
    }
    
    public override List<Jogo> FiltrarPorGenero(string genero)
    {
        return jogosRegistrados.Values.Where( j => j.Genero == genero  ).ToList();
    }


     public override List<Jogo> SelectJogoPorCampo(string campo = "", string valor = "")
    {
        List<Jogo> resultado = new List<Jogo>();

        foreach (var jogo in jogosRegistrados.Values)
        {
            if (campo == "" || (campo == "Título" && jogo.Titulo == valor) || (campo == "Gênero" && jogo.Genero == valor))
            {
                resultado.Add(jogo);
            }
        }

        return resultado;
    }
}


