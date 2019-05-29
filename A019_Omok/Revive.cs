using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A019_Omok
{
  class Revive
  {
    public int X { get; set; }  // 속성, Property
    public int Y { get; set; } // 필드
    public STONE Stone  { get; set; }
    public int Seq { get; set; }

    public Revive(int x, int y, STONE s, int seq)
    {
      this.X = x;
      this.Y = y;
      this.Stone = s;
      this.Seq = seq;
    }
  }
}
