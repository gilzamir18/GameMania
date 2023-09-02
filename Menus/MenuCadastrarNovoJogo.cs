namespace GameMania.Menus;
using GameMania.Modelos;

internal class MenuCadastrarNovoJogo: Menu{
    public MenuCadastrarNovoJogo():base(titulo:"Cadastrar Novo Jogo"){

    }    
    public override void ExecutarOpcao(Dictionary<string, Jogo> jogosRegistrados){
        Console.WriteLine("Cadastrar Um Novo Jogo | Digite -1 Para Cancelar: ");
        Console.Write("Titulo: ");
        string? aux = Console.ReadLine();
        aux = string.IsNullOrEmpty(aux) ? "" : aux;

        while((string.IsNullOrEmpty(aux) || jogosRegistrados.ContainsKey(aux)) && aux != "-1"){
            Console.Write("Nome Invalido Ou Ja Cadastrado. Tente Novamente: ");
            aux = Console.ReadLine();
            aux = string.IsNullOrEmpty(aux) ? "" : aux;
        }
        
        if(aux != "-1"){
            Jogo? jogo = new(titulo:aux);
            Console.Write("Genero: ");
            aux = Console.ReadLine();
            //TryCatch que manda pra um validador?
            jogo.Genero = base.ForcedValidationString(aux);

            Console.Write("Studio: ");
            aux = Console.ReadLine();
            jogo.Studio = ForcedValidationString(aux);        

            Console.Write("Edicao: ");
            aux = Console.ReadLine();
            jogo.Edicao = ForcedValidationString(aux);

            Console.Write("Disponivel Para Avaliacao? (1 == Sim | 0 == Nao)");
            while (true){
                aux = Console.ReadLine();
                if (aux == "1" || aux == "Sim"){
                    jogo.Disponibilidade=true;
                    break;
                }else if (aux == "0" || aux == "Nao"){
                    jogo.Disponibilidade=false;
                    break;
                }else{
                    Console.Write("Tente Novamente: ");
                }
            }

            Console.Write("Plataformas: ");
            aux = Console.ReadLine();
            jogo.Plataformas = ForcedValidationString(aux);

            jogo.Notas = new List<float>{};//Evitar Warning
            Console.Write("Notas | Digite -1 Para Cancelar: ");
            float n = 0;
            while(n >= 0){
                aux = Console.ReadLine();
                n = ForcedValidationFloat(aux);
                if(n>=0){
                    jogo.Notas.Add(n);
                }else{
                    n=-1;
                }
            }
            jogo.Titulo = string.IsNullOrEmpty(jogo.Titulo)?"":jogo.Titulo;
            jogosRegistrados.Add(jogo.Titulo,jogo);
            Console.WriteLine("Jogo Adicionado Com Sucesso");        
        }else{
            Console.WriteLine("Cadastro Cancelado");
        }
    }
}