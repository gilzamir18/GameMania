namespace GameMania.Dados;
using GameMania.Modelos;

public class JogoMemDAO : JogoDAO{
    private Dictionary<string,Jogo> jogos = new(){
        ["FarCry"] = new Jogo("FarCry", "Acao/Aventura", "Ubisoft", "3", "3edicao", true, "AllPlatform", notas: new List<float> { 9, 8, 8 }),
        ["GTA"] = new Jogo("GTA", "Acao/Aventura", "RockStar", "5", "5edicao", true, "AllPlatform", notas: new List<float> { 9, 8, 9 }),
        ["Skyrim"] = new Jogo("Skyrim", "RPG", "Bethesda", "5", "5edicao", false, "AllPlatform", notas: new List<float> { 10, 10, 10 }),
        ["Valorant"] = new Jogo("Valorant", "FPS", "Riot", "1", "1edicao", false, "AllPlatform", notas: new List<float> { 0, 0, 0 })
    };  
    private static JogoMemDAO? jogoDAO;

    public static JogoMemDAO GetInstance(){
        if (jogoDAO == null){
            jogoDAO = new JogoMemDAO();
        }
        return jogoDAO;
    }

    public override void SalvarJogo(Jogo jogo){
        jogo.Titulo = string.IsNullOrEmpty(jogo.Titulo)?"":jogo.Titulo;
        jogos[jogo.Titulo] = jogo;
    }

    public override List<Jogo> ExibirJogosCadastrados(){
        return jogos.Values.ToList();
    }
    public override Jogo? JogoPorTitulo(string titulo){
        if (jogos.ContainsKey(titulo)){
            return jogos[titulo];
        }else{
            return null;
        }        
    }

}
