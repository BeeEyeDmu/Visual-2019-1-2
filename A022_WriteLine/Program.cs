using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A022_WriteLine
{
  class Program
  {
    static void Main(string[] args)
    {
      int x=10, y=20;

      Console.WriteLine(x.ToString() + ", " + y.ToString());
      // printf("%d %d", x, y);
      Console.WriteLine("{0}, {1}", x, y);
      Console.WriteLine($"{x}, {y}");

      string s = string.Format($"{x}, {y}");
      Console.WriteLine(s);

      string t = string.Format("{0}, {1}", x, y);
      Console.WriteLine(t);
    }
  }
}
