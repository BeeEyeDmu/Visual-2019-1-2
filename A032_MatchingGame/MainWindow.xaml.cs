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
using System.Windows.Threading;

namespace A032_MatchingGame
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    DispatcherTimer myTimer = new DispatcherTimer();

    public MainWindow()
    {
      InitializeComponent();

      BoardSet();
      myTimer.Interval = new TimeSpan(0, 0, 0, 0, 750); // 0.75초
      myTimer.Tick += MyTimer_Tick;
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
        b.Click += B_Click;
        board.Children.Add(b);
      }
    }

    Button first; // 첫번째 클릭된 버튼
    Button second;  // 두번째 클릭된 버튼
    string[] icon = {"딸기", "레몬", "모과", "배",
      "사과", "수박", "파인애플", "포도"};

    private void B_Click(object sender, RoutedEventArgs e)
    {
      Button btn = sender as Button;
      //MessageBox.Show(btn.Tag.ToString());      

      btn.Content = MakeImage("../../Images/" +
        icon[(int)btn.Tag] + ".png");

      // 첫번째 버튼이라면 계속 그림이 보여진다
      if(first == null)
      {
        first = btn;
        return;
      }
      else
      {
        second = btn;
      }

      if((int)first.Tag == (int)second.Tag)
      {
        first = null;
        second = null;
        matched += 2;
        if(matched >= 16)
        {
          MessageBoxResult res = MessageBox.Show(
            "성공! 다시 할까요?", "Success",
            MessageBoxButton.YesNo);
          if (res == MessageBoxResult.Yes)
            NewGame();
          else
            Close();
        }
        
        //MessageBox.Show("Match: " + matched.ToString());
      }
      else
      {
        myTimer.Start();
      }

    }

    private void NewGame()
    {
      for (int i = 0; i < 16; i++)
        check[i] = false;
      board.Children.Clear();
      BoardSet();
      matched = 0;
    }

    private void MyTimer_Tick(object sender, EventArgs e)
    {
      myTimer.Stop();
      first.Content = MakeImage("../../Images/check.png");
      second.Content = MakeImage("../../Images/check.png");
      first = null;
      second = null;
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
    private int matched;

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
