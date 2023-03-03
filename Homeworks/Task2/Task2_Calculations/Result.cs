namespace Task2_Calculations;

public class Result
{
    public List<(double X, double Y)>? Values { get; set; }
    
    public double CorrelationCoefficient { get; set; }
    
    public (double a, double b) RegressionCoefficients { get; set; }
    
    public double XValue { get; set; }
    
    public List<(double X, double Y)>? LinearFunctionPoints { get; set; }
}