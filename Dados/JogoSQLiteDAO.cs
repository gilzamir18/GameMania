namespace GameMania.Dados;
using GameMania.Modelos;
using System.Data.SQLite;

public class JogoSQLiteDAO: JogoDAO{

    private static JogoSQLiteDAO? instance;

    public static JogoDAO GetInstance(){
        if (instance == null){
            instance = new JogoSQLiteDAO();
        }
        return instance;
    }

    private SQLiteConnection connection;

    private JogoSQLiteDAO(){
         var connectionString = $"Data Source=gamemania.db;Version=3";
         connection = new SQLiteConnection(connectionString);
         connection.Open();
    }

    public override void SalvarJogo(Jogo jogo){
        var transaction = connection.BeginTransaction();
        try{
            using (var command = new SQLiteCommand(connection)){
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
                command.Parameters.AddWithValue("@titulo", jogo.Nome);
                command.Parameters.AddWithValue("@genero", jogo.Genero);
                command.Parameters.AddWithValue("@studio", jogo.Studio);
                command.Parameters.AddWithValue("@edicao", jogo.Edicao);
                command.Parameters.AddWithValue("@descricao", jogo.Descricao);
                command.Parameters.AddWithValue("@disponibilidade", jogo.Disponibilidade);
                var idJogo = command.ExecuteScalar();

                using (var commandAval = new SQLiteCommand(connection)){
                    for (int i = 0; i < jogo.QtdNotas; i++){
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
                // using (var commandPlat = new SQLiteCommand(connection)){
                //     for (int i = 0; i < jogo.QtdPlataformas; i++){
                //         var plataforma = jogo.GetPlataforma(i);
                //         object idplat = -1;
                //         using (var selectPlat = new SQLiteCommand(connection)){
                //             selectPlat.CommandText = @"SELECT ID, Nome 
                //                                         FROM Plataforma
                //                                         WHERE Plataforma.Nome = @nome";
                //             selectPlat.Parameters.AddWithValue("@nome", plataforma);
                //             var reader = selectPlat.ExecuteReader();
                            
                //             if (reader.Read()){
                //                 idplat = reader.GetInt32(0);
                //                 //vreader.GetString(1);
                //             }else{
                //                 using (var addPlat = new SQLiteCommand(connection)){
                //                     addPlat.CommandText = @"INSERT INTO 
                //                                             Plataforma(Nome)
                //                                             VALUES (@nome); SELECT last_insert_rowid();";
                //                     addPlat.Parameters.AddWithValue("@nome", plataforma);
                //                     idplat = addPlat.ExecuteScalar();
                //                 }
                //             }
                //         }


                //         commandPlat.CommandText = @"INSERT INTO
                //                                             JogoPlataforma(ID_Jogo, ID_Plataforma) 
                //                                             VALUES(@p1, @p2)
                //                                             ";
                //         commandPlat.Parameters.AddWithValue("@p1", idJogo);
                //         commandPlat.Parameters.AddWithValue("@p2", idplat);
                //         commandPlat.ExecuteNonQuery();
                //     }
                // }
            }

            transaction.Commit();
        }catch(Exception e){
            Console.WriteLine(e.Message);
            transaction.Rollback();
        }
    }
    
    public override List<Jogo> ListarTodosOsJogos(){
        return SelectJogoPorCampo();
    }
    
    public override Jogo? ObterJogoPorTitulo(string titulo){
        List<Jogo> jogos = SelectJogoPorCampo("Titulo", titulo);
        if (jogos.Count > 0){
            return jogos[0];
        }
        return null;
    }
    
    public override  List<Jogo> FiltrarPorGenero(string genero){
        return SelectJogoPorCampo("Genero", genero);
    }

    private List<Jogo> SelectJogoPorCampo(string campo="", string valor=""){
        List<Jogo> resultado = new List<Jogo>();
        using (var cmdSelect = new SQLiteCommand(connection)){
            if (campo == ""){
                cmdSelect.CommandText = $"select * from Jogo";    
            }else{
                cmdSelect.CommandText = $"select * from Jogo where {campo}=@param";
            }
            cmdSelect.Parameters.AddWithValue("@param", valor);
            using (var reader = cmdSelect.ExecuteReader()){
                while (reader.Read()){
                    int jogoID = -1;
                    Jogo? jogo = null;
                    jogoID = reader.GetInt32(0);
                    var titulo = reader.GetString(1);
                    var genero = reader.GetString(2);
                    var studio = reader.GetString(3);
                    var edicao = reader.GetString(4);
                    var descvalue = reader.GetValue(5);
                    var desc = "";
                    if (!(descvalue is System.DBNull)){
                        desc = (string)descvalue;
                    }
                    var disponibilidade = reader.GetInt32(6) == 1 ? true : false;                  
                    jogo = new Jogo(nome:titulo,
                                    edicao:edicao,
                                    genero:genero,
                                    studio:studio);
                    jogo.Descricao = desc;
                    using (var cmdSelectAval = new SQLiteCommand(connection)){

                        cmdSelectAval.CommandText = @"select Nota from Avaliacao 
                                                                            where ID_Jogo=@param1";
                        cmdSelectAval.Parameters.AddWithValue("@param1", jogoID);
                        using (var readerAval = cmdSelectAval.ExecuteReader()){
                            while (readerAval.Read())
                            {
                                int nota = readerAval.GetInt32(0);
                                jogo.AdicionarNota(new Avaliacao(nota));
                            }
                        }
                    }

                    using (var cmdSelectPlat = new SQLiteCommand(connection)){
                        cmdSelectPlat.CommandText = @"
                            SELECT Plataforma.Nome FROM Plataforma
                                INNER JOIN JogoPlataforma ON Plataforma.ID = JogoPlataforma.ID_Plataforma
                                WHERE JogoPlataforma.ID_Jogo = @param";
                        cmdSelectPlat.Parameters.AddWithValue("@param", jogoID);
                        using(var readerPlat = cmdSelectPlat.ExecuteReader()){

                            while (readerPlat.Read()){
                                //jogo.AdicionarPlataforma(readerPlat.GetString(0));
                            }
                        }
                    }

                    resultado.Add(jogo);
                }
            }
        }
        return resultado;
    }
}
