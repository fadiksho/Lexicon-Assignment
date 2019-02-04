using Assignment_3_ArenaFighter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment_3_ArenaFighter_Test
{
  [TestClass]
  public class Battle_Test
  {
    [TestMethod]
    public void Player_Without_Any_Battle_Have_Score_Of_Zero()
    {
      // Arrange
      var player1 = Character.GetRandomCharacter();
      
      // Act
      
      // Assert
      Assert.AreEqual(player1.GetPlayerScore(), 0);
    }
    [TestMethod]
    public void Players_Joins_Battle_Get_Reword_By_Increasing_There_Score_By_Two()
    {
      // Arrange
      var player1 = Character.GetRandomCharacter();
      var player2 = Character.GetRandomCharacter();
      Battle battle;
      // Act
      battle = new Battle(player1, player2);
      // Assert
      Assert.AreEqual(player1.GetPlayerScore(), 2);
      Assert.AreEqual(player2.GetPlayerScore(), 2);
    }
    [TestMethod]
    public void Battle_Should_End_When_One_Of_The_Player_Is_Dead()
    {
      // Arrange
      var player = new Character("Player1", 20, 10, 10);
      var player2 = new Character("Player2", 1, 1, 1);
      var battle = new Battle(player, player2);
      var round = new Round(battle);
      // Act
      round.StartRound();
      // Assert
      Assert.IsTrue(battle.IsBattleEnd);
    }
    [TestMethod]
    public void Player_With_One_Battle_Win_Have_Score_Of_5()
    {
      // Arrange
      var player = new Character("Player1", 20, 10, 10);
      var player2 = new Character("Player2", 1, 1, 1);

      var battle1 = new Battle(player, player2);
      var round1 = new Round(battle1);

      // Act
      round1.StartRound();
      // Assert
      Assert.AreEqual(player.GetPlayerScore(), 5);
    }
  }
}
