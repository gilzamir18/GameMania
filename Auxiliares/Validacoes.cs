namespace Auxiliares;

public class Validacoes {
    public static string ObterStringValida(string? campo = null, int comprimentoMinimo = 3) {
        while (true) {
            string? entrada = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrWhiteSpace(entrada) || entrada.Length < comprimentoMinimo) {
                if (string.IsNullOrEmpty(campo)) {
                    Console.WriteLine($"A entrada não pode ser vazia{(comprimentoMinimo > 1 ? $" e deve ter pelo menos {comprimentoMinimo} caracteres" : "")}.");
                } else {
                    Console.WriteLine($"{campo} do jogo não pode ser vazio{(comprimentoMinimo > 1 ? $" e deve ter pelo menos {comprimentoMinimo} caracteres" : "")}.");
                }
            } else {
                return entrada;
            }
        }
    }

    public static int ObterNotaValida() {
        while (true) {
            string? entrada = Console.ReadLine()?.Trim();

            if (int.TryParse(entrada, out int nota) && nota >= 0 && nota <= 10) {
                return nota;
            } else {
                Console.WriteLine("A nota deve ser um número inteiro entre 0 e 10.");
            }
        }
    }
}