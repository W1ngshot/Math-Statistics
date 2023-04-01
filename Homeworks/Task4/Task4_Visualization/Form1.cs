using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using Task4_Calculation;

namespace Task4_Visualization;

public partial class Form1 : Form
{
    public Form1()
    {
        var result = Calculator.CalculateResult();
        InitializeComponent();
        var plotView = new PlotView();
        plotView.Dock = DockStyle.Fill;
        this.Controls.Add(plotView);

        var plotModel = new PlotModel
        {
            Title = "Exponential Distribution and Empirical Distribution"
        };

        // Create a line series for the normal distribution
        var normalSeries = new LineSeries
        {
            Title = "Exponential Distribution"
        };
        for (double x = 0; x <= 6; x += 0.01)
        {
            normalSeries.Points.Add(new DataPoint(x, result.EFunc(x)));
        }

        // Create a step series for the empirical distribution
        var empiricalSeries = new StairStepSeries
        {
            Title = "Empirical Distribution"
        };
        foreach (var point in result.EmpiricalDistribution)
        {
            empiricalSeries.Points.Add(new DataPoint(point.Key, point.Value));
        }

        // Add the series to the plot model
        plotModel.Series.Add(normalSeries);
        plotModel.Series.Add(empiricalSeries);

        plotView.Model = plotModel;
    }
}