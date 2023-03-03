using Task1_Calculations;
using Task1_Calculations.Extensions;

var result = Calculator.CalculateResult();
Console.WriteLine(result.GetAllProperties());
        
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("Histogram values");
var dict = result.Values.ToHistogram();
foreach (var pair in dict)
{
    Console.WriteLine($"[{pair.Key} - {pair.Key + 1}): {pair.Value}%");
}
        
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("Empirical distribution function values");
var function = result.Values.ToEmpiricalDistributionFunction();
foreach (var pair in function)
{
    Console.WriteLine($"{pair.Key}: {pair.Value}");
}