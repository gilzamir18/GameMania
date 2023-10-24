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
        jogosRegistrados = new(){
            {"Forza",new Jogo(nota: new List<int>(){8,7,8},
                                            nome: "Forza", 
                                            edicao:"1",
                                            descricao:"",
                                            genero: "Corrida", 
                                            studio: "XBox Game Studios",
                                            plataforma:"Xbox One"
                                            )},
          {"Valorant",new Jogo(nota: new List<int>(){0,1,3},
                                            nome: "Valorant", 
                                            edicao:"1",
                                            descricao:"",
                                            disponibilidade:true,
                                            genero: "FPS", 
                                            studio: "Riot",
                                            plataforma:"PC"
                                            )}                                            

        };
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
