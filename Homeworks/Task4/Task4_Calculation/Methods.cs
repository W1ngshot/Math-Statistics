namespace Task4_Calculation;

public static class Methods
{
    public static Dictionary<double, double> ToEmpiricalDistribution(this List<double> orderedValues)
    {
        var dict = new Dictionary<double, double>();
        var count = 0;
        foreach (var number in orderedValues)
        {
            count++;
            if (!dict.ContainsKey(number))
                dict[number] = count;
            else
                dict[number] += 1;
        }

        foreach (var key in dict.Keys)
        {
            dict[key] = Math.Round(dict[key] / orderedValues.Count, 5);
        }

        return dict;
    }

    public static double FindSupremum(Dictionary<double, double> emp, Func<double, double> func) => 
        emp.Keys.Select(empValue => Math.Abs(emp[empValue] - func(empValue))).Max();


    public static void PrintAnswer(double t, double cCritical, double pValue)
    {
        Print(Math.Round(t, 2), Math.Round(cCritical, 2), Math.Round(pValue, 2));
    }
    
    private static void Print(double t, double cCritical, double pValue)
    {
        Console.WriteLine("Критерий согласия Колмогорова");
        Console.WriteLine("Правосторонняя критическая область");
        Console.WriteLine($"Статистика: {t}");
        Console.WriteLine($"C-критическое: {cCritical}");
        Console.WriteLine($"p-значение: {pValue}");
        Console.WriteLine(t < cCritical
            ? $"Мы принимаем нулевую гипотезу, так как {t} < {cCritical}"
            : $"Мы отвергаем нулевую гипотезу, так как {t} > {cCritical}");
    }
}