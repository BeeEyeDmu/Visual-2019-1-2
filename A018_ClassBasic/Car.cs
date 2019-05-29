using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A018_ClassBasic
{
  class Program
  {
    static void Main(string[] args)
    {
      // 클래스를 사용하자
      // 클래스의 객체(개체), Object/instance를 만들어서 사용한다
      Car x = new Car();
      x.SetInTime();
      // ...
      x.SetOutTime();
      //x.SetCarColor(1);
      x.CarColor = 1;

      //Math m = new Math();
      //m.Sin(30);
      // Math는 static 클래스
      // 객체를 만들지 않고 클래스이름으로 사용
      Console.WriteLine(Math.Sin(Math.PI));
    }
  }

  class Car 
  {
    private int carNumber;
    private DateTime inTime;
    private DateTime outTime;
    public int CarColor { set; get; } // 속성
    //private int carColor;

    public void SetInTime()
    {
      this.inTime = DateTime.Now;
    }

    public void SetOutTime()
    {
      this.outTime = DateTime.Now;
    }

    //public void SetCarColor(int color)
    //{
    //  carColor = color;
    //}
  }
}
