using System;
using System.Linq;

namespace Assignment_1_Calculator
{
  class Program
  {
    static void Main(string[] args)
    {
      string operation = "";
      double result = 0.0;
      bool displayResult = true;
      var mathOperation = new MathOperation();
      var validation = new UserInput();
      
      // Loop To Keep The Program Running!
      while (true)
      {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        ConsoleHelper.WriteToConsole("Lexicon Calculator!", ConsoleColor.White, 2);

        operation = validation.GetOperation();

        if (operation == "e")
        {
          Environment.Exit(0);
        }
        Console.Clear();
        ConsoleHelper.WriteToConsole("Enter The Numbers ex: 4 7 -2 5", ConsoleColor.Green, 1);
        double[] digits = validation.GetDigits();

        switch (operation)
        {
          case "a":
            result = mathOperation.Add(digits);
            break;
          case "s":
            result = mathOperation.Subtract(digits);
            break;
          case "m":
            result = mathOperation.Multiply(digits);
            break;
          case "d":
            var dividendNumber = digits.FirstOrDefault();
            var divisorNumber = mathOperation.Multiply(digits.Skip(1));
            if (divisorNumber == 0)
            {
              displayResult = false;
              ConsoleHelper.WriteToConsole("Opps! Dividing By 0 Is Not A Valid Math Operation!", ConsoleColor.DarkYellow, 1);
              break;
            }
            result = mathOperation.Divide(dividendNumber, divisorNumber);
            break;
        }

        // If There Is Error We Don't have Print The Result
        // Ex: When We Divide By Zero There Is No Result
        if (displayResult)
        {
          ConsoleHelper.WriteToConsole($"\nResult: {result}", ConsoleColor.DarkGreen, 2);
        }

        // Reset The Display Flag Because We Will Get New Input
        displayResult = true;
      }
    }
  }
}
