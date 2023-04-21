var values = Parser.Parser.ParseXFromFile("../../../../Task5_Data.csv").ToList();

Console.WriteLine(values.Sum(Math.Log));

var alpha = (-values.Count / values.Sum(Math.Log) - 1) / 2;

Console.WriteLine(alpha);