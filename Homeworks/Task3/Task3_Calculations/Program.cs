using Task3_Calculations;

var values = Parser.Parser.ParseXYFromFile("../../../../Task3_Data.csv");

var valuesX = values.Select(value => value.X).ToList();
var valuesY = values.Select(value => value.Y).ToList();

var criteria = new StudentСriteria(valuesX, valuesY, 0.025, CriticalAreaType.RightSide);
Console.WriteLine(criteria.GetFullAnswer());