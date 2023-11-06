namespace Auxiliares;

public class Validacoes {
    public static string ObterStringValida(string mensagem, string campo, int comprimentoMinimo = 3) {
        while (true) {
            Console.Write(mensagem);
            string? entrada = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrWhiteSpace(entrada) || entrada.Length < comprimentoMinimo) {
                Console.WriteLine($"{campo} não pode ser vazio e deve ter pelo menos {comprimentoMinimo} caractere{(comprimentoMinimo >= 2 ? "s" : "")}.");
            } else {
                return entrada;
            }
        }
    }

    public static int ObterNotaValida(string mensagem) {
        while (true) {
            Console.Write(mensagem);
            string? entrada = Console.ReadLine()?.Trim();

            if (int.TryParse(entrada, out int nota) && nota >= 0 && nota <= 10) {
                return nota;
            } else {
                Console.WriteLine("A nota deve ser um número inteiro entre 0 e 10.");
            }
        }
    }
}