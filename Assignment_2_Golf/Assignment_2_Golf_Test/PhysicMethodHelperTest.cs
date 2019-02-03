using Assignment_2_Golf;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment_2_Golf_Test
{
  [TestClass]
  public class PhysicMethodHelperTest
  {
    [TestMethod]
    public void Get_Valid_Distanc_When_Giving_Angle_And_Velocity()
    {
      // Arrange
      var angleInDegree = 45;
      var velocity = 56;

      // Act
      var distance = PhysicMethodHelper.CalculateDistance(angleInDegree, velocity);
      var expectedDistance = 320;

      // Assert
      Assert.AreEqual(distance, expectedDistance);
    }
  }
}
