namespace Task1_Calculations.Extensions;

public static class Histogram
{
    public static Dictionary<int, double> ToHistogram(this List<double> numbers)
    {
        var dict = new Dictionary<int, double>();
        foreach (var n in numbers.OrderBy(x => x).Select(number => (int)Math.Floor(number)))
        {
            if (!dict.ContainsKey(n))
                dict[n] = 1;
            else
                dict[n] += 1;
        }

        foreach (var key in dict.Keys)
        {
            dict[key] = Math.Round(dict[key] * 100 / numbers.Count, 2);
        }

        return dict;
    }
}