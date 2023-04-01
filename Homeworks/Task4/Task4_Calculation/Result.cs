namespace Task4_Calculation;

public class Result
{
    public Dictionary<double, double> EmpiricalDistribution { get; set; } = null!;

    public Func<double, double> EFunc { get; set; } = null!;

    public double CCritical { get; set; }
    
    public double T { get; set; }
    
    public double PValue { get; set; }
}