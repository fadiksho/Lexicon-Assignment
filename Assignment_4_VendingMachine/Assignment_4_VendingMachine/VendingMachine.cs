using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_4_VendingMachine
{
  public class VendingMachine
  {
    public static readonly int[] AcceptedCoins =
      new int[8] { 1, 5, 10, 20, 50, 100, 500, 1000 };

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
      SelectedProductToBuy = null;
      Console.ResetColor();
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

    /// <summary>
    /// Retrive the user mony as a coins
    /// </summary>
    /// <param name="monyPool">Integer value, the mony the user put in the machine</param>
    /// <returns>String value represent the retrived mony</returns>
    public static string RetriveCoine(int monyPool)
    {
      var retriveAmountDic = new Dictionary<int, int>();
      int index = AcceptedCoins.Length - 1;

      while (monyPool != 0)
      {
        if (AcceptedCoins[index] <= monyPool)
        {
          if (retriveAmountDic.ContainsKey(AcceptedCoins[index]))
          {
            var value = retriveAmountDic[AcceptedCoins[index]] + 1;

            retriveAmountDic[AcceptedCoins[index]] = value;
          }
          else
          {
            retriveAmountDic.Add(AcceptedCoins[index], 1);
          }
          monyPool -= AcceptedCoins[index];
        }
        else
        {
          index -= 1;
        }
      }

      var stb = new StringBuilder();
      foreach (var coin in retriveAmountDic)
      {
        stb.Append($"({coin.Value}){coin.Key}kr ");
      }

      return stb.ToString();
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
