using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2_Golf
{
  public static class PhysicMethodHelper
  {
    public static double CalculateDistance(double angleInDegree, double vilocity)
    {
      // Convert Angle Degree To Radians
      var angleInRadians = Math.PI / 180 * angleInDegree;
      // Calculate The Distanc Low
      return Math.Round(Math.Pow(vilocity, 2) / 9.8 * Math.Sin(2 * angleInRadians));
    }
  }
}
