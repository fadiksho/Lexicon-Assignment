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
        new Fruits("Apple") { Price = 24 },
        new Fruits("Orange") { Price = 47 },
        new Staple("Bread") { Price = 16 },
        new Staple("Cereal") { Price = 15 },
        new Staple("Baguette") { Price = 20 },
        new Dessert("Ice Cream") { Price = 40 },
        new Dessert("Cake") { Price = 78 },
        new Dessert("Butterfinger") { Price = 94 },
        new Dessert("Bakers Royale") { Price = 100 },
        new Drink( "Coke", DrinkType.Cold) { Price = 25 },
        new Drink( "Soda", DrinkType.Cold) { Price = 10 },
        new Drink( "Coffee", DrinkType.Hot) { Price = 1 }
      };
    }
  }
}
