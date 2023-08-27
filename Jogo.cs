class Jogo{
  private string Titulo{ get; set; }
  public string genero;
  public string studio;
  public string edicao;
  private readonly string descricao;
  private bool disponibilidade;
  public string plataformas;
  public List<int> notas = new List<int>();
  public Jogo(string titulo, string genero, string studio, string edicao, string plataformas){
    Titulo = titulo;
    this.genero = genero;
    this.studio = studio;
    this.edicao = edicao;
    descricao =  $"O jogo {titulo} pertence ao studio {studio}";
    this.plataformas = plataformas;
    disponibilidade = true;
  }
  public double AvaliacaoMedia(){
     return notas.Average();
  }
  public void ExibirFichaTecnica(){
    Console.WriteLine($"Título: {Titulo}");
    Console.WriteLine($"Genero: {genero}");
    Console.WriteLine($"Título: {studio}");
    Console.WriteLine($"Edição: {edicao}");
    Console.WriteLine($"Título: {plataformas}");
    Console.WriteLine($"Descrição: {descricao}");
    
    if(notas.Count != 0)
      Console.WriteLine($"A média de avaliação é: {AvaliacaoMedia()}");
    else
      Console.WriteLine($"O jogo ainda não possui avaliação");

    if(disponibilidade)
      Console.WriteLine("Este jogo está disponível para avaliação.");
    else
      Console.WriteLine("Este jogo não está disponível para avaliação.");
   }
  public bool GetDisponibilidade(){
    return disponibilidade;
  }
}