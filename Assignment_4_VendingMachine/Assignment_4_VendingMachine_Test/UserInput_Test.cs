using Assignment_4_VendingMachine;
using System;
using Xunit;

namespace Assignment_4_VendingMachine_Test
{
  public class UserInput_Test
  {
    [Theory]
    [InlineData("1")]
    [InlineData("5")]
    [InlineData("10")]
    [InlineData("20")]
    [InlineData("50")]
    [InlineData("100")]
    [InlineData("500")]
    [InlineData("1000")]
    public void MonyInputValidWhenIsInFixedDenominations(string money)
    {
      Assert.True(UserInput.IsMonyValid(money));
    }
  }
}
