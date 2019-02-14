using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
  public class Staple : Product
  {
    public static int StapleProductCount { get; private set; }

    public Staple(string name) : base( name)
    {
      StapleProductCount += 1;
    }
    
    public override void UseProduct()
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"Do you know that the Staple Food is better than snacks," +
        $"Enjoy eating {this.Name}!");
    }
  }
}
