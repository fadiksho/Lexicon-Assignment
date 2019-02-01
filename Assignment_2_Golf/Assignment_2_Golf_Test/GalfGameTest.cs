using Assignment_2_Golf;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment_2_Golf_Test
{
  [TestClass]
  public class GalfGameTest
  {
    [TestMethod]
    public void Swing_Count_Should_Increase_After_Swinging()
    {
      // Arange
      var golfGame = new GolfGame(1000, 3);
      // Act
      golfGame.Swing(10, 50);
      // Assert
      Assert.AreEqual(golfGame.SwingCount, 1);
    }
    [TestMethod]
    public void Game_In_Failure_After_The_Max_Swing_Counter_Exceeded_And_Ball_Not_Hit_Target()
    {
      // Arange
      var golfGame = new GolfGame(1000, 3);
      // Act
      golfGame.Swing(10, 50);
      golfGame.Swing(10, 50);
      golfGame.Swing(10, 50);
      // Assert
      Assert.AreEqual(GameResult.failure, golfGame.GameResult);
    }
    [TestMethod]
    public void Game_In_Victory_After_The_Ball_Hit_The_Gol()
    {
      // Arrange
      // When Angule = 45 & Velocity = 56
      // The  Destance = 320;
      // We Hit The Target If 
      // The Ball Location = 0
      // The Gol Location = 640(stadSize)/2
      var golfGame = new GolfGame(stadSize: 640, maxSwingCount: 5);
      // Act
      golfGame.Swing(45, 56);
      // Assert
      Assert.AreEqual(GameResult.victory, golfGame.GameResult);
    }
    [TestMethod]
    public void Game_In_Failure_After_Exceeding_The_Stadium_Boundary()
    {
      // Arrange
      // When Angule = 45 & Velocity = 56
      // The  Destance = 320;
      // We Hit The Target If 
      // The Ball Location = 0
      // The Gol Location = 640(stadSize)/2
      var golfGame = new GolfGame(stadSize: 640, maxSwingCount: 5);
      // Act
      golfGame.Swing(45, 112);
      // Assert
      Assert.AreEqual(GameResult.failure, golfGame.GameResult);
    }
    [TestMethod]
    public void Game_In_Playing_If_Ball_Location_On_Boundary_And_Not_Exceed_Max_Swing_Count()
    {
      // Arrange
      // When Angule = 45 & Velocity = 56
      // The  Destance = 320;
      // We Hit The Target If 
      // The Ball Location = 0
      // The Gol Location = 320(stadSize)/2 = 160
      var golfGame = new GolfGame(stadSize: 320, maxSwingCount: 5);
      // Act
      golfGame.Swing(45, 56);
      // Assert
      Assert.AreEqual(GameResult.Playing, golfGame.GameResult);
    }
  }
}
