using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
  public class UserInput
  {
    /// <summary>
    /// Check wether the mony is in this denominations values: 
    /// 1 || 5 || 10 || 20 || 50 || 100 || 500 || 1000
    /// </summary>
    /// <param name="mony">The amount of mony to check</param>
    /// <returns></returns>
    public bool IsMonyValid(int mony)
    {
      bool isMonyValid = mony == 1 || mony == 5 || mony == 10
        || mony == 20 || mony == 50 || mony == 100 
        || mony == 500 | mony == 1000;

      return isMonyValid;
    }
  }
}
