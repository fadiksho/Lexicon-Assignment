using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_1_Calculator
{
  class UserInput
  {
    readonly string[] operations = { "a", "s", "m", "d", "e" };

    /// <summary>
    /// Provide information on how the user will interact with the Program
    /// Read user input
    /// Warnning this method will lock the user until getting the correct operation
    /// </summary>
    /// <returns>A valid operation</returns>
    public string GetOperation()
    {
      do
      {
        ConsoleHelper.WriteToConsole("For Addition......Press: ");
        ConsoleHelper.WriteToConsole("a", ConsoleColor.Blue, emptyLinesCout: 1);
        ConsoleHelper.WriteToConsole("For Substracting..Press: ");
        ConsoleHelper.WriteToConsole("s", ConsoleColor.Blue, emptyLinesCout: 1);
        ConsoleHelper.WriteToConsole("For Multiplying...Press: ");
        ConsoleHelper.WriteToConsole("m", ConsoleColor.Blue, emptyLinesCout: 1);
        ConsoleHelper.WriteToConsole("For Dividing......Press: ");
        ConsoleHelper.WriteToConsole("d", ConsoleColor.Blue, emptyLinesCout: 1);
        ConsoleHelper.WriteToConsole("To  Exit..........Press: ", ConsoleColor.Red);
        ConsoleHelper.WriteToConsole("e", ConsoleColor.Blue, emptyLinesCout: 1);
        string operation = Console.ReadLine();
        if (operations.Contains(operation))
        {
          return operation;
        }
        Console.Clear();
        ConsoleHelper.WriteToConsole("Please Choose A Valid Operation!", ConsoleColor.DarkYellow, 1);
      } while (true);
    }

    /// <summary>
    /// Read user input
    /// Warning this method will lock the user until entering a valid Input
    /// </summary>
    /// <returns>Array of double numbers Not less than (TWO)</returns>
    public double[] GetDigits()
    {
      while (true)
      {
        string input = Console.ReadLine();
        try
        {
          var digits = input.Trim().Split(" ").Select(Double.Parse).ToArray();
          if (digits.Length < 2)
          {
            ConsoleHelper.WriteToConsole("Please Enter At Least Two Digits!", ConsoleColor.DarkYellow, 1);
          }
          else
          {
            return digits;
          }
        }
        catch
        {
          ConsoleHelper.WriteToConsole("Please Enter A Valid Input!", ConsoleColor.DarkYellow, 1);
        }
      }
    }
  }
}
