namespace Auxiliares;

public class Validacoes {
    public static string ObterStringValida(string mensagem, int comprimentoMinimo = 3) {
        string? entrada;

        do {
            Console.Write(mensagem);
            entrada = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(entrada) || entrada.Length < comprimentoMinimo) {
                Console.WriteLine($"A entrada deve ter pelo menos {comprimentoMinimo} caracteres e não pode ser vazia.");
            }
        } while (string.IsNullOrWhiteSpace(entrada) || entrada.Length < comprimentoMinimo);

        return entrada;
    }

    public static string ObterEdicaoValida(string mensagem) {
        string? entrada;

        do {
            Console.Write(mensagem);
            entrada = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(entrada)) {
                Console.WriteLine("A entrada não pode ser vazia.");
            }
        } while (string.IsNullOrWhiteSpace(entrada));

        return entrada;
    }

    public static int ObterNotaValida(string mensagem) {

        while (true) {
            Console.Write(mensagem);
            string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int nota) && nota >= 0 && nota <= 10) {
                return nota;
            } else {
                Console.WriteLine("A nota deve ser um número inteiro entre 0 e 10.");
            }
        }
    }
}