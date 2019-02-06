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
    public static bool IsMonyValid(string moneyString)
    {
      bool isNumber = int.TryParse(moneyString, out int money);

      bool isMonyValid = isNumber &&
          (money == 1 || money == 5 || money == 10 ||
           money == 20 || money == 50 || money == 100 ||
           money == 500 | money == 1000);

      return isMonyValid;
    }
  }
}
