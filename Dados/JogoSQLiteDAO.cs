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
                int IDJogo = InserirNovoJogo(jogo, connection);
                if (IDJogo != -1){
                    jogo.Genero = string.IsNullOrEmpty(jogo.Genero)?"":jogo.Genero;
                    InserirJogoGenero(IDJogo, jogo.Genero, connection);
                    jogo.Estudio = string.IsNullOrEmpty(jogo.Estudio)?"":jogo.Estudio;
                    InserirJogoEstudio(IDJogo, jogo.Estudio, connection);
                    jogo.Plataforma = string.IsNullOrEmpty(jogo.Plataforma)?"":jogo.Plataforma;
                    InserirJogoPlataforma(IDJogo, jogo.Plataforma, connection);           
                    jogo.Nota = jogo.Nota==null?new List<int>():jogo.Nota;
                    InserirJogoNota(IDJogo, jogo.Nota, connection);                                     
                    transaction.Commit();
                }else{
                    throw new ArgumentException("Falha ao Inserir Novo Jogo");
                }
            }catch (SQLiteException ex){
                Console.WriteLine("Erro ao Salvar Jogo: " + ex.Message);
                transaction.Rollback();
            }
        }
    }

    public int ObterIDJogo(string nome){
        try{
            using (SQLiteCommand command = connection.CreateCommand()){
                command.CommandText = @"
                    SELECT 
                        Jogo.ID
                    FROM 
                        Jogo
                    WHERE 
                        Jogo.Nome = @nome";
                command.Parameters.AddWithValue("@nome", nome);
                using (SQLiteDataReader reader = command.ExecuteReader()){
                    int IDJogo;
                    while (reader.Read()){
                        IDJogo = reader.GetInt32(0);
                        return IDJogo;
                    }
                    return -1;
                }
            }
        }catch (SQLiteException ex){
            Console.WriteLine("Erro ao Obter IDJogo: " + ex.Message);
            return -1;
        }           
    }
    public override Jogo? ObterJogoPorNome(string nome){
        try{
            using (SQLiteCommand command = connection.CreateCommand()){
                command.CommandText = @"
                    SELECT 
                        Jogo.ID, Jogo.Nome, Jogo.Edicao, Jogo.Descricao, Jogo.Disponibilidade 
                    FROM 
                        Jogo
                    WHERE 
                        Jogo.Nome = @nome";
                command.Parameters.AddWithValue("@nome", nome);
                using (SQLiteDataReader reader = command.ExecuteReader()){
                    int IDJogo;
                    while (reader.Read()){
                        IDJogo = reader.GetInt32(0);
                        Jogo jogo = new Jogo{
                            Nome = reader.GetString(1),
                            Edicao = reader.GetString(2),
                            Descricao = reader.GetString(3),
                            Disponibilidade = reader.GetBoolean(4),

                            Genero = ObterGeneroDoJogo(IDJogo),
                            Estudio = ObterEstudioDoJogo(IDJogo),
                            Plataforma = ObterPlataformaDoJogo(IDJogo),
                            Nota = ObterNotaDoJogo(IDJogo)
                        };
                        return jogo;
                    }
                }
            }
        }catch (SQLiteException ex){
            Console.WriteLine("Erro ao Listar Jogo: " + ex.Message);
        }        
        return null;
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
    private void InserirJogoGenero(int IDJogo, string genero, SQLiteConnection conexao){
        try{
            using (SQLiteCommand command = new SQLiteCommand(conexao)){
                command.CommandText = @"
                    INSERT INTO 
                        JogoGenero (IDJogo, IDGenero)
                    VALUES 
                        (@IDJogo, (SELECT ID FROM Genero WHERE Nome = @genero));";
                command.Parameters.AddWithValue("@IDJogo", IDJogo);
                command.Parameters.AddWithValue("@genero", genero);
                command.ExecuteNonQuery();
            }                
        }catch (SQLiteException ex){
            Console.WriteLine("Erro ao Inserir Genero: " + ex.Message);
        }

    }

    private void InserirJogoEstudio(int IDJogo, string estudio, SQLiteConnection conexao){
        try{
            using (SQLiteCommand command = new SQLiteCommand(conexao)){
                command.CommandText = @"
                    INSERT INTO 
                        JogoEstudio (IDJogo, IDEstudio)
                    VALUES 
                        (@IDJogo, (SELECT ID FROM Estudio WHERE Nome = @estudio));";
                command.Parameters.AddWithValue("@IDJogo", IDJogo);
                command.Parameters.AddWithValue("@estudio", estudio);
                command.ExecuteNonQuery();
            }                
        }catch (SQLiteException ex){
            Console.WriteLine("Erro ao Inserir Estudio: " + ex.Message);
        }

    }

    private void InserirJogoPlataforma(int IDJogo, string plataforma, SQLiteConnection conexao){
        try{
            using (SQLiteCommand command = new SQLiteCommand(conexao)){
                command.CommandText = @"
                    INSERT INTO 
                        JogoPlataforma (IDJogo, IDPlataforma)
                    VALUES 
                        (@IDJogo, (SELECT ID FROM Plataforma WHERE Nome = @plataforma));";
                command.Parameters.AddWithValue("@IDJogo", IDJogo);
                command.Parameters.AddWithValue("@plataforma", plataforma);
                command.ExecuteNonQuery();
            }                
        }catch (SQLiteException ex){
            Console.WriteLine("Erro ao Inserir Plataforma: " + ex.Message);
        }

    }             

    private void InserirJogoNota(int IDJogo, List<int> notas, SQLiteConnection conexao) {
        try {
            using (SQLiteCommand command = new SQLiteCommand(conexao)) {
                command.CommandText = @"
                    INSERT INTO 
                        JogoNota (IDJogo, IDNota)
                    VALUES 
                        (@IDJogo, @IDNota);";

                command.Parameters.AddWithValue("@IDJogo", IDJogo);

                foreach (int nota in notas) {
                    command.Parameters.AddWithValue("@IDNota", nota);
                    command.ExecuteNonQuery();
                    command.Parameters.RemoveAt("@IDNota");
                }
            }
        } catch (SQLiteException ex) {
            Console.WriteLine("Erro ao Inserir Nota: " + ex.Message);
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

                            Genero = ObterGeneroDoJogo(IDJogo),
                            Estudio = ObterEstudioDoJogo(IDJogo),
                            Plataforma = ObterPlataformaDoJogo(IDJogo),
                            Nota = ObterNotaDoJogo(IDJogo)
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

    public string ObterGeneroDoJogo(int IDJogo){
        string genero = "";
        try{
            using (SQLiteCommand command = connection.CreateCommand()){
                command.CommandText = @"
                    SELECT Genero.Nome
                    FROM Genero
                    JOIN JogoGenero ON JogoGenero.IDGenero = Genero.ID
                    JOIN Jogo ON JogoGenero.IDJogo = Jogo.ID
                    WHERE Jogo.ID = @IDJogo";
                command.Parameters.AddWithValue("@IDJogo", IDJogo);
                using (SQLiteDataReader reader = command.ExecuteReader()){
                    if (reader.Read()){
                        genero = reader.GetString(0);
                    }
                }
            }            
        }catch (SQLiteException ex){
            Console.WriteLine("Erro ao Salvar Genero: " + ex.Message);
        }
        return genero;
    }

    public string ObterEstudioDoJogo(int IDJogo){
        string estudio = "";
        try{
            using (SQLiteCommand command = connection.CreateCommand()){
                command.CommandText = @"
                    SELECT Estudio.Nome
                    FROM Estudio
                    JOIN JogoEstudio ON JogoEstudio.IDEstudio = Estudio.ID
                    JOIN Jogo ON JogoEstudio.IDJogo = Jogo.ID
                    WHERE Jogo.ID = @IDJogo";
                command.Parameters.AddWithValue("@IDJogo", IDJogo);
                using (SQLiteDataReader reader = command.ExecuteReader()){
                    if (reader.Read()){
                        estudio = reader.GetString(0);
                    }
                }
            }            
        }catch (SQLiteException ex){
            Console.WriteLine("Erro ao Salvar Estudio: " + ex.Message);
        }
        return estudio;
    }

    public string ObterPlataformaDoJogo(int IDJogo){
        string plataforma = "";
        try{
            using (SQLiteCommand command = connection.CreateCommand()){
                command.CommandText = @"
                    SELECT Plataforma.Nome
                    FROM Plataforma
                    JOIN JogoPlataforma ON JogoPlataforma.IDPlataforma = Plataforma.ID
                    JOIN Jogo ON JogoPlataforma.IDJogo = Jogo.ID
                    WHERE Jogo.ID = @IDJogo";
                command.Parameters.AddWithValue("@IDJogo", IDJogo);
                using (SQLiteDataReader reader = command.ExecuteReader()){
                    if (reader.Read()){
                        plataforma = reader.GetString(0);
                    }
                }
            }            
        }catch (SQLiteException ex){
            Console.WriteLine("Erro ao Salvar Plataforma: " + ex.Message);
        }
        return plataforma;
    }

    public List<int> ObterNotaDoJogo(int IDJogo) {
        List<int> notas = new List<int>();
        try {
            using (SQLiteCommand command = connection.CreateCommand()) {
                command.CommandText = @"
                    SELECT IDNota
                    FROM JogoNota
                    WHERE IDJogo = @IDJogo";
                command.Parameters.AddWithValue("@IDJogo", IDJogo);
                using (SQLiteDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        int nota = reader.GetInt32(0);
                        notas.Add(nota);
                    }
                }
            }
        } catch (SQLiteException ex) {
            Console.WriteLine("Erro ao Obter Notas do Jogo: " + ex.Message);
        }
        return notas;
    }

    public override void AdicionarNota(Jogo jogo, int nota){
        jogo.Nome = string.IsNullOrEmpty(jogo.Nome)?"":jogo.Nome;
        int IDJogo = ObterIDJogo(jogo.Nome);
        List<int> aux = new List<int>(){nota};
        InserirJogoNota(IDJogo, aux ,connection);
    }   
}
