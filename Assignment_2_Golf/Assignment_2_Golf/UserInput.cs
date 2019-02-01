using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2_Golf
{
  public class UserInput
  {
    public bool IsAngleDegreeValid(double angleDegree)
    {
      if (angleDegree > 0 && angleDegree < 90)
      {
        return true;
      }
      return false;
    }
  }
}
