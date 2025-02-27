using Newtonsoft.Json;

namespace teste_target.Source;
class Program
{
    static void Main()
    {
        int sum = Utils.CalculateSum();
        Console.WriteLine($"Resultado da Soma: {sum}");
        Console.Write("Digite um número para verificar a Sequência de Fibonacci: ");
        
        int number;
        string? value = Console.ReadLine();
        if (!int.TryParse(value, out number))
        {
            Console.WriteLine("Valor inválido.");
            return;
        }
        bool isFibonacci = Fibonacci.IsInFibonacci(number);
        Console.WriteLine(isFibonacci 
            ? "O número está na sequência de Fibonacci." 
            : "O número NÃO está na sequência de Fibonacci.");
            
        string jsonPath = Path.Combine("Data", "dados.json");

        if (File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            var revenueData = JsonConvert.DeserializeObject<List<Revenue>>(json) ?? new List<Revenue>();
            RevenueProcessor.ProcessRevenue(revenueData);
        }
        else
        {
            Console.WriteLine("Arquivo JSON não encontrado.");
        }
        
        RevenueProcessor.CalculateRevenuePercentage();

        Console.Write("Digite uma string para reverter: ");
        string inputString = Console.ReadLine() ?? string.Empty;
        string reversedString = Utils.ReverseString(inputString);
        Console.WriteLine($"String Invertida: {reversedString}");
    }
}
