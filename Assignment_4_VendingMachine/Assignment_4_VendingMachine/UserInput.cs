using System;
using System.Collections.Generic;
using System.Linq;
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

      bool isMonyValid = isNumber && VendingMachine.AcceptedCoins.Contains(money);

      return isMonyValid;
    }
  }
}
