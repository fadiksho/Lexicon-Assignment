using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_4_VendingMachine
{
  public class VendingMachine
  {
    public int MonyPool { get; set; }

    public IProduct SelectedProductToBuy { get; set; }

    public bool CanBuySelectedProduct
    {
      get
      {
        return SelectedProductToBuy != null && SelectedProductToBuy.Price <= MonyPool;
      }
    }

    public IEnumerable<IProduct> Products { get; private set; }

    public VendingMachine(IEnumerable<Product> products)
    {
      this.Products = products;
    }

    public MachineState State { get; set; } = MachineState.InputMoney;

    /// <summary>
    /// Buying product from the machine
    /// </summary>
    /// <param name="product">the product to buy</param>
    public void BuyProduct()
    {
      MonyPool -= SelectedProductToBuy.Price;
      SelectedProductToBuy.UseProduct();
      Console.ResetColor();
      Console.ReadKey();
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
      Console.WriteLine();
    }

    /// <summary>
    /// Set the property SelectedProductToBuy to Product or Null
    /// </summary>
    /// <param name="id">The product Id</param>
    public void SelectProduct(int id)
    {
      this.SelectedProductToBuy = Products.Where(p => p.Id == id).FirstOrDefault();
    }
  }

  public enum MachineState
  {
    NotWorking,
    InputMoney,
    ChooseProduct,
    BuyProduct,
    MoneyIsNotEnough,
    SaveCutomerOrder,
    NextCustomer
  }
}
