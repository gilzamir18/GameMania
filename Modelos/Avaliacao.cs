public class Avaliacao
{
    public int Nota {get; set;}

    public Avaliacao(int nota)
    {
        Nota = nota;
    }

    public static Avaliacao Parse(string texto)
    {
        int nota = 0;
        try 
        {
            nota = int.Parse(texto);
        }
        catch(FormatException e)
        {
            throw new FormatException("Valor informato não é um inteiro válido!");
        }
        
        if (nota < 0 || nota > 10)
        {
            throw new FormatException("Nota de avaliação tem que ser um valor entre 0 e 10.");
        } 
        return new Avaliacao(nota);
    }
}