using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace A017_WPFCalc
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    private bool opFlag;
    private string op;
    private double savedValue;

    public MainWindow()
    {
      InitializeComponent();
    }

    private void Number_Click(object sender, RoutedEventArgs e)
    {
      Button btn = sender as Button;
      string num = btn.Content.ToString();

      if (txtResult.Text == "0" || opFlag == true)
      {
        txtResult.Text = num;
        opFlag = false;
      }
      else
        txtResult.Text += num;
    }

    // 소수점
    private void Dot_Click(object sender, RoutedEventArgs e)
    {
      if (txtResult.Text.Contains("."))
        return;
      else
        txtResult.Text += ".";
    }

    private void PlusMinus_Click(object sender, RoutedEventArgs e)
    {
      double v = double.Parse(txtResult.Text);
      txtResult.Text = (-v).ToString();
    }

    // 사칙연산자 처리(+,-,*,/)
    // 1. opFlag = true
    // 2. txtResult.Text값을 저장 -> savedValue
    // 3. 연산자도 저장
    // 4. txtExp에 수식 표시
    private void Op_Click(object sender, RoutedEventArgs e)
    {      
      opFlag = true;  // 1      
      savedValue = Double.Parse(txtResult.Text); // 2

      // 3
      Button btn = sender as Button;
      string s = btn.Content.ToString();

      switch (s)
      {
        case "+":
          op = "+";
          break;
        case "-":
          op = "-";
          break;
        case "×":
          op = "*";
          break;
        case "÷":
          op = "/";
          break;
      }
      // 4
      txtExp.Text = txtResult.Text + " " + s; 
    }

    // = 클릭되면(예를 들어 123 + 5 =)
    // savedValue + 5 ==> txtResult에 표시
    private void Equal_Click(object sender, RoutedEventArgs e)
    {
      double v = double.Parse(txtResult.Text);
      switch(op)
      {
        case "+":
          txtResult.Text = (savedValue + v).ToString();
          break;
        case "-":
          txtResult.Text = (savedValue - v).ToString();
          break;
        case "*":
          txtResult.Text = (savedValue * v).ToString();
          break;
        case "/":
          txtResult.Text = (savedValue / v).ToString();
          break;
      }

      txtExp.Text = "";
    }

    private void CE_Click(object sender, RoutedEventArgs e)
    {
      txtResult.Text = "0";
    }

    // 모든 값을 초기화
    private void C_Click(object sender, RoutedEventArgs e)
    {
      txtResult.Text = "0";
      txtExp.Text = "";
      savedValue = 0;
      op = "";
      opFlag = false;
    }

    private void Del_Click(object sender, RoutedEventArgs e)
    {
      string s = txtResult.Text;
      s = s.Remove(s.Length - 1);
      if (s == "")
        s = "0";
      txtResult.Text = s;
    }

    private void Sqrt_Click(object sender, RoutedEventArgs e)
    {
      if(txtExp.Text == "")
        txtExp.Text = "√(" + txtResult.Text + ")";
      else
        txtExp.Text = "√(" + txtExp.Text + ")";

      double x = Math.Sqrt(double.Parse(txtResult.Text));
      
      txtResult.Text = x.ToString();      
    }

    private void Sqr_Click(object sender, RoutedEventArgs e)
    {
      if (txtExp.Text == "")
        txtExp.Text = "sqr(" + txtResult.Text + ")";
      else
        txtExp.Text = "sqr(" + txtExp.Text + ")";

      double x = double.Parse(txtResult.Text);

      txtResult.Text = (x*x).ToString();
    }

    private void Reci_Click(object sender, RoutedEventArgs e)
    {
      if (txtExp.Text == "")
        txtExp.Text = "1/(" + txtResult.Text + ")";
      else
        txtExp.Text = "1/(" + txtExp.Text + ")";

      double x = double.Parse(txtResult.Text);

      txtResult.Text = (1/x).ToString();
    }
  }
}
