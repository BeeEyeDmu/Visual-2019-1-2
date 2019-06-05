using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A031_ExclusiveRandom
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] a = new int[16];
      
      // 16개의 중복되지 않는 랜덤 숫자를 저장한다
      for(int i=0; i<16; i++)
      {
        a[i] = Check()%8;
      }

      for (int i = 0; i < 16; i++)
      {
        Console.WriteLine(a[i]);
      }
    }

    static bool[] check = new bool[16];

    // 중복되지 않은 랜덤 값을 리턴하는 메서드
    private static int Check()
    {
      Random r = new Random();
      
      while(true)
      {
        int x = r.Next(16); // 0~15
        if(check[x] == false)
        {
          check[x] = true;
          return x;
        }
      }
    }
  }
}
