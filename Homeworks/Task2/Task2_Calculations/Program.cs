using Task2_Calculations;

var result = Calculator.CalculateResult();

Console.WriteLine($"Correlation coefficient is {result.CorrelationCoefficient}");
Console.WriteLine($"Regression equation: y = {result.RegressionCoefficients.b}x + {result.RegressionCoefficients.a}");
Console.WriteLine($"Regression value in point with Y = 82 is {result.XValue}");