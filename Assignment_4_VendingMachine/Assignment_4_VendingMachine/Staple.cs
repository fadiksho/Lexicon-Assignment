using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
  public class Staple : Product
  {
    public static int StapleCount { get; private set; }

    public Staple(int id, string name) : base(id, name)
    {
      StapleCount += 1;
    }
    
    public override void UseProduct()
    {
      Console.WriteLine($"Do you know that the Staple Food is better than snacks," +
        $"Enjoy eating {this.Name}!");
    }
  }
}
