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

namespace A032_MatchingGame
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      BoardSet();
    }

    private void BoardSet()
    {
      for(int i=0; i<16; i++)
      {
        Button b = new Button();
        b.Background = Brushes.White;
        b.Margin = new Thickness(10);
        b.Tag = SetRandom() % 8;
        b.Content = MakeImage("../../Images/check.png");
        board.Children.Add(b);
      }
    }

    private Image MakeImage(string v)
    {
      BitmapImage bi = new BitmapImage();
      bi.BeginInit();
      bi.UriSource = new Uri(v, UriKind.Relative);
      bi.EndInit();

      Image myImage = new Image();
      myImage.Source = bi;
      return myImage;
    }

    bool[] check = new bool[16];

    private int SetRandom()
    {
      Random r = new Random();

      while (true)
      {
        int x = r.Next(16); // 0~15
        if (check[x] == false)
        {
          check[x] = true;
          return x;
        }
      }
    }
  }
}
