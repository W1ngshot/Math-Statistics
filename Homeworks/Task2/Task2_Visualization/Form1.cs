using Task2_Calculations;

namespace Task2_Visualization;

public partial class Task2 : Form
{
    public Task2()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        var result = Calculator.CalculateResult();
        result.Values!.ForEach(val => 
            chart1.Series["Points"].Points.AddXY(val.X, val.Y));
        
        result.LinearFunctionPoints!.ForEach(val =>
            chart1.Series["Regression"].Points.AddXY(val.X, val.Y));
    }
}