using System;

namespace Assignment_4_VendingMachine
{
  class Program
  {
    static void Main(string[] args)
    {


      var vendingMachine = new VendingMachine(Products_Data.GetProducts());

      while (!(vendingMachine.State == MachineState.NotWorking))
      {
        Console.Clear();
        Console.WriteLine("Lexicon Vending Machine!");
        Console.WriteLine("\n ---------\n|ALL ITEMS|\n ---------\n");

        vendingMachine.DisplayProducts();

        // Getting money from customer
        if (vendingMachine.State == MachineState.InputMoney)
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
        // Choose Product
        else if (vendingMachine.State == MachineState.ChooseProduct)
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
        // Buying Product
        else if (vendingMachine.State == MachineState.BuyProduct)
        {
          // Check if user have engough money
          if (vendingMachine.CanBuySelectedProduct)
          {
            vendingMachine.BuyProduct();

            vendingMachine.State = MachineState.SaveCutomerOrder;
          }
          else
          {
            vendingMachine.State = MachineState.MoneyIsNotEnough;
          }
        }
        // When customer money isn't enough to buy product
        else if (vendingMachine.State == MachineState.MoneyIsNotEnough)
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
            vendingMachine.State = MachineState.SaveCutomerOrder;
          }
        }
        // Save customer history & exit
        else if (vendingMachine.State == MachineState.SaveCutomerOrder)
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
            Console.WriteLine($"Your Change is: {vendingMachine.MonyPool}");
            Console.WriteLine("------------------------------------------\n");
            Console.ReadKey(true);
            // reset the machine to resive new customer!
            vendingMachine.State = MachineState.InputMoney;
            vendingMachine.SelectedProductToBuy = null;
            vendingMachine.MonyPool = 0;
            Console.WriteLine("Thank you!");
            Console.ReadKey();
          }
        }
      }
    }
  }
}
