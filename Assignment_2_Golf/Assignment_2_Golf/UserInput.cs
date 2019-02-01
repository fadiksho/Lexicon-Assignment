using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2_Golf
{
  public static class UserInput
  {
    public static bool IsAngleDegreeValid(double angleDegree)
    {
      if (angleDegree > 0 && angleDegree < 90)
      {
        return true;
      }
      return false;
    }

    public static double GetAngleFromUser()
    {
      bool isAngleValueValid = false;
      double angle = 0;
      while (isAngleValueValid)
      {
        isAngleValueValid = double.TryParse(Console.ReadLine(), out angle)
          && IsAngleDegreeValid(angle);
        if(!isAngleValueValid)
        {
          Console.WriteLine("Please Enter A Valid Input!");
        }
      }
      return angle;
    }

    /// <summary>
    /// Read Input From User
    /// Warning This Method Will Lock The Program Untills Get a Valid Input
    /// </summary>
    /// <returns>Digit</returns>
    public static double GetDoubleValueFromUser()
    {
      bool isValidFormat = false;
      isValidFormat = double.TryParse(Console.ReadLine(), out double value);
      while (!isValidFormat)
      {
        Console.WriteLine("Please Enter A Valid Number!");
        isValidFormat = double.TryParse(Console.ReadLine(), out value);
      }
      return value;
    }
  }
}
