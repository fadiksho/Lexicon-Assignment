using System;

namespace Assignment_1_Calculator
{
  class Program
  {


    static void Main(string[] args)
    {
      string operation = "";
      double result = 0.0;
      bool displayResult = true;
      Console.WriteLine("Welcome To Lexicon Calculator!");

      MathOperation mathOperation = new MathOperation();
      UserInput validation = new UserInput();

      // Loop To Keep The Program Running!
      while (true)
      {
        operation = validation.GetOperation();

        if (operation == "e")
        {
          Environment.Exit(0);
        }
        Console.WriteLine("Enter The Numbers ex: 4 7");
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
            if (digits[1] == 0)
            {
              displayResult = false;
              Console.WriteLine("Opps! Dividing By 0 Is Not A Valid Math Operation! \n");
              break;
            }
            result = mathOperation.Divide(digits[0], digits[1]);
            break;
        }

        // If There Is Error We Don't have Print The Result
        // Ex: When We Divide By Zero There Is No Result
        if (displayResult)
        {
          Console.WriteLine($"\nResult: {result} \n");
        }

        // Reset The Display Flag Because We Will Get New Input
        displayResult = true;
      }
    }
  }
}
