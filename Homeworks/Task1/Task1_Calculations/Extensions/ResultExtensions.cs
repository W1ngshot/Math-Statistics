using System.Linq.Expressions;
using System.Text;

namespace Task1_Calculations.Extensions;

public static class ResultExtensions
{
    private static string GetName(this Result result, Expression<Func<Result, object>> exp) => 
        ReflectionExtensions.Properties.GetDisplayName(exp);

    public static string GetAllProperties(this Result result)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{result.GetName(r => r.SampleSize)}: {result.SampleSize}");
        sb.AppendLine($"{result.GetName(r => r.Minimum)}: {result.Minimum}");
        sb.AppendLine($"{result.GetName(r => r.Maximum)}: {result.Maximum}");
        sb.AppendLine($"{result.GetName(r => r.SampleRange)}: {result.SampleRange}");
        sb.AppendLine($"{result.GetName(r => r.Average)}: {result.Average}");
        sb.AppendLine($"{result.GetName(r => r.SampleVariance)}: {result.SampleVariance}");
        sb.AppendLine($"{result.GetName(r => r.CorrectedVariance)}: {result.CorrectedVariance}");
        sb.AppendLine($"{result.GetName(r => r.StandardDeviation)}: {result.StandardDeviation}");
        sb.AppendLine($"{result.GetName(r => r.Asymmetry)}: {result.Asymmetry}");
        sb.AppendLine($"{result.GetName(r => r.Median)}: {result.Median}");
        sb.AppendLine($"{result.GetName(r => r.InterquartileLatitude)}: {result.InterquartileLatitude}");
        return sb.ToString();
    }
}