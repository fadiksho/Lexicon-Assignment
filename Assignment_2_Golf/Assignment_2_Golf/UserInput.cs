using System;

namespace Assignment_2_Golf
{
  public static class UserInput
  {
    /// <summary>
    /// Indicate wether the givin value is range 0 < value < 90
    /// </summary>
    /// <param name="angleDegree">the double to test</param>
    /// <returns>true if in valid range 0 < value < 90</returns>
    public static bool IsAngleDegreeValid(double angleDegree)
    {
      if (angleDegree > 0 && angleDegree < 90)
      {
        return true;
      }
      return false;
    }
    
    /// <summary>
    /// Indicate wether the givin value is positive
    /// </summary>
    /// <param name="velocity">the double to test</param>
    /// <returns></returns>
    public static bool IsVelocityPositive(double velocity)
    {
      return velocity >= 0;
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
