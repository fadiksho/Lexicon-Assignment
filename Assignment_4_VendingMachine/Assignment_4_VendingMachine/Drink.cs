using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
  public class Drink : Product
  {
    public static int DrinkProductCount { get; set; }

    public DrinkType DrinkType { get; private set; }

    public Drink(string name, DrinkType type) : base(name)
    {
      DrinkType = type;
    }

    public override void UseProduct()
    {
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine($"Drink The {this.Name}!");
    }

    public override void DisplayProductInfo()
    {
      base.DisplayProductInfo();
      Console.WriteLine($"|-----({this.DrinkType.ToString()}) Drink!");
    }
  }

  public enum DrinkType
  {
    Hot,
    Cold
  }
}
