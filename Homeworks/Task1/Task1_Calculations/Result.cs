using System.ComponentModel;

namespace Task1_Calculations;

public class Result
{
    [DisplayName("Выборка")]
    public List<double> Values { get; set; } = null!;
    
    [DisplayName("Размер выборки")]
    public int SampleSize { get; set; }
    
    [DisplayName("Минимум")]
    public double Minimum { get; set; }
    
    [DisplayName("Максимум")]
    public double Maximum { get; set; }
    
    [DisplayName("Размах выборки")]
    public double SampleRange { get; set; }
    
    [DisplayName("Среднее")]
    public double Average { get; set; }
    
    [DisplayName("Выборочная дисперсия")]
    public double SampleVariance { get; set; }
    
    [DisplayName("Поправленная на несмещённость оценка дисперсии")]
    public double CorrectedVariance { get; set; } 
    
    [DisplayName("Стандартное отклонение")]
    public double StandardDeviation { get; set; }
    
    [DisplayName("Асимметрия")]
    public double Asymmetry { get; set; }
    
    [DisplayName("Медиана")]
    public double Median { get; set; }
    
    [DisplayName("Интерквартильная широта")]
    public double InterquartileLatitude { get; set; }
}