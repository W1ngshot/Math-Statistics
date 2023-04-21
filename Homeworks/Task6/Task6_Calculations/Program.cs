using MathNet.Numerics;
using Statistics;

const double q = 0.99d;
var values = Parser.Parser.ParseXFromFile("../../../../Task6_Data.csv").ToList();
var n = values.Count;
var avg = Formulas.CalculateAverage(values);
var deviation = Formulas.CalculateStandardDeviation(values);
var m = deviation / Math.Sqrt(n - 1);
var tCrit = ExcelFunctions.TInv(1 - q, n - 1);

Console.WriteLine($"Объём выборки = {n}\n" +
                  $"Выборочное среднее = {avg}\n" + 
                  $"Стандартная ошибка среднего = {Math.Round(m, 2)}\n" + 
                  $"Значения выборки с вероятностью {q} лежат в верхнем доверительном интервале (-[inf] ; {Math.Round(avg + tCrit * m, 2)}]");