using GameMania.Modelos;
using System.Data.SQLite;

namespace GameMania.Dados;
public class SQLiteDAO : IJogoDAO {
    private readonly string connectionString;
    private static SQLiteDAO? instance;
    private static readonly string defaultDbFilePath = @"C:\caminho\para\seu\arquivo\sqlite.db";

    private SQLiteDAO() {
        connectionString = $"Data Source={defaultDbFilePath};Version=3";
        CriarTabelaDeJogos();
    }

    public static SQLiteDAO GetInstance() {
        if (instance == null)
            instance = new SQLiteDAO();

        return instance;
    }

    private void CriarTabelaDeJogos() {
        using SQLiteConnection connection = new(connectionString);
        connection.Open();

        string createTableSql = @"
                CREATE TABLE IF NOT EXISTS Jogos (
                    Titulo TEXT PRIMARY KEY,
                    Genero TEXT,
                    Studio TEXT,
                    Edicao TEXT,
                    Disponibilidade INTEGER
                );";

        using (SQLiteCommand command = new(createTableSql, connection))
            command.ExecuteNonQuery();

        connection.Close();
    }

    public override void SalvarJogo(Jogo jogo) {
        using SQLiteConnection connection = new(connectionString);
        connection.Open();

        string insetSql = @"INSERT INTO Jogos (Titulo, Genero, Studio, Edicao, Disponibilidade)
            VALUES (@Titulo, @Genero, @Studio, @Edicao, @Disponibilidade);";

        using (SQLiteCommand command = new(insetSql, connection)) {
            command.Parameters.AddWithValue("@Titulo", jogo.Titulo);
            command.Parameters.AddWithValue("@Genero", jogo.Genero);
            command.Parameters.AddWithValue("@Studio", jogo.Studio);
            command.Parameters.AddWithValue("@Edicao", jogo.Edicao);
            command.Parameters.AddWithValue("@Disponibilidade", jogo.Disponibilidade);
            command.ExecuteNonQuery();
        }
        connection.Close();
    }

    public override List<Jogo> ObterTodosOsJogos() {
        List<Jogo> jogos = new();

        using SQLiteConnection connection = new(connectionString);
        connection.Open();

        string seletSql = "SELECT * FROM Jogos;";
        using (SQLiteCommand command = new(seletSql, connection)) {
            using SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                string titulo = reader["Titulo"].ToString();
                string genero = reader["Genero"].ToString();
                string studio = reader["Studio"].ToString();
                string edicao = reader["Edicao"].ToString();
                bool disponibilidade = Convert.ToInt32(reader["Disponibilidade"]) == 1;

                Jogo jogo = new Jogo(titulo, genero, studio, edicao, disponibilidade);
                jogos.Add(jogo);
            }
        }
        connection.Close();
        return jogos;
    }

    public override Jogo ObterJogoPorTitulo(string titulo) {
        using SQLiteConnection connection = new(connectionString);
        connection.Open();

        string seletSql = "SELECT * FROM Jogos WHERE Titulo = @Titulo;";
        using (SQLiteCommand command = new SQLiteCommand(seletSql, connection)) {
            command.Parameters.AddWithValue("@Titulo", titulo);

            using SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read()) {
                string genero = reader["Genero"].ToString();
                string studio = reader["Studio"].ToString();
                string edicao = reader["Edicao"].ToString();
                bool disponibilidade = Convert.ToInt32(reader["Disponibilidade"]) == 1;
                Jogo jogo = new(titulo, genero, studio, edicao, disponibilidade);

                connection.Close();
                return jogo;
            }
        }
        connection.Close();
        return null;
    }

    public override List<Jogo> FiltrarPorGenero(string genero) {
        List<Jogo> jogos = new();

        using SQLiteConnection connection = new(connectionString);
        connection.Open();

        string seletSql = "SELECT * FROM Jogos WHERE Genero = @Genero;";
        using (SQLiteCommand command = new(seletSql, connection)) {
            command.Parameters.AddWithValue("@Genero", genero);

            using SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                string titulo = reader["Titulo"].ToString();
                string studio = reader["Studio"].ToString();
                string edicao = reader["Edicao"].ToString();
                bool disponibilidade = Convert.ToInt32(reader["Disponibilidade"]) == 1;
                Jogo jogo = new Jogo(titulo, genero, studio, edicao, disponibilidade);
                jogos.Add(jogo);
            }
        }
        connection.Close();
        return jogos;
    }
}