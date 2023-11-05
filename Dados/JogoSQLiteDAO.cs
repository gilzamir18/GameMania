using GameMania.Modelos;
using System.Data.SQLite;

namespace GameMania.Dados;

public class JogoSQLiteDAO : IJogoDAO {
    private static JogoSQLiteDAO? instance;
    private readonly string _conexaoString;

    public static IJogoDAO GetInstance() {
        instance ??= new JogoSQLiteDAO();
        return instance;
    }

    public JogoSQLiteDAO() {
        _conexaoString = "Data Source=GameMania.db;Version=3";
    }

    public override List<Jogo> ListarJogos() {
        using (var conexao = new SQLiteConnection(_conexaoString)) {
            conexao.Open();

            try {
                return Buscar(conexao);
            } catch (SQLiteException ex) {
                Console.WriteLine($"Erro ao obter lista de jogos!\n{ex.Message}");
                return new List<Jogo>();
            }
        }
    }

    public override Jogo? BuscarJogo(string titulo) {
        using (var conexao = new SQLiteConnection(_conexaoString)) {
            conexao.Open();

            try {
                var jogos = Buscar(conexao, titulo);

                if (jogos.Count > 0) {
                    return jogos[0];
                }
            } catch (SQLiteException e) {
                Console.WriteLine($"Erro ao buscar o jogo '{titulo}'!\n{e.Message}");
            }

            return null;
        }
    }

    public override void AvaliarJogo(int jogoID, int nota) {
        using (var conexao = new SQLiteConnection(_conexaoString)) {
            conexao.Open();
            var transacao = conexao.BeginTransaction();

            try {
                InserirNota(conexao, jogoID, nota);
                transacao.Commit();
            } catch (SQLiteException e) {
                Console.WriteLine($"Erro ao adicionar a nota ao jogo!\n{e.Message}");
                transacao.Rollback();
            }
        }
    }

    public override void SalvarJogo(Jogo jogo) {
        using (var conexao = new SQLiteConnection(_conexaoString)) {
            conexao.Open();
            var transacao = conexao.BeginTransaction();

            try {
                int idJogo = InserirJogo(conexao, jogo);

                if (idJogo != -1) {
                    InserirGeneros(conexao, idJogo, jogo);
                    InserirAvaliacoes(conexao, idJogo, jogo);
                    InserirPlataformas(conexao, idJogo, jogo);
                    transacao.Commit();
                } else {
                    throw new Exception("Erro inesperado ao inserir o jogo no banco de dados.");
                }
            } catch (SQLiteException e) {
                Console.WriteLine($"Erro ao salvar o jogo!\n{e.Message}");
                transacao.Rollback();
            }
        }
    }

    private List<Jogo> Buscar(SQLiteConnection conexao, string? titulo = null) {
        var resultado = new List<Jogo>();

        try {
            using (var cmdSelect = new SQLiteCommand(conexao)) {
                if (string.IsNullOrEmpty(titulo)) {
                    cmdSelect.CommandText = @"
                        SELECT *
                        FROM Jogo";
                } else {
                    cmdSelect.CommandText = @"
                        SELECT *
                        FROM Jogo
                        WHERE Titulo=@titulo";
                    cmdSelect.Parameters.AddWithValue("@titulo", titulo);
                }

                using (var reader = cmdSelect.ExecuteReader()) {
                    while (reader.Read()) {
                        var jogo = new Jogo(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(5) == 1) {
                            ID = reader.GetInt32(0),
                            Descricao = reader.GetValue(4) as string ?? ""
                        };
                        CarregarGeneros(conexao, jogo);
                        CarregarAvaliacoes(conexao, jogo);
                        CarregarPlataformas(conexao, jogo);

                        resultado.Add(jogo);
                    }
                }
            }
        } catch (SQLiteException e) {
            Console.WriteLine($"Erro ao efetuar busca!\n{e.Message}");
        }

        return resultado;
    }

    private void CarregarGeneros(SQLiteConnection conexao, Jogo jogo) {
        try {
            using (var cmdSelectGen = new SQLiteCommand(conexao)) {
                cmdSelectGen.CommandText = @"
                    SELECT Genero.Nome
                    FROM Genero
                    INNER JOIN JogoGenero ON Genero.ID = JogoGenero.ID_Genero
                    WHERE JogoGenero.ID_Jogo = @idJogo";
                cmdSelectGen.Parameters.AddWithValue("@idJogo", jogo.ID);

                using (var readerGen = cmdSelectGen.ExecuteReader()) {
                    while (readerGen.Read()) {
                        jogo.Generos.Add(readerGen.GetString(0));
                    }
                }
            }
        } catch (SQLiteException e) {
            Console.WriteLine($"Erro ao carregar os gêneros!\n{e.Message}");
        }
    }

    private void CarregarAvaliacoes(SQLiteConnection conexao, Jogo jogo) {
        try {
            using (var cmdSelectAval = new SQLiteCommand(conexao)) {
                cmdSelectAval.CommandText = @"
                    SELECT Nota
                    FROM Avaliacao
                    WHERE ID_Jogo=@idJogo";
                cmdSelectAval.Parameters.AddWithValue("@idJogo", jogo.ID);

                using (var readerAval = cmdSelectAval.ExecuteReader()) {
                    while (readerAval.Read()) {
                        var nota = readerAval.GetInt32(0);
                        jogo.AdicionarNota(new Avaliacao(nota));
                    }
                }
            }
        } catch (SQLiteException e) {
            Console.WriteLine($"Erro ao carregar as avaliações!\n{e.Message}");
        }
    }

    private void CarregarPlataformas(SQLiteConnection conexao, Jogo jogo) {
        try {
            using (var cmdSelectPlat = new SQLiteCommand(conexao)) {
                cmdSelectPlat.CommandText = @"
                    SELECT Plataforma.Nome
                    FROM Plataforma
                    INNER JOIN JogoPlataforma ON Plataforma.ID = JogoPlataforma.ID_Plataforma
                    WHERE JogoPlataforma.ID_Jogo = @idJogo";
                cmdSelectPlat.Parameters.AddWithValue("@idJogo", jogo.ID);

                using (var readerPlat = cmdSelectPlat.ExecuteReader()) {
                    while (readerPlat.Read()) {
                        jogo.AdicionarPlataforma(readerPlat.GetString(0));
                    }
                }
            }
        } catch (SQLiteException e) {
            Console.WriteLine($"Erro ao carregar as plataformas!\n{e.Message}");
        }
    }

    private void InserirNota(SQLiteConnection conexao, int jogoID, int nota) {
        try {
            using (var command = new SQLiteCommand(conexao)) {
                command.CommandText = @"
                    INSERT INTO Avaliacao(ID_Jogo, Nota)
                    VALUES(@idJogo, @nota)";
                command.Parameters.AddWithValue("@idJogo", jogoID);
                command.Parameters.AddWithValue("@nota", nota);
                command.ExecuteNonQuery();
            }
        } catch (SQLiteException e) {
            Console.WriteLine($"Erro ao inserir a nota!\n{e.Message}");
        }
    }

    private int InserirJogo(SQLiteConnection conexao, Jogo jogo) {
        try {
            using (var command = new SQLiteCommand(conexao)) {
                command.CommandText = @"
                    INSERT INTO Jogo(Titulo, Estudio, Edicao, Descricao, Disponibilidade) 
                    VALUES(@titulo, @estudio, @edicao, @descricao, @disponibilidade);
                    SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@titulo", jogo.Titulo);
                command.Parameters.AddWithValue("@estudio", jogo.Estudio);
                command.Parameters.AddWithValue("@edicao", jogo.Edicao);
                command.Parameters.AddWithValue("@descricao", jogo.Descricao);
                command.Parameters.AddWithValue("@disponibilidade", jogo.Disponibilidade);
                int idJogo = Convert.ToInt32(command.ExecuteScalar());
                return idJogo;
            }
        } catch (SQLiteException e) {
            Console.WriteLine($"Erro ao inserir jogo!\n{e.Message}");
            return -1; // Indica que ocorreu um erro.
        }
    }

    private void InserirGeneros(SQLiteConnection conexao, int idJogo, Jogo jogo) {
        try {
            using (var commandGenero = new SQLiteCommand(conexao)) {
                foreach (var genero in jogo.Generos) {
                    int idGenero = SelecionarOuAdicionarGenero(conexao, genero);

                    if (idGenero != -1) {
                        commandGenero.CommandText = @"
                            INSERT INTO JogoGenero(ID_Jogo, ID_Genero)
                            VALUES(@idJogo, @idGenero)";
                        commandGenero.Parameters.AddWithValue("@idJogo", idJogo);
                        commandGenero.Parameters.AddWithValue("@idGenero", idGenero);
                        commandGenero.ExecuteNonQuery();
                    } else {
                        throw new Exception("Erro inesperado ao inserir o gênero no banco de dados.");
                    }
                }
            }
        } catch (SQLiteException e) {
            Console.WriteLine($"$Erro ao inserir generos!\n{e.Message}");
        }
    }

    private int SelecionarOuAdicionarGenero(SQLiteConnection conexao, string genero) {
        try {
            using (var selectGenero = new SQLiteCommand(conexao)) {
                selectGenero.CommandText = @"
                    SELECT ID FROM Genero
                    WHERE Nome = @nome";
                selectGenero.Parameters.AddWithValue("@nome", genero);

                using (var reader = selectGenero.ExecuteReader()) {
                    if (reader.Read()) {
                        int idGen = reader.GetInt32(0);
                        return idGen;
                    } else {
                        using (var addGenero = new SQLiteCommand(conexao)) {
                            addGenero.CommandText = @"
                                INSERT INTO Genero(Nome)
                                VALUES (@nome);
                                SELECT last_insert_rowid();";
                            addGenero.Parameters.AddWithValue("@nome", genero);

                            int idGen = Convert.ToInt32(addGenero.ExecuteScalar());
                            return idGen;
                        }
                    }
                }
            }
        } catch (SQLiteException e) {
            Console.WriteLine($"Erro ao selecionar ou adicionar genero!\n{e.Message}");
            return -1; // Indica que ocorreu um erro.
        }
    }

    private void InserirAvaliacoes(SQLiteConnection conexao, int idJogo, Jogo jogo) {
        try {
            using (var commandAval = new SQLiteCommand(conexao)) {
                for (int i = 0; i < jogo.QtdNotas; i++) {
                    var avaliacao = jogo.GetAvaliacao(i);

                    commandAval.CommandText = @"
                        INSERT INTO Avaliacao(ID_Jogo, Nota)
                        VALUES(@idJogo, @nota)";
                    commandAval.Parameters.AddWithValue("@idJogo", idJogo);
                    commandAval.Parameters.AddWithValue("@nota", avaliacao.Nota);
                    commandAval.ExecuteNonQuery();
                }
            }
        } catch (SQLiteException e) {
            Console.WriteLine($"Erro ao inserir avaliações!\n{e.Message}");
        }
    }

    private void InserirPlataformas(SQLiteConnection conexao, int idJogo, Jogo jogo) {
        try {
            using (var commandPlat = new SQLiteCommand(conexao)) {
                for (int i = 0; i < jogo.QtdPlataformas; i++) {
                    var plataforma = jogo.GetPlataforma(i);
                    int idPlataforma = SelecionarOuAdicionarPlataforma(conexao, plataforma);

                    if (idPlataforma != -1) {
                        commandPlat.CommandText = @"
                            INSERT INTO JogoPlataforma(ID_Jogo, ID_Plataforma)
                            VALUES(@idJogo, @idPlataforma)";
                        commandPlat.Parameters.AddWithValue("@idJogo", idJogo);
                        commandPlat.Parameters.AddWithValue("@idPlataforma", idPlataforma);
                        commandPlat.ExecuteNonQuery();
                    } else {
                        throw new Exception("Erro inesperado ao inserir plataforma no banco de dados.");
                    }
                }
            }
        } catch (SQLiteException e) {
            Console.WriteLine($"Erro ao inserir plataformas!\n{e.Message}");
        }
    }

    private int SelecionarOuAdicionarPlataforma(SQLiteConnection conexao, string plataforma) {
        try {
            using (var selectPlat = new SQLiteCommand(conexao)) {
                selectPlat.CommandText = @"
                    SELECT ID FROM Plataforma
                    WHERE Nome = @nome";
                selectPlat.Parameters.AddWithValue("@nome", plataforma);

                using (var reader = selectPlat.ExecuteReader()) {
                    if (reader.Read()) {
                        int idPlat = reader.GetInt32(0);
                        return idPlat;
                    } else {
                        using (var addPlat = new SQLiteCommand(conexao)) {
                            addPlat.CommandText = @"
                                INSERT INTO Plataforma(Nome)
                                VALUES (@nome); SELECT last_insert_rowid();";
                            addPlat.Parameters.AddWithValue("@nome", plataforma);

                            int idPlat = Convert.ToInt32(addPlat.ExecuteScalar());
                            return idPlat;
                        }
                    }
                }
            }
        } catch (SQLiteException e) {
            Console.WriteLine($"Erro ao selecionar ou adicionar plataforma!\n{e.Message}");
            return -1; // Indica que ocorreu um erro.
        }
    }
}