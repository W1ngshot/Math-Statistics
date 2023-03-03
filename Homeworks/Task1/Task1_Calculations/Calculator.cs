using Statistics;

namespace Task1_Calculations;

public static class Calculator
{
    private const double Eps = 1E-14;

    public static Result CalculateResult()
    {
        var values = Parser.Parser.ParseXFromFile("../../../../Task1_Data.csv")
            .OrderBy(x => x)
            .ToList();

        return new Result
        {
            Values = values,
            SampleSize = values.Count,
            Minimum = values.Min(),
            Maximum = values.Max(),
            SampleRange = values.Max() - values.Min(),
            Average = Formulas.CalculateAverage(values),
            SampleVariance = Formulas.CalculateSampleVariance(values),
            CorrectedVariance = Formulas.CalculateCorrectedVariance(values),
            StandardDeviation = Formulas.CalculateStandardDeviation(values),
            Asymmetry = Formulas.CalculateAsymmetry(values),
            Median = Formulas.CalculateMedian(values),
            InterquartileLatitude = Formulas.CalculateInterquartileLatitude(values)
        };
    }
}