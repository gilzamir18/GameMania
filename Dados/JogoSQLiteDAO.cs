using GameMania.Modelos;
using System.Data.SqlClient;
using System.Data.SQLite;
namespace GameMania.Dados;

public class SQLiteJogoDAO: IJogoDAO
{

    private static SQLiteJogoDAO instance;

    public static IJogoDAO GetInstance()
    {
        if (instance == null)
        {
            instance = new SQLiteJogoDAO();
        }
        return instance;
    }

    private SQLiteConnection con;

    private SQLiteJogoDAO()
    {
         var connectionString = $"Data Source=gamemania.db;Version=3";
         con = new SQLiteConnection(connectionString);
         con.Open();
    }

    public override void SalvarJogo(Jogo jogo){
        var transaction = con.BeginTransaction();
        try
        {
            using (var command = new SQLiteCommand(con))
            {
                command.CommandText = @"INSERT INTO 
                                                Jogo(
                                                    Titulo, 
                                                    Genero, 
                                                    Studio, 
                                                    Edicao, 
                                                    Descricao,
                                                    Disponibilidade)
                                                VALUES(@titulo,
                                                       @genero,
                                                       @studio,
                                                       @edicao,
                                                       @descricao,
                                                       @disponibilidade); SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@titulo", jogo.Titulo);
                command.Parameters.AddWithValue("@genero", jogo.Genero);
                command.Parameters.AddWithValue("@studio", jogo.Studio);
                command.Parameters.AddWithValue("@edicao", jogo.Edicao);
                command.Parameters.AddWithValue("@descricao", jogo.Descricao);
                command.Parameters.AddWithValue("@disponibilidade", jogo.Disponibilidade);
                var idJogo = command.ExecuteScalar();

                using (var commandAval = new SQLiteCommand(con))
                {
                    for (int i = 0; i < jogo.QtdNotas; i++)
                    {
                        var avaliacao = jogo.GetAvaliacao(i);
                        commandAval.CommandText = @"INSERT INTO
                                                            Avaliacao(ID_Jogo, Nota) 
                                                            VALUES(@idjogo, @nota)
                                                            ";
                        commandAval.Parameters.AddWithValue("@idjogo", idJogo);
                        commandAval.Parameters.AddWithValue("@nota", avaliacao.Nota);
                        commandAval.ExecuteNonQuery();
                    }
                }
                using (var commandPlat = new SQLiteCommand(con))
                {
                    for (int i = 0; i < jogo.QtdPlataformas; i++)
                    {
                        var plataforma = jogo.GetPlataforma(i);
                        object idplat = -1;
                        using (var selectPlat = new SQLiteCommand(con))
                        {
                            selectPlat.CommandText = @"SELECT ID, Nome 
                                                        FROM Plataforma
                                                        WHERE Plataforma.Nome = @nome";
                            selectPlat.Parameters.AddWithValue("@nome", plataforma);
                            var reader = selectPlat.ExecuteReader();
                            
                            if (reader.Read())
                            {
                                idplat = reader.GetInt32(0);
                                //vreader.GetString(1);
                            }
                            else
                            {
                                using (var addPlat = new SQLiteCommand(con))
                                {
                                    addPlat.CommandText = @"INSERT INTO 
                                                            Plataforma(Nome)
                                                            VALUES (@nome); SELECT last_insert_rowid();";
                                    addPlat.Parameters.AddWithValue("@nome", plataforma);
                                    idplat = addPlat.ExecuteScalar();
                                }
                            }
                        }


                        commandPlat.CommandText = @"INSERT INTO
                                                            JogoPlataforma(ID_Jogo, ID_Plataforma) 
                                                            VALUES(@p1, @p2)
                                                            ";
                        commandPlat.Parameters.AddWithValue("@p1", idJogo);
                        commandPlat.Parameters.AddWithValue("@p2", idplat);
                        commandPlat.ExecuteNonQuery();
                    }
                }
            }

            transaction.Commit();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            transaction.Rollback();
        }
    }
    
    public override List<Jogo> ObterTodosOsJogos(){
        throw new System.NotImplementedException();
    }
    
    public override  Jogo ObterPorTitulo(string titulo){
        throw new System.NotImplementedException();
    }
    
    public override  List<Jogo> FiltrarPorGenero(string genero){
        throw new System.NotImplementedException();
    }
}
