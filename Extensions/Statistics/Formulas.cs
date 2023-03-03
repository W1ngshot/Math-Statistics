using System.Runtime.CompilerServices;

namespace Statistics;

public static class Formulas
{
    private const double Epsilon = 1E-14;

    public static double CalculateAverage(IReadOnlyCollection<double> values, int accuracy = 2) =>
        Average(values).ToRound(accuracy);

    public static double
        CalculateSampleVariance(IReadOnlyCollection<double> values, int accuracy = 2) =>
        SampleVariance(values).ToRound(accuracy);

    public static double CalculateCorrectedVariance(IReadOnlyCollection<double> values, int accuracy = 2) =>
        CorrectedVariance(values).ToRound(accuracy);

    public static double CalculateStandardDeviation(IReadOnlyCollection<double> values, int accuracy = 2) =>
        StandardDeviation(values).ToRound(accuracy);

    public static double CalculateAsymmetry(IReadOnlyCollection<double> values, int accuracy = 2) =>
        Asymmetry(values).ToRound(accuracy);

    public static double CalculateMedian(IReadOnlyList<double> values, int accuracy = 2) =>
        Median(values).ToRound(accuracy);

    public static double CalculateInterquartileLatitude(IReadOnlyList<double> values, int accuracy = 2) =>
        InterquartileLatitude(values).ToRound(accuracy);

    public static double CalculateCorrelationCoefficient(
        IReadOnlyCollection<(double X, double Y)> values, int accuracy = 2) =>
        CorrelationCoefficient(values).ToRound(accuracy);

    public static (double a, double b) CalculateRegressionCoefficients(
        IReadOnlyCollection<(double X, double Y)> values, int accuracy = 2) =>
        RegressionCoefficients(values).ToRound(accuracy);

    public static double CalculateRegressionValueInPoint(IReadOnlyCollection<(double X, double Y)> values,
        double yValue, int accuracy = 2) =>
        RegressionValueInPoint(values, yValue).ToRound(accuracy);


    #region MathFormulas
    
    private static double Average(IReadOnlyCollection<double> values) =>
        values.Sum() / values.Count;

    private static double MultiplyAverage(IReadOnlyCollection<(double X, double Y)> values) =>
        values.Sum(val => val.X * val.Y) / values.Count;
    
    private static double SampleVariance(IReadOnlyCollection<double> values)
    {
        var average = Average(values);
        var sum = values.Sum(value => (value - average) * (value - average));
        return sum / values.Count;
    }

    private static double CorrectedVariance(IReadOnlyCollection<double> values) => 
        SampleVariance(values) * values.Count / (values.Count - 1);

    private static double StandardDeviation(IReadOnlyCollection<double> values) => 
        Math.Sqrt(SampleVariance(values));
    
    private static double Asymmetry(IReadOnlyCollection<double> values)
    {
        var average = Average(values);
        var variance = SampleVariance(values);
        var sum = values.Sum(value => (value - average) * (value - average) * (value - average));
        return  sum / (values.Count * variance * Math.Sqrt(variance));
    }

    private static double Median(IReadOnlyList<double> values) =>
        values.Count % 2 == 1 ? values[(values.Count - 1) / 2] : 
            (values[values.Count / 2] + values[values.Count / 2 - 1]) / 2;
    
    private static double InterquartileLatitude(IReadOnlyList<double> values)
    {
        var size = values.Count;
        var q14 = (size - 1) / 4d % 1 < Epsilon ? 
            values[(size - 1) / 4] :
            (values[(int)Math.Floor((size - 1) / 4d)] + values[(int)Math.Ceiling((size - 1) / 4d)]) / 2d;
        var q34 = (values.Count - 1) * 3 / 4d % 1 < Epsilon ? 
            values[3 * (size - 1) / 4] :
            (values[(int)Math.Floor(3 * (size - 1) / 4d)] + values[(int)Math.Ceiling(3 * (size - 1) / 4d)]) / 2d;
        return q34 - q14;
    }

    private static double CorrelationCoefficient(IReadOnlyCollection<(double X, double Y)> values)
    {
        var xValues = values.Select(val => val.X).ToList();
        var yValues = values.Select(val => val.Y).ToList();
        var multiplyAverage = MultiplyAverage(values);
        var xAverage = Average(xValues);
        var yAverage = Average(yValues);
        var xDeviation = StandardDeviation(xValues);
        var yDeviation = StandardDeviation(yValues);

        return (multiplyAverage - xAverage * yAverage) / (xDeviation * yDeviation);
    }
    
    private static (double a, double b) RegressionCoefficients(IReadOnlyCollection<(double X, double Y)> values)
    {
        var xValues = values.Select(val => val.X).ToList();
        var yValues = values.Select(val => val.Y).ToList();
        var xAverage = Average(xValues);
        var yAverage = Average(yValues);
        var xDeviation = StandardDeviation(xValues);
        var yDeviation = StandardDeviation(yValues);
        var correlation = CorrelationCoefficient(values);

        var b = correlation * yDeviation / xDeviation;
        var a = yAverage - b * xAverage;
        return (a, b);
    }

    private static (double a, double b) RegressionCoefficients2(IReadOnlyCollection<(double X, double Y)> values)
    {
        var n = values.Count;
        var ySum = values.Sum(val => val.Y);
        var xSum = values.Sum(val => val.X);
        var xySum = values.Sum(val => val.X * val.Y);
        var xxSum = values.Sum(val => val.X * val.X);

        var b = (ySum * xSum / n - xySum) / (xSum * xSum / n - xxSum);
        var a = (ySum - b * xSum) / n;
        return (a, b);
    }

    private static double RegressionValueInPoint(IReadOnlyCollection<(double X, double Y)> values, double yValue)
    {
        var coefficients = RegressionCoefficients2(values);
        return (yValue - coefficients.a) / coefficients.b;
    }

    #endregion
}