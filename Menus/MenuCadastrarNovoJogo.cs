namespace GameMania.Menus;
using GameMania.Modelos;

class MenuCadastrarNovoJogo: Menu{
    public MenuCadastrarNovoJogo(): base("Cadastrar Novo Jogo"){

    }
public override void ExecutarOpcao(){
        Console.Write("Nome: ");
        string nome = ValidarConsulta(Console.ReadLine());
        Jogo? jogo = jogoDAO.ObterJogoPorNome(nome);
        if(jogo != null){
            Console.WriteLine("Este Nome Ja Esta Cadastrado");
        }else{
            Console.Write("Edicao: ");
            string edicao = ValidarConsulta(Console.ReadLine());
            Console.Write("Descricao: ");
            string descricao = ValidarConsulta(Console.ReadLine());
            Console.Write("Disponibilidade (1 - S(im) | 2 - N(ao): ");
            bool disponibilidade = ValidaDisponibilidade(Console.ReadLine());
            Console.Write("Genero: ");
            string genero = ValidarConsulta(Console.ReadLine());
            Console.Write("Studio: ");
            string estudio = ValidarConsulta(Console.ReadLine());
            Console.Write("Plataforma: ");
            string plataforma = ValidarConsulta(Console.ReadLine());

            List<int>? notas = new List<int>();
            if(disponibilidade == true){
                Console.Write("Nota: ");
                int nota = ValidarNota(Console.ReadLine());
                notas.Add(nota);
                foreach (var item in notas){
                    Console.WriteLine(item);
                }                
            }



            jogoDAO.SalvarJogo(new Jogo(nome:nome,
                                        edicao:edicao,
                                        descricao:descricao,
                                        disponibilidade:disponibilidade,
                                        genero:genero,
                                        estudio:estudio,
                                        plataforma:plataforma,
                                        nota:notas
                                        ));
            Console.WriteLine("Jogo Adicionado Com Sucesso");
        }

    }
}
