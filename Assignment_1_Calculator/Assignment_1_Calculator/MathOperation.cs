using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_1_Calculator
{
  class MathOperation
  {
    public double Add(double[] numbers)
    {
      return numbers.Sum();
    }

    public double Subtract(double[] numbers)
    {
      double result = numbers[0];
      for (int i = 1; i < numbers.Length; i++)
      {
        result -= numbers[i];
      }
      return result;
    }

    public double Multiply(IEnumerable<double> numbers)
    {
      var result = numbers.Aggregate(1.0, (x, y) => x * y);
      return result;
    }

    public double Divide(double num1, double num2)
    {
      var result = num1 / num2;
      return result;
    }
  }
}
