using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
//using System.Windows.Forms.DataVisualization.Charting;

namespace A025_ECGPPG
{
  public partial class Form1 : Form
  {
    Timer myTimer = new Timer();

    public Form1()
    {
      InitializeComponent();

      chart1.Dock = DockStyle.Fill;
      this.WindowState = FormWindowState.Maximized;
      this.Text = "ECG/PPG";

      EcgRead();
      PpgRead();

      myTimer.Interval = 10;  // 0.01초
      myTimer.Tick += MyTimer_Tick;
    }

    int cursorX = 0;  // 현재 그래프에 표시되는 데이터의 시작점
    private void MyTimer_Tick(object sender, EventArgs e)
    {
      if (cursorX + 500 <= ecgCount)
        chart1.ChartAreas["Draw"].AxisX.ScaleView.Zoom
          (cursorX, cursorX + 500);
      else
        myTimer.Stop();
      cursorX += 2;
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void ChartSetting()
    {
      chart1.ChartAreas.Clear();
      chart1.Series.Clear();

      chart1.ChartAreas.Add("Draw");
      chart1.ChartAreas["Draw"].BackColor = Color.Black;
      chart1.ChartAreas["Draw"].AxisX.Minimum = 0;
      chart1.ChartAreas["Draw"].AxisX.Maximum = ecgCount;
      chart1.ChartAreas["Draw"].AxisX.Interval = 50;
      chart1.ChartAreas["Draw"].AxisX.MajorGrid.LineColor = Color.Gray;
      chart1.ChartAreas["Draw"].AxisX.MajorGrid.LineDashStyle
        = ChartDashStyle.Dash;

      chart1.ChartAreas["Draw"].AxisY.Minimum = -3;
      chart1.ChartAreas["Draw"].AxisY.Maximum = 5;
      chart1.ChartAreas["Draw"].AxisY.Interval = 0.5;
      chart1.ChartAreas["Draw"].AxisY.MajorGrid.LineColor = Color.Gray;
      chart1.ChartAreas["Draw"].AxisY.MajorGrid.LineDashStyle 
        = ChartDashStyle.Dash;

      chart1.Series.Add("ECG");
      chart1.Series["ECG"].ChartType = SeriesChartType.Line;
      chart1.Series["ECG"].Color = Color.LightGreen;
      chart1.Series["ECG"].BorderWidth = 2;
      chart1.Series["ECG"].LegendText = "ECG";

      chart1.Series.Add("PPG");
      chart1.Series["PPG"].ChartType = SeriesChartType.Line;
      chart1.Series["PPG"].Color = Color.Orange;
      chart1.Series["PPG"].BorderWidth = 2;
      chart1.Series["PPG"].LegendText = "PPG";
    }

    private void PpgRead()
    {
      string fileName = "../../Data/ppg.txt";
      string[] lines = File.ReadAllLines(fileName);

      double min = double.MaxValue;
      double max = double.MinValue;
      for (int i = 0; i < lines.Length; i++)
      {
        ppg[i] = double.Parse(lines[i]);
        if (ppg[i] > max)
          max = ppg[i];
        if (ppg[i] < min)
          min = ppg[i];
      }
      ppgCount = lines.Length;
      string s = String.Format("PPG : Count = {0}, Min = {1}, Max = {2}",
        ppgCount, min, max);
      MessageBox.Show(s);
    }

    double[] ecg = new double[50000];
    double[] ppg = new double[50000];
    int ecgCount;
    int ppgCount;

    private void EcgRead()
    {
      string fileName = "../../Data/ecg.txt";
      string[] lines = File.ReadAllLines(fileName);

      double min = double.MaxValue;
      double max = double.MinValue;
      for(int i=0; i<lines.Length; i++)
      {
        ecg[i] = double.Parse(lines[i]) + 3;
        if (ecg[i] > max)
          max = ecg[i];
        if (ecg[i] < min)
          min = ecg[i];
      }
      ecgCount = lines.Length;

      string s = String.Format("ECG : Count = {0}, Min = {1}, Max = {2}",
        ecgCount, min, max);
      MessageBox.Show(s);

      //MessageBox.Show("ECG : Count = " 
      //  + ecgCount + ", Min = " + min + ", Max = " + max);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      ChartSetting();

      foreach (var v in ecg)
        chart1.Series["ECG"].Points.Add(v);

      foreach (var v in ppg)
        chart1.Series["PPG"].Points.Add(v);
    }

    private void autoScrollToolStripMenuItem_Click(object sender, EventArgs e)
    {
      myTimer.Start();
    }

    private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      myTimer.Stop();

      chart1.ChartAreas["Draw"].AxisX.ScaleView.Zoom(0, ecgCount);
    }

    bool autoScrollFlag = false; 

    private void chart1_Click(object sender, EventArgs e)
    {
      if(autoScrollFlag == false )
      {
        myTimer.Start();
        autoScrollFlag = true;
      }
      else
      {
        myTimer.Stop();
        autoScrollFlag = false;
      }
    }
  }
}
