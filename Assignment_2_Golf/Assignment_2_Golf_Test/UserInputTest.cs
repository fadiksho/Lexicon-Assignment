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
      bool isAngleCorrect;

      // Act
      isAngleCorrect = 
        UserInput.IsAngleDegreeValid(10) &&
        UserInput.IsAngleDegreeValid(0.01) && 
        UserInput.IsAngleDegreeValid(70);

      // Assert
      Assert.IsTrue(isAngleCorrect);
      
    }
    [TestMethod]
    public void Angle_Less_Than_Or_Equal_0_Is_InValid_Input()
    {
      // Arrange
      bool isAngleCorrect;

      // Act
      isAngleCorrect = 
        UserInput.IsAngleDegreeValid(0) ||
        UserInput.IsAngleDegreeValid(-10);

      // Assert
      Assert.IsFalse(isAngleCorrect);
    }
    [TestMethod]
    public void Angle_Grater_Than_Or_Equal_90_Is_InValid_Input()
    {
      // Arrange
      bool isAngleCorrect;

      // Act
      isAngleCorrect = UserInput.IsAngleDegreeValid(90)
        || UserInput.IsAngleDegreeValid(91);

      // Assert
      Assert.IsFalse(isAngleCorrect);
    }
    [TestMethod]
    public void Velocity_Is_InValid_When_Value_Is_Negative()
    {
      // Arrange
      var velocity = -10;
      // Act
      bool isValid = UserInput.IsVelocityPositive(velocity);
      // Assert
      Assert.IsFalse(isValid);
    }
  }
}
