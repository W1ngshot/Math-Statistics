namespace Task1_Calculations;

public static class Calculator
{
    private const double Eps = 1E-14;
    
    public static Result CalculateResult()
    {
        var values = Parser.Parser.ParseFile("../../../../Task1_Data.csv")
            .OrderBy(x => x)
            .ToList();
        
        var average = CalculateAverage(values);
        var variance = CalculateSampleVariance(values, average);

        return new Result
        {
            Values = values,
            SampleSize = values.Count,
            Minimum = values.Min(),
            Maximum = values.Max(),
            SampleRange = values.Max() - values.Min(),
            Average = average.ToRound(),
            SampleVariance = variance.ToRound(),
            CorrectedVariance = CalculateCorrectedVariance(variance, values.Count).ToRound(),
            StandardDeviation = CalculateStandardDeviation(variance).ToRound(),
            Asymmetry = CalculateAsymmetry(values, average, variance).ToRound(),
            Median = CalculateMedian(values).ToRound(),
            InterquartileLatitude = CalculateInterquartileLatitude(values).ToRound()
        };
    }

    private static double CalculateAverage(IReadOnlyCollection<double> values) =>
        values.Sum() / values.Count;

    private static double CalculateSampleVariance(IReadOnlyCollection<double> values, double average) => 
        values.Sum(value => (value - average) * (value - average)) / values.Count;

    private static double CalculateCorrectedVariance(double variance, int sampleSize) => 
        variance * sampleSize / (sampleSize - 1);

    private static double CalculateStandardDeviation(double variance) => 
        Math.Sqrt(variance);

    private static double CalculateAsymmetry(IReadOnlyCollection<double> values, double average, double variance) =>
        values.Sum(value => (value - average) * (value - average) * (value - average)) /
        (values.Count * variance * Math.Sqrt(variance));

    private static double CalculateMedian(IReadOnlyList<double> values) =>
        values.Count % 2 == 1 ? values[(values.Count - 1) / 2] : 
            (values[values.Count / 2] + values[values.Count / 2 - 1]) / 2;

    private static double CalculateInterquartileLatitude(IReadOnlyList<double> values)
    {
        var size = values.Count;
        var q14 = (size - 1) / 4d % 1 < Eps ? 
            values[(size - 1) / 4] :
            (values[(int)Math.Floor((size - 1) / 4d)] + values[(int)Math.Ceiling((size - 1) / 4d)]) / 2d;
        var q34 = (values.Count - 1) * 3 / 4d % 1 < Eps ? 
            values[3 * (size - 1) / 4] :
            (values[(int)Math.Floor(3 * (size - 1) / 4d)] + values[(int)Math.Ceiling(3 * (size - 1) / 4d)]) / 2d;
        return q34 - q14;
    }

    private static double ToRound(this double number, int accuracy = 2) =>
        Math.Round(number, accuracy);
}