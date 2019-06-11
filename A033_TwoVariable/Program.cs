using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A033_TwoVariable
{
  class Program
  {
    static void Main(string[] args)
    {
      int x = 10;
      int y = 20;
      Console.WriteLine(x);
      Console.WriteLine(y);

      // 1. string으로 바꾸어 출력
      Console.WriteLine(x.ToString() + ", " + y.ToString());
      Console.WriteLine(x + ", " + y);

      // 2. 
      Console.WriteLine("{0}, {1}", x, y);

      // 3. 문자열 보간(String Interpolation)
      // C# 6.0
      Console.WriteLine($"{x}, {y}");
    }
  }
}
