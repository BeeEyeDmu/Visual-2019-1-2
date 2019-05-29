using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A013_Array
{
  class Program
  {
    static void Main(string[] args)
    {
      //int a[10];
      //int b[];
      //int b[10] = { 1, 2, 3, 4, 5 };
      int[] a = new int[10];
      int[] b = { 11, 22, 13, 4, 15 };
      //TextBox[] c = {txt1, txt2, .. }; 

      for (int i = 0; i < b.Length; i++)
        Console.WriteLine(b[i]);

      Array.Sort(b);
      for (int i = 0; i < b.Length; i++)
        Console.WriteLine(b[i]);

      Console.WriteLine("Using foreach:");
      foreach(var i in b)
        Console.WriteLine(i);

    }
  }
}
