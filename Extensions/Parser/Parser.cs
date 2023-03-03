using System.Globalization;

namespace Parser;

public static class Parser
{
    public static List<double> ParseXFromFile(string path) =>
        File.ReadAllLines(path)
            .Select(x => x.Split(';').First())
            .Where(x => double.TryParse(x, CultureInfo.InvariantCulture, out _))
            .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
            .ToList();

    public static List<(double X, double Y)> ParseXYFromFile(string path) =>
        File.ReadAllLines(path)
            .Select(x => x.Split(';').First())
            .Select(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries))
            .Where(x => x.Length == 2)
            .Where(x => double.TryParse(x[0], CultureInfo.InvariantCulture, out _) &&
                        double.TryParse(x[1], CultureInfo.InvariantCulture, out _))
            .Select(x => (X: double.Parse(x[0], CultureInfo.InvariantCulture)
                , Y: double.Parse(x[1], CultureInfo.InvariantCulture)))
            .ToList();
}