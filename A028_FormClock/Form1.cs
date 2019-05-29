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
    private Timer t = new Timer();
    private Graphics g;
    private double radius; // 반지름
    private Point center; // 중심점
    private int hourHand; // 시침 길이
    private int minHand;  // 분침
    private int secHand;  // 초침
    private const int clientSize = 300; // 화면크기
    private const int clockSize = 200;  // 시계 크기

    public Form1()
    {
      InitializeComponent();

      panel1.Size = new Size(clientSize, clientSize);
      this.ClientSize = new Size(clientSize, clientSize + menuStrip1.Height);
      this.Text = "나의 시계";

      t.Interval = 1000;
      t.Tick += T_Tick;
      t.Start();

      g = panel1.CreateGraphics();
      aClockSetting();
    }

    private void aClockSetting()
    {
      center = new Point(panel1.Width / 2, panel1.Height / 2);
      radius = panel1.Width / 2;

      hourHand = (int)(radius * 0.45);
      minHand = (int)(radius * 0.55);
      secHand = (int)(radius * 0.65);
    }

    // 현재시간에 맞추어 아날로그 시계를 그린다
    private void T_Tick(object sender, EventArgs e)
    {
      DateTime c = DateTime.Now;
      panel1.Refresh();
      DrawClockFace();  // 시계판 그리기

      // 시,분,초침의 각도를 계산
      double radHr 
        = (c.Hour % 12 + c.Minute / 60.0) * 30 * Math.PI / 180;
      double radMin
        = (c.Minute + c.Second / 60.0) * 6 * Math.PI / 180;
      double radSec
        = c.Second * 6 * Math.PI / 180;

      DrawHands(radHr, radMin, radSec);

      // 배꼽
      int coreSize = 16;
      Rectangle r = new Rectangle(center.X - coreSize / 2,
        center.Y - coreSize / 2, coreSize, coreSize);
      g.FillEllipse(Brushes.Gold, r);
      Pen p = new Pen(Brushes.DarkRed, 3);
      g.DrawEllipse(p, r);
    }

    // 시계바늘
    private void DrawHands(double radHr, double radMin, double radSec)
    {
      // 시침
      DrawLine((int)(hourHand*Math.Sin(radHr)), 
        (int)(-hourHand*Math.Cos(radHr)),
        0, 0, Brushes.RoyalBlue, 8, center.X, center.Y);
      // 분침
      DrawLine((int)(minHand * Math.Sin(radMin)),
        (int)(-minHand * Math.Cos(radMin)),
        0, 0, Brushes.SkyBlue, 6, center.X, center.Y);
      // 초침
      DrawLine((int)(secHand * Math.Sin(radSec)),
        (int)(-secHand * Math.Cos(radSec)),
        0, 0, Brushes.OrangeRed, 3, center.X, center.Y);
    }

    private void DrawLine(int x1, int y1, int x2, int y2, Brush color, int thick, int cx, int cy)
    {
      Pen pen = new Pen(color, thick);
      pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
      pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
      g.DrawLine(pen, x1 + cx, y1 + cy, x2 + cx, y2 + cy);
    }

    // 시계판
    private void DrawClockFace()
    {
      Pen pen = new Pen(Brushes.LightSteelBlue, 30);
      g.DrawEllipse(pen,
        center.X - clockSize / 2,
        center.Y - clockSize / 2,
        clockSize, clockSize);

      for(int i=0; i<12; i++)
      {
        int deg = i * 30;
        double rad = deg * Math.PI / 180;
        int x = (int)(center.X + clockSize/2 * Math.Sin(rad));
        int y = (int)(center.Y - clockSize/2 * Math.Cos(rad));
        Rectangle r = new Rectangle(x - 3, y - 3, 6, 6);
        g.FillEllipse(Brushes.Blue, r);
      }
    }
  }
}

/* 
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
        */
