using System;

namespace Assignment_4_VendingMachine
{
  class Program
  {
    static void Main(string[] args)
    {


      var vendingMachine = new VendingMachine(Products_Data.GetProducts());
      while (true)
      {
        Console.Clear();
        Console.WriteLine("Lexicon Vending Machine!");
        Console.WriteLine("\n ---------\n|ALL ITEMS|\n ---------\n");

        vendingMachine.DisplayProducts();

        switch (vendingMachine.State)
        {
          case MachineState.InputMoney:
            GettingMonyFromCustomer(vendingMachine);
            break;
          case MachineState.ChooseProduct:
            ChooseProduct(vendingMachine);
            break;
          case MachineState.BuyProduct:
            CheckIfCustomerHaveMonyBeforeBuying(vendingMachine);
            break;
          case MachineState.MoneyIsNotEnough:
            GiveCustomerOptionWhenMoneyIsNotEnough(vendingMachine);
            break;
          case MachineState.Checkout:
            GiveCustomerOptionsAfterFinishBuying(vendingMachine);
            break;
        }
      }
    }

    /// <summary>
    /// Give customer option:
    /// P: To buy new product
    /// E: To exit and get a recipe
    /// </summary>
    /// <param name="vendingMachine"></param>
    private static void GiveCustomerOptionsAfterFinishBuying(VendingMachine vendingMachine)
    {
      Console.WriteLine($"You have {vendingMachine.MonyPool} In Machine Pool!");
      Console.WriteLine($"To product list --P");
      //Console.WriteLine("To take your recipe ------R");
      Console.WriteLine($"Exit the machine --E");
      var userChoice = Console.ReadKey(true).Key.ToString();
      if (userChoice == "P")
      {
        vendingMachine.State = MachineState.ChooseProduct;
      }
      else if (userChoice == "E")
      {
        // ToDo: Save Customer order
        // ToDo: Prepare kvito for the customer
        Console.WriteLine("\n------------------------------------------");
        Console.WriteLine($"Your Change is: { VendingMachine.RetriveCoine(vendingMachine.MonyPool) }");
        Console.WriteLine("------------------------------------------\n");
        Console.ReadKey(true);
        // Reset the machine to resive new customer!
        vendingMachine.State = MachineState.InputMoney;
        vendingMachine.SelectedProductToBuy = null;
        vendingMachine.MonyPool = 0;
        Console.WriteLine("Thank you!");
        Console.ReadKey();
      }
    }

    /// <summary>
    /// When custumer trying to buy product and don't have enough mony give him the below option:
    /// M: To put more money into the maching by going to "InputMoney" state
    /// C: To choose other product by going to "ChooseProduct" state
    /// E: To go to "Checkout" state
    /// </summary>
    /// <param name="vendingMachine"></param>
    private static void GiveCustomerOptionWhenMoneyIsNotEnough(VendingMachine vendingMachine)
    {
      Console.WriteLine($"You have {vendingMachine.MonyPool} In Machine Pool! and you need { Math.Abs(vendingMachine.MonyPool - vendingMachine.SelectedProductToBuy.Price) } more!");
      Console.WriteLine($"Put more money to buy {vendingMachine.SelectedProductToBuy.Name} --M");
      Console.WriteLine($"Change the product --C");
      Console.WriteLine($"Back --E");
      var userChoice = Console.ReadKey(true).Key.ToString();

      if (userChoice == "M")
      {
        // change machine state to ask for money
        vendingMachine.State = MachineState.InputMoney;
      }
      else if (userChoice == "C")
      {
        // change machine state to ask for new product to buy
        vendingMachine.State = MachineState.ChooseProduct;
      }
      else if (userChoice == "E")
      {
        // change machine state to save and customer history
        vendingMachine.State = MachineState.Checkout;
      }
    }

    /// <summary>
    /// Check if customer money is enough
    /// If it is then go to "Checkout" state 
    /// If it's NOT then go to "MoneyIsNotEnough" state
    /// </summary>
    /// <param name="vendingMachine"></param>
    private static void CheckIfCustomerHaveMonyBeforeBuying(VendingMachine vendingMachine)
    {
      if (vendingMachine.CanBuySelectedProduct)
      {
        vendingMachine.BuyProduct();
        Console.ReadKey();
        vendingMachine.State = MachineState.Checkout;
      }
      else
      {
        vendingMachine.State = MachineState.MoneyIsNotEnough;
      }
    }

    /// <summary>
    /// Get the productId(integer) from customer and validate it
    /// If productId valid then go to "BuyProduct" state
    /// If Not then stay at "ChooseProduct" state
    /// </summary>
    /// <param name="vendingMachine"></param>
    private static void ChooseProduct(VendingMachine vendingMachine)
    {
      Console.WriteLine($"You have {vendingMachine.MonyPool} In Machine Pool!");
      Console.WriteLine("Choose what to buy by writing the Product Id: ");
      int.TryParse(Console.ReadLine(), out int productId);
      vendingMachine.SelectProduct(productId);
      if (vendingMachine.SelectedProductToBuy != null)
      {
        // Set the state to buying the selected product
        vendingMachine.State = MachineState.BuyProduct;
      }
    }

    /// <summary>
    /// Get money from customer and validate it
    /// If money valid then go to "ChooseProduct" state
    /// /// If customer have already selected the product then go to "BuyProduct" state
    /// If Not stay at "InputMoney" state
    /// </summary>
    /// <param name="vendingMachine"></param>
    private static void GettingMonyFromCustomer(VendingMachine vendingMachine)
    {
      Console.WriteLine("Money should be input in fixed denominations 1 || 5 || 10 || 20 || 50 || 100 || 500 || 1000.");

      string stringMoney = Console.ReadLine();
      bool isMoneyValid = UserInput.IsMonyValid(stringMoney);
      if (isMoneyValid)
      {
        vendingMachine.MonyPool += int.Parse(stringMoney);

        // Customer havn't choose any product yet
        if (vendingMachine.SelectedProductToBuy == null)
        {
          vendingMachine.State = MachineState.ChooseProduct;
        }
        // Customer was choose the product
        else
        {
          vendingMachine.State = MachineState.BuyProduct;
        }
      }
    }
  }
}
