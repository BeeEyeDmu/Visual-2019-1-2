using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A028_FormClock
{
  public partial class Form1 : Form
  {
    Timer t = new Timer();
    Graphics g;

    public Form1()
    {
      InitializeComponent();

      panel1.Size = new Size(300, 300);
      this.ClientSize = new Size(300, 300 + menuStrip1.Height);

      t.Interval = 1000;
      t.Tick += T_Tick;
      t.Start();

      g = panel1.CreateGraphics();
    }

    // 현재시간에 맞추어 아날로그 시계를 그린다
    private void T_Tick(object sender, EventArgs e)
    {
      int sec = DateTime.Now.Second;  // 초
      double secDeg = sec * 6;    // 초침이 12시방향과 이루는 각도
      // 초침의 길이는 200
      double x = 100 * Math.Sin(secDeg * Math.PI / 180);
      double y = 100 * Math.Cos(secDeg * Math.PI / 180);

      g.DrawLine(new Pen(Color.Black), new Point(150, 150), 
        new Point((int)(150 + x), (int)(150 - y)));

      int min = DateTime.Now.Minute;  // 분
      double minDeg = min * 6;    // 초침이 12시방향과 이루는 각도
      // 초침의 길이는 200
      double x1 = 100 * Math.Sin(minDeg * Math.PI / 180);
      double y1 = 100 * Math.Cos(minDeg * Math.PI / 180);

      g.DrawLine(new Pen(Color.Red), new Point(150, 150),
        new Point((int)(150 + x1), (int)(150 - y1)));

      int hour = DateTime.Now.Hour;  // 시
      double hourDeg = hour * 30 + min * 0.5;    // 초침이 12시방향과 이루는 각도
      // 초침의 길이는 200
      double x2 = 80 * Math.Sin(hourDeg * Math.PI / 180);
      double y2 = 80 * Math.Cos(hourDeg * Math.PI / 180);

      g.DrawLine(new Pen(Color.Blue), new Point(150, 150),
        new Point((int)(150 + x2), (int)(150 - y2)));
    }
  }
}
