using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_1_Calculator
{
  public static class ConsoleHelper
  {
    public static void WriteToConsole(string message, ConsoleColor color = ConsoleColor.White, int emptyLinesCout = 0)
    {
      Console.ForegroundColor = color;
      Console.Write(message);
      while(emptyLinesCout > 0)
      {
        Console.WriteLine();
        emptyLinesCout--;
      }
      Console.ResetColor();
    }
  }
}
