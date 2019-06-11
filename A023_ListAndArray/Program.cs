using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A023_ListAndArray
{
  class Program
  {
    static void Main(string[] args)
    {
      Random r = new Random();

      for (int i = 0; i < 10; i++)
      {
        int a = r.Next();
        int b = r.Next(100);
        int c = r.Next(10, 20);
        double d = r.NextDouble();

        Console.WriteLine("{0,12}, {1,10}, {2,10}, {3,10:F4}", a, b, c, d);
      }

      // 두 개의 주사위를 100번 던져서 합이 얼마인지 출력하라
      for(int i=0; i<100; i++)
      {
        Console.WriteLine("{0}", r.Next(1,7) + r.Next(1,7));
      }

      // 두 개의 주사위를 1000000번 던져서 각각의 합이 몇번씩 
      // 나왔는지를 출력하시요
      // [출력]
      // 2 : 15678
      // 3 : 245789
      // 4 : 124531
      // ...
      // 12 : 545564
      // 배열이 필요하다 [13]개짜리(0~12)

      int[] cnt = new int[13];
      for (int i = 0; i < 1000000; i++)
      {
        cnt[r.Next(1, 7) + r.Next(1, 7)]++;
      }

      // 출력
      for(int i=2; i<=12; i++)
      {
        Console.WriteLine("{0,2} : {1}", i, cnt[i]);
      }

      Console.WriteLine("foreach array");
      foreach (var item in cnt)
      {
        Console.WriteLine(item);
      }

      // 리스트 : Generic <T> List<T>
      List<int> lst = new List<int>();

      for(int i=0; i<10; i++)
      {
        lst.Add(r.Next(100));
      }

      //foreach(var item in lst)
      //  Console.WriteLine(item);

      Console.WriteLine("for list");
      for (int i=0; i<10; i++)
        Console.WriteLine(lst[i]);  // 마치 배열처럼

      // 마지막으로 
      // 10개짜리 문자열 배열 s1과 문자열 리스트 s2를 만드시오
      string[] s1 = new string[10];
      List<string> s2 = new List<string>();

      // 문자열 10개를 콘솔에서 입력받아 배열과 리스트에 저장하쇼
      Console.WriteLine("문자열 10개를 입력하세요");
      for(int i=0; i<10; i++)
      {
        string s = Console.ReadLine();
        s1[i] = s;
        s2.Add(s);
      }

      // 문자열 10개를 출력
      for(int i=0; i<10; i++)
      {
        Console.WriteLine("{0,20} {1,20}", s1[i], s2[i]);
      }

      // 정렬하여 출력하기
      Array.Sort(s1); // 배열
      s2.Sort();

      Console.WriteLine("배열과 리스트 정렬 후 출력");
      for (int i = 0; i < 10; i++)
      {
        Console.WriteLine("{0,20} {1,20}", s1[i], s2[i]);
      }
    }
  }
}
