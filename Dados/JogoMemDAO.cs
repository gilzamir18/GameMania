namespace GameMania.Dados;
using GameMania.Modelos;
public class JogoMemDAO : JogoDAO{
    private Dictionary<string, Jogo> jogos;
    private static JogoMemDAO? jogoDAO;
    public static JogoMemDAO GetInstance(){
        if (jogoDAO == null){
            jogoDAO = new JogoMemDAO();
        }
        return jogoDAO;
    }
    private JogoMemDAO(){
        jogos = new(){
            {"Forza",new Jogo(nota: new List<int>(){8,7,8},
                                            nome: "Forza", 
                                            edicao:"Horizon",
                                            descricao:"Edicao 1 de Forza",
                                            genero: "Corrida", 
                                            estudio: "XBox Game Studios",
                                            plataforma:"Xbox One"
                                            )},
          {"Valorant",new Jogo(nota: new List<int>(){3,5,2},
                                            nome: "Valorant", 
                                            edicao:"1",
                                            descricao:"Edicao 1 de Valorant",
                                            disponibilidade:false,
                                            genero: "FPS", 
                                            estudio: "Riot",
                                            plataforma:"Windows"
                                            )}                                            

        };
    }
    public override void SalvarJogo(Jogo jogo){
        jogo.Nome = string.IsNullOrEmpty(jogo.Nome)?"":jogo.Nome;
        jogos[jogo.Nome] = jogo;
    }
    public override List<Jogo> ListarTodosOsJogos(){
        return jogos.Values.ToList();
    }
    public override Jogo? ObterJogoPorTitulo(string titulo){
        if (jogos.ContainsKey(titulo)){
            return jogos[titulo];
        }else{
            return null;
        }
    }
    public override List<Jogo> FiltrarPorGenero(string genero){
        return jogos.Values.Where( j => j.Genero == genero  ).ToList();
    }
}
