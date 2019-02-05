using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
  public class Products_Data
  {
    public static List<Product> GetProducts()
    {
      return new List<Product>()
      {
        new Fruits(1, "Apple") { Price = 24 },
        new Fruits(2, "Orange") { Price = 47 },
        new Staple(3, "Bread") { Price = 16 },
        new Staple(4, "Cereal") { Price = 15 },
        new Staple(5, "Baguette") { Price = 20 },
        new Dessert(6, "Ice Cream") { Price = 40 },
        new Dessert(7, "Cake") { Price = 78 },
        new Dessert(8, "Butterfinger") { Price = 94 },
        new Dessert(9, "Bakers Royale") { Price = 100 },
        new Drink(10, "Coke", DrinkType.Cold) { Price = 25 },
        new Drink(11, "Soda", DrinkType.Cold) { Price = 10 },
        new Drink(12, "Coffee", DrinkType.Hot) { Price = 1 }
      };
    }
  }
}
