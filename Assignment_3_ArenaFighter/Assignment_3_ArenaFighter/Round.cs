using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_3_ArenaFighter
{
  public class Round
  {
    public Battle Battle { get; private set; }

    public Round(Battle battle)
    {
      this.Battle = battle;
    }

    public void StartRound()
    {
      var ran = new Random();
      int playerDice = ran.Next(1, 7);
      int opponentDice = ran.Next(1, 7);
      int playerStrengthPlusDice = playerDice + Battle.Player.Strength;
      int opponentStrenghtPlusDice = opponentDice + Battle.Opponent.Strength;

      // Print Rolls
      PrintRolls(playerDice, opponentDice);
     
      // Player attack
      if (playerStrengthPlusDice > opponentStrenghtPlusDice)
      {
        Battle.Opponent.Health -= Battle.Player.Damage;
        PrintTheAttack(playerDice, opponentDice);
      }
      // Opponent attack
      else if (playerStrengthPlusDice < opponentStrenghtPlusDice)
      {
        Battle.Player.Health -= Battle.Opponent.Damage;
        PrintTheAttack(playerDice, opponentDice);
      }
      // Evently matched
      else
      {
        Console.WriteLine("Evenly matched, the combatants circle each other, looking for a better opportunity.");
      }

      // Print Remaining Health
      PrintRemainingHealth();
    }

    private void PrintRolls(int playerDice, int opponentDice)
    {
      Console.WriteLine($"Rolls: " +
        $"{Battle.Player.Name} {Battle.Player.Strength + 2} ({Battle.Player.Strength}+{playerDice})" +
        $" vs " +
        $"{Battle.Player.Name} {Battle.Player.Strength + 2} ({Battle.Opponent.Strength}+{opponentDice})");
    }

    private void PrintRemainingHealth()
    {
      Console.WriteLine($"Remaining Health: " +
        $"{Battle.Player.Name} ({(Battle.Player.Health > 0 ? Battle.Player.Health.ToString() : "Dead")}) " +
        $"{Battle.Opponent.Name} ({(Battle.Opponent.Health > 0 ? Battle.Opponent.Health.ToString() : "Dead")})");
    }

    private void PrintTheAttack(int playerDice, int opponentDice)
    {
      Player attacker;
      Player defender;
      if (playerDice > opponentDice)
      {
        attacker = Battle.Player;
        defender = Battle.Opponent;
        Console.ForegroundColor = ConsoleColor.Green;
      }
      else
      {
        attacker = Battle.Opponent;
        defender = Battle.Player;
        Console.ForegroundColor = ConsoleColor.Red;
      }
      Console.Write($"{attacker.Name} attacks {defender.Name}! " +
        $"{defender.Name} takes {attacker.Damage} damage" + 
        $"{(Battle.IsBattleEnd ? ", and falls to the ground dead." : ".")}");
      Console.ResetColor();
    }
  }
}
