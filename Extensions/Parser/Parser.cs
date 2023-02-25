using System.Globalization;

namespace Parser;

public static class Parser
{
    public static List<double> ParseFile(string path)
    {
        return File.ReadAllLines(path)
            .Select(a => a.Split(';').First())
            .Where(x => double.TryParse(x, CultureInfo.InvariantCulture, out _))
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToList();
    }
}