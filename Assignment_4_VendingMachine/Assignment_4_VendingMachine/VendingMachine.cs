using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
  public class VendingMachine
  {
    public int MonyPool { get; set; }

    public IEnumerable<IProduct> Products { get; private set; }
    
    public VendingMachine(IEnumerable<Product> products)
    {
      this.Products = products;
    }
    
    /// <summary>
    /// Buying product from the machine
    /// </summary>
    /// <param name="product">the product to buy</param>
    /// <returns>wether the buying succeded or not</returns>
    public bool BuyProduct(IProduct product)
    {
      if(MonyPool >= product.Price)
      {
        MonyPool -= product.Price;
        product.UseProduct();
        return true;
      }
      else
      {
        Console.WriteLine($"You don't have enough mony to buy {product.Name}!");
        return false;
      }
    }

    /// <summary>
    /// Display all product information in the machine
    /// </summary>
    public void DisplayProducts()
    {
      foreach (var product in Products)
      {
        product.DisplayProductInfo();
      }
    }
  }
}
