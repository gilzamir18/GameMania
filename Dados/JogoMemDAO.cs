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
            {"forza",new Jogo(  nome: "forza", 
                                edicao:"horizon",
                                descricao:"edicao 1 de forza",
                                disponibilidade:true,
                                genero: "corrida", 
                                estudio: "xbox game studios",
                                plataforma:"xbox one",
                                nota: new List<int>(){8,7,8}
                                )},
          {"valorant",new Jogo( nome: "valorant", 
                                edicao:"1",
                                descricao:"edicao 1 de valorant",
                                disponibilidade:false,
                                genero: "fps", 
                                estudio: "riot",
                                plataforma:"windows",
                                nota: new List<int>(){3,5,2}
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
    public override Jogo? ObterJogoPorNome(string nome){
        if (jogos.ContainsKey(nome)){
            return jogos[nome];
        }else{
            return null;
        }
    }
    public override List<Jogo> FiltrarPorGenero(string genero){
        return jogos.Values.Where( j => j.Genero == genero  ).ToList();
    }

}
