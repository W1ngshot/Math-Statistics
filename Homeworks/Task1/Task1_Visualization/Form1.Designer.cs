namespace Task1_Visualization;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.яё  
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
        System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
        System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
        System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
        System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
        System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
        System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
        Histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
        chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
        PropertiesData = new Label();
        ((System.ComponentModel.ISupportInitialize)Histogram).BeginInit();
        ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
        SuspendLayout();
        // 
        // Histogram
        // 
        chartArea1.Name = "ChartArea1";
        Histogram.ChartAreas.Add(chartArea1);
        legend1.Name = "Legend1";
        Histogram.Legends.Add(legend1);
        Histogram.Location = new Point(12, 12);
        Histogram.Name = "Histogram";
        Histogram.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
        series1.ChartArea = "ChartArea1";
        series1.Legend = "Legend1";
        series1.Name = "Values";
        Histogram.Series.Add(series1);
        Histogram.Size = new Size(720, 480);
        Histogram.TabIndex = 0;
        Histogram.Text = "chart1";
        title1.Name = "Title1";
        title1.Text = "Histogram";
        Histogram.Titles.Add(title1);
        // 
        // chart1
        // 
        chartArea2.Name = "ChartArea1";
        chart1.ChartAreas.Add(chartArea2);
        legend2.Name = "Legend1";
        chart1.Legends.Add(legend2);
        chart1.Location = new Point(12, 507);
        chart1.Name = "chart1";
        series2.ChartArea = "ChartArea1";
        series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
        series2.Legend = "Legend1";
        series2.MarkerBorderWidth = 5;
        series2.MarkerSize = 10;
        series2.Name = "Values";
        chart1.Series.Add(series2);
        chart1.Size = new Size(1353, 480);
        chart1.TabIndex = 1;
        chart1.Text = "chart1";
        // 
        // PropertiesData
        // 
        PropertiesData.AutoSize = true;
        PropertiesData.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        PropertiesData.Location = new Point(750, 15);
        PropertiesData.Name = "PropertiesData";
        PropertiesData.Size = new Size(210, 25);
        PropertiesData.TabIndex = 2;
        PropertiesData.Text = "All properties data here";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1377, 999);
        Controls.Add(PropertiesData);
        Controls.Add(chart1);
        Controls.Add(Histogram);
        Name = "Form1";
        Text = "Task 1";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)Histogram).EndInit();
        ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.DataVisualization.Charting.Chart Histogram;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    private Label PropertiesData;
}