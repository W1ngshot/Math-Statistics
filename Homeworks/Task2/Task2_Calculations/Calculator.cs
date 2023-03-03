using Statistics;

namespace Task2_Calculations;

public static class Calculator
{
    public static Result CalculateResult()
    {
        var values = Parser.Parser.ParseXYFromFile("../../../../Task2_Data.csv");
        return new Result
        {
            Values = values,
            CorrelationCoefficient = Formulas.CalculateCorrelationCoefficient(values),
            RegressionCoefficients = Formulas.CalculateRegressionCoefficients(values),
            XValue = Formulas.CalculateRegressionValueInPoint(values, 82),
            LinearFunctionPoints = GeneratePointsForLinearFunction(110, 130, values)
        };
    }

    private static List<(double X, double Y)> GeneratePointsForLinearFunction(
        double xFrom, double xTo, List<(double X, double Y)> values)
    {
        var points = new List<(double X, double Y)>();
        var coefficients = Formulas.CalculateRegressionCoefficients(values);
        for (var x = xFrom; x <= xTo; x++)
        {
            points.Add((x, coefficients.b * x + coefficients.a));
        }

        return points;
    }
}