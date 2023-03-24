using MathNet.Numerics;
using Statistics;

namespace Task3_Calculations;

public class StudentСriteria
{
    private List<double> _estimatesX;
    private List<double> _estimatesY;
    private double _minimalSignificanceLevel;
    private int _freedomDegree;
    private CriticalAreaType _criticalAreaType;

    public StudentСriteria(List<double> x, List<double> y, double minimalSignificanceLevel, CriticalAreaType criticalAreaType)
    {
        _estimatesX= x;
        _estimatesY = y;
        _minimalSignificanceLevel = minimalSignificanceLevel;
        _freedomDegree = _estimatesX.Count + _estimatesY.Count - 2;
        _criticalAreaType = criticalAreaType;
    }
    
    public string GetFullAnswer()
        => $"t-Критерий student'а: {GetOneSelectionalStudentCriteria(_estimatesX, _estimatesY)}" +
           $"\nt-Критическое: {GetTCritical(_freedomDegree, _minimalSignificanceLevel)}" +
           $"\nАльтернативная гипотеза {IfWeAreRight(IsAlternativeFair())}.";
    
    public double GetOneSelectionalStudentCriteria(List<double> x, List<double> y) =>
        (Formulas.CalculateAverage(x) - Formulas.CalculateAverage(y))  /
        Math.Sqrt(Math.Pow(StandardAvgError(x), 2) + Math.Pow(StandardAvgError(y), 2));
    
    public double StandardAvgError(List<double> selection) =>
        Formulas.CalculateStandardDeviation(selection) / Math.Sqrt(selection.Count);

    public double GetTCritical(int df, double alpha) => Math.Abs(ExcelFunctions.TInv(alpha, df));

    public double GetSignificanceLevel(int df, double tTest) => Math.Abs(ExcelFunctions.TDist(tTest, df, 1));

    string IfWeAreRight(bool areWeRight) =>
        areWeRight
            ? $"{GetAnswer(areWeRight)} вероятностью ошибки 1 рода {GetSignificanceLevel(_freedomDegree, GetOneSelectionalStudentCriteria(_estimatesX, _estimatesY))}"
            : $"{GetAnswer(areWeRight)}, в виду большей чем в условии вероятности ошибки 1 рода {GetSignificanceLevel(_freedomDegree, GetOneSelectionalStudentCriteria(_estimatesX, _estimatesY))} > {_minimalSignificanceLevel}";

    string GetAnswer(bool areWeRight) =>
        areWeRight ? "верна" : "неверна";
    
    bool IsAlternativeFair() =>
        _criticalAreaType switch
        {
            CriticalAreaType.RightSide => GetOneSelectionalStudentCriteria(_estimatesX, _estimatesY) >
                                          GetTCritical(_freedomDegree, _minimalSignificanceLevel),
            CriticalAreaType.LeftSide => GetOneSelectionalStudentCriteria(_estimatesX, _estimatesY) <
                                         GetTCritical(_freedomDegree, _minimalSignificanceLevel),
            CriticalAreaType.BothSide => GetOneSelectionalStudentCriteria(_estimatesX, _estimatesY) >
                                         Math.Abs(GetTCritical(_freedomDegree, _minimalSignificanceLevel)),
        };
}

public enum CriticalAreaType
{
    LeftSide, 
    RightSide,
    BothSide
}