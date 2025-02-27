using Newtonsoft.Json;

namespace teste_target.Source;

public class Revenue
{
    [JsonProperty("dia")]
    public int Day { get; set; }

    [JsonProperty("valor")]
    public double Value { get; set; }
}

public class RevenueByState
{
    public string State { get; set; } = string.Empty;
    public double Revenue { get; set; }
}

public static class RevenueProcessor
{
    public static void ProcessRevenue(List<Revenue> revenues)
    {
        if (revenues == null || revenues.Count == 0)
        {
            Console.WriteLine("Nenhum dado de receita foi fornecido.");
            return;
        }

        var validRevenues = revenues.Where(r => r.Value > 0).ToList();

        if (validRevenues.Count == 0)
        {
            Console.WriteLine("Nenhum dado da Receita válido encontrado");
            return;
        }

        double avg = validRevenues.Average(r => r.Value);
        var min = validRevenues.Min(r => r.Value);
        var max = validRevenues.Max(r => r.Value);
        int daysAboveAvg = validRevenues.Count(r => r.Value > avg);

        Console.WriteLine($"O Menor valor de faturamento ocorrido foi: R${min:F2}");
        Console.WriteLine($"O Maior valor de faturamento ocorrido foi: R${max:F2}");
        Console.WriteLine($"O número de dias com faturamento superior à média mensal foi: {daysAboveAvg}");
    }

    public static void CalculateRevenuePercentage()
    {
        var revenueByState = new List<RevenueByState>
        {
            new() { State = "SP", Revenue = 67836.43 },
            new() { State = "RJ", Revenue = 36678.66 },
            new() { State = "MG", Revenue = 29229.88 },
            new() { State = "ES", Revenue = 27165.48 },
            new() { State = "Others", Revenue = 19849.53 }
        };

        double totalRevenue = revenueByState.Sum(r => r.Revenue);
        Console.WriteLine("\nPorcentagem de receita por estado:");

        foreach (var state in revenueByState)
        {
            double percentage = (state.Revenue / totalRevenue) * 100;
            Console.WriteLine($"{state.State}: {percentage:F2}%");
        }
    }
}
