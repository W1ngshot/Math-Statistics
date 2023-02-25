using Task1_Calculations.Extensions;

namespace Task1_Calculations;

public static class Program
{
    public static void Main(string[] args)
    {
        var result = Calculator.CalculateResult();
        Console.WriteLine(result.GetAllProperties());
        
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Значения для гистограммы");
        var dict = result.Values.ToHistogram();
        foreach (var pair in dict)
        {
            Console.WriteLine($"[{pair.Key} - {pair.Key + 1}): {pair.Value}%");
        }
        
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Значения для эмпирической функции распределения");
        var function = result.Values.ToEmpiricalDistributionFunction();
        foreach (var pair in function)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}