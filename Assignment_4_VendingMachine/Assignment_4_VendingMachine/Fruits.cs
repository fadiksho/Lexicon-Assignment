using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
  public class Fruits : Product
  {
    public static int FruitsProductCount { get; set; }

    public Fruits(string name) : base(name)
    {
      
    }

    public override void UseProduct()
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"Peel the {this.Name} and start eating!");
    }
  }
}
