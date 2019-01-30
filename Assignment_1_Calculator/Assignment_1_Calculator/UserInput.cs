using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_1_Calculator
{
  class UserInput
  {
    readonly string[] operations = { "a", "s", "m", "d", "r", "c", "e" };

    /// <summary>
    /// Provide information on how the user will interact with the Program
    /// Read user input
    /// Warnning this method will lock the user until he Write the correct operation
    /// </summary>
    /// <returns>a valid operation</returns>
    public string GetOperation()
    {
      do
      {
        Console.WriteLine("Choose your operation!");
        Console.WriteLine("For Adding Numbers Press: a");
        Console.WriteLine("For Substracting Numbers Press: s");
        Console.WriteLine("For Multiplying Numbers Press: m");
        Console.WriteLine("For Dividing Numbers Press: d");
        //Console.WriteLine("To Reset Press: r");
        //Console.WriteLine("To Change Operstion Press: c");
        Console.WriteLine("To Exit Press: e");
        string operation = Console.ReadLine();
        if (operations.Contains(operation))
        {
          return operation;
        }
        Console.WriteLine("\nPlease Choose A Valid Operation! \n");
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
            Console.WriteLine("Please Enter At Least Two Digits! \n");
          }
          else
          {
            return digits;
          }
        }
        catch
        {
          Console.WriteLine("Please Enter A Valid Input! \n");
        }
      }
    }
  }
}
