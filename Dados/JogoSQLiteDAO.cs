namespace GameMania.Dados;
using GameMania.Modelos;
using System.Data.SQLite;

public class JogoSQLiteDAO: JogoDAO{

    private static JogoSQLiteDAO? instancia;

    public static JogoDAO GetInstance(){
        if (instancia == null){
            instancia = new JogoSQLiteDAO();
        }
        return instancia;
    }

    private SQLiteConnection connection;

    private JogoSQLiteDAO(){
         string connectionString = $"Data Source=GameMania.db";
         connection = new SQLiteConnection(connectionString);
         connection.Open();
    }

         public override void SalvarJogo(Jogo jogo){
            using (SQLiteTransaction transaction = connection.BeginTransaction()){
                try{
                    int jogoID = InserirNovoJogo(jogo, connection);
                    if (jogoID != -1){
                        jogo.Genero = string.IsNullOrEmpty(jogo.Genero)?"":jogo.Genero;
                        InserirJogoGenero(jogoID, jogo.Genero, connection);
                        transaction.Commit();
                    }else{
                        throw new ArgumentException("Falha ao inserir novo jogo.");
                    }
                }catch (SQLiteException ex){
                    Console.WriteLine("Erro ao Salvar Jogo: " + ex.Message);
                    transaction.Rollback();
                }
            }
        }

        private int InserirNovoJogo(Jogo jogo, SQLiteConnection conexao){
            try{
                using (SQLiteCommand command = new SQLiteCommand(conexao)){
                    command.CommandText = @"
                        INSERT INTO 
                            Jogo (Nome, Edicao, Descricao, Disponibilidade)
                        VALUES 
                            (@nome, @edicao, @descricao, @disponibilidade);
                        SELECT 
                            ID FROM Jogo 
                        WHERE 
                            Nome = @nome AND Edicao = @edicao;";
                    command.Parameters.AddWithValue("@nome", jogo.Nome);
                    command.Parameters.AddWithValue("@edicao", jogo.Edicao);
                    command.Parameters.AddWithValue("@descricao", jogo.Descricao);
                    command.Parameters.AddWithValue("@disponibilidade", jogo.Disponibilidade);

                    using (SQLiteDataReader reader = command.ExecuteReader()){
                        if (reader.Read()){
                            return reader.GetInt32(0);
                        }
                    }
                    return -1; // Valor padrão indicando falha
                }
            }catch (SQLiteException ex){
                Console.WriteLine("Erro ao Inserir Jogo: " + ex.Message);
                return -1; // Valor padrão indicando falha
            }

        }
        private void InserirJogoGenero(int jogoID, string genero, SQLiteConnection conexao){
            try{
                using (SQLiteCommand command = new SQLiteCommand(conexao)){
                    command.CommandText = @"
                        INSERT INTO 
                            JogoGenero (IDJogo, IDGenero)
                        VALUES 
                            (@IDJogo, (SELECT ID FROM Genero WHERE Nome = @genero));";
                    command.Parameters.AddWithValue("@IDJogo", jogoID);
                    command.Parameters.AddWithValue("@genero", genero);
                    command.ExecuteNonQuery();
                }                
            }catch (SQLiteException ex){
                Console.WriteLine("Erro ao Inserir Genero: " + ex.Message);
            }

        }
    
    public override List<Jogo> ListarTodosOsJogos(){
        List<Jogo> jogos = new List<Jogo>();
        try{
            using (SQLiteCommand command = connection.CreateCommand()){
                command.CommandText = @"
                    SELECT 
                        Jogo.ID, Jogo.Nome, Jogo.Edicao, Jogo.Descricao, Jogo.Disponibilidade 
                    FROM 
                        Jogo";
                using (SQLiteDataReader reader = command.ExecuteReader()){
                    int IDJogo;
                    while (reader.Read()){
                        IDJogo = reader.GetInt32(0);
                        Jogo jogo = new Jogo{
                            Nome = reader.GetString(1),
                            Edicao = reader.GetString(2),
                            Descricao = reader.GetString(3),
                            Disponibilidade = reader.GetBoolean(4),

                            Genero = ObterGeneroDoJogo(IDJogo)
                        };
                        jogos.Add(jogo);
                    }
                }
            }
        }catch (SQLiteException ex){
            Console.WriteLine("Erro ao Listar Jogos: " + ex.Message);
        }        

        return jogos;
    }

    public string ObterGeneroDoJogo(int jogoID){
        string genero = "";
        try{
            using (SQLiteCommand command = connection.CreateCommand()){
                command.CommandText = @"
                    SELECT Genero.Nome
                    FROM Genero
                    JOIN JogoGenero ON JogoGenero.IDGenero = Genero.ID
                    JOIN Jogo ON JogoGenero.IDJogo = Jogo.ID
                    WHERE Jogo.ID = @jogoID";
                command.Parameters.AddWithValue("@jogoID", jogoID);
                using (SQLiteDataReader reader = command.ExecuteReader()){
                    if (reader.Read()){
                        genero = reader.GetString(0);
                    }
                }
            }            
        }catch (SQLiteException ex){
            Console.WriteLine("Erro ao Salvar Jogo: " + ex.Message);
        }
        return genero;
    }
    
    public override Jogo? ObterJogoPorNome(string nome){
        List<Jogo> jogos = SelectJogoPorCampo("Nome", nome);
        if (jogos.Count > 0){
            return jogos[0];
        }
        return null;
    }
    
    public override  List<Jogo> FiltrarPorGenero(string genero){
        return SelectJogoPorCampo("Genero", genero);
    }

    private List<Jogo> SelectJogoPorCampo(string campo="", string valor=""){
        return new();
    }
}
