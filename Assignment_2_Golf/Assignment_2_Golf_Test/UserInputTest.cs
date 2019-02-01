using Assignment_2_Golf;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment_2_Golf_Test
{
  [TestClass]
  public class UserInputTest
  {
    [TestMethod]
    public void Angle_In_Between_0_and_90_Is_Valid_Input()
    {
      // Arrange
      var userInput = new UserInput();
      bool isAngleCorrect;

      // Act
      isAngleCorrect = 
        userInput.IsAngleDegreeValid(10) &&
        userInput.IsAngleDegreeValid(0.01) && 
        userInput.IsAngleDegreeValid(70);

      // Assert
      Assert.IsTrue(isAngleCorrect);
      
    }
    [TestMethod]
    public void Angle_Less_Than_Or_Equal_0_Is_InValid_Input()
    {
      // Arrange
      var userInput = new UserInput();
      bool isAngleCorrect;

      // Act
      isAngleCorrect = 
        userInput.IsAngleDegreeValid(0) ||
        userInput.IsAngleDegreeValid(-10);

      // Assert
      Assert.IsFalse(isAngleCorrect);
    }
    [TestMethod]
    public void Angle_Grater_Than_Or_Equal_90_Is_InValid_Input()
    {
      // Arrange
      var userInput = new UserInput();
      bool isAngleCorrect;

      // Act
      isAngleCorrect = userInput.IsAngleDegreeValid(90)
        || userInput.IsAngleDegreeValid(91);

      // Assert
      Assert.IsFalse(isAngleCorrect);
    }
  }
}
