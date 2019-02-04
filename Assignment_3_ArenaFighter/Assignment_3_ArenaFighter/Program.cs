using System;

namespace Assignment_3_ArenaFighter
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Enter the name of your character: ");
      string playerName = Console.ReadLine(); Console.Clear();

      // Creat the player
      var player = new Character(playerName);

      // Game Loop
      while (!player.IsDead)
      {
        string HuntOrRetire;
        do
        {
          Console.Clear();
          player.PrintCharacterInfo();
          Console.WriteLine("What do you want to do?");
          Console.WriteLine("H - Hunt for an opponent");
          Console.WriteLine("R - Retire from fighting");
          HuntOrRetire = Console.ReadKey(true).Key.ToString();
        } while (!(HuntOrRetire == "H" ^ HuntOrRetire == "R"));

        // Ended the violence
        if (HuntOrRetire == "R")
        {
          Console.WriteLine("You have ended the violence by not fighting.");
          Console.ReadKey(true);
          break;
        }
        // Hunt for an opponent
        else
        {
          // Get random opponent
          var opponent = Character.GetRandomCharacter();

          Console.Clear();
          player.PrintCharacterInfo();
          opponent.PrintCharacterInfo();

          // Creat a battle
          var battle = new Battle(player, opponent);
          // Keep playing rounds untill the battle end
          while (!battle.IsBattleEnd)
          {
            // Creat new round
            var round = new Round(battle);
            Console.ReadKey(true);
            Console.WriteLine("-------------------------");
            // Start the round and print the result
            round.StartRound();
            // Save this round in battle history
            battle.BattleRounds.Add(round);

            // If the battle end reward the winner!
            // Print the winner name
            if (battle.IsBattleEnd)
            {
              Console.ReadKey(true);
              var winer = battle.Player.Health > battle.Opponent.Health
                  ? battle.Player : battle.Opponent;
              winer.Score += 3;
              Console.WriteLine($"\n{winer.Name} is victory");
              Console.ReadKey(true);
            }
          }
        }

        // ToDo remove this line
        // Hunting or Retire
        //break;
      }
      Console.Clear();
      // Print Final Statistics
      player.PrintCharacterFinalStatistics();
      // Print Total Score
      player.PrintCharacterScore();

      Console.ReadKey();
    }
  }
}
