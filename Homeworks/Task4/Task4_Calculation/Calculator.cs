using static Task4_Calculation.Methods;

namespace Task4_Calculation;

public static class Calculator
{
    public static Result CalculateResult()
    {
        var values = Parser.Parser.ParseXFromFile("../../../../Task4_Data.csv")
            .OrderBy(x => x).ToList();

        const double alpha = 0.01;
        var cCritical = Math.Sqrt(-0.5 * Math.Log(alpha / 2, Math.E));
        Func<double, double> eFunc = x => 1 - Math.Pow(Math.E, -x);
        var empDistribution = values.ToEmpiricalDistribution();
        var supremum = FindSupremum(empDistribution, eFunc);
        var t = supremum * Math.Sqrt(values.Count);
        var pValue = 2 * Math.Pow(Math.E, -2 * t * t);
        
        return new Result
        {
            T = t,
            PValue = pValue,
            CCritical = cCritical,
            EFunc = eFunc,
            EmpiricalDistribution = empDistribution
        };
    }
}