using Task1_Calculations;
using Task1_Calculations.Extensions;

namespace Task1_Visualization;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        var result = Calculator.CalculateResult();
        PropertiesData.Text = result.GetAllProperties();

        var histogram = result.Values.ToHistogram();
        foreach (var pair in histogram)
        {
            Histogram.Series["Values"].Points.AddXY($"[{pair.Key}-{pair.Key + 1})", pair.Value);
        }

        var distributionFunction = result.Values.ToEmpiricalDistributionFunction();
        foreach (var pair in distributionFunction)
        {
            chart1.Series["Values"].Points.AddXY(pair.Key, pair.Value);
        }
    }


}