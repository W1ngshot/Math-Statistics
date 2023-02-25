namespace Task1_Calculations.Extensions;

public static class EmpiricalDistributionFunction
{
    public static Dictionary<double, double> ToEmpiricalDistributionFunction(this List<double> numbers)
    {
        var dict = new Dictionary<double, double>() {{numbers.Min() - 0.5, 0}};
        var count = 0;
        foreach (var number in numbers.OrderBy(x => x))
        {
            count++;
            if (!dict.ContainsKey(number))
                dict[number] = count;
            else
                dict[number] += 1;
        }

        dict[numbers.Max() + 0.5] = count;
        
        foreach (var key in dict.Keys)
        {
            dict[key] = Math.Round(dict[key] / numbers.Count, 2);
        }

        return dict;
    }
}
