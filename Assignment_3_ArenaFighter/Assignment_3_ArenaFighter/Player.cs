using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_3_ArenaFighter
{
  public class Player
  {
    public string Name { get; private set; }
    public int Strength { get; set; }
    public int Damage { get; set; }
    public int Health { get; set; }
    public int Score { get; set; }
    public bool IsDead
    {
      get
      {
        return Health > 0;
      }
    }

    public List<Battle> Battles { get; set; }
      = new List<Battle>();

    public Player(string name)
    {
      this.Name = name;
    }

    public void PrintPlayerInfo()
    {
      Console.WriteLine($"Name: {this.Name}");
      Console.WriteLine($"Strength: {this.Strength}");
      Console.WriteLine($"Damage: {this.Damage}");
      Console.WriteLine($"Health: {(this.Health > 0 ? this.Damage.ToString() : "Dead")}");
    }

    public void PrintPlayerScore()
    {
      Console.WriteLine($"{this.Name} total score is {this.Score}.");
    }

    public void PrintPlayerFinalStatistics()
    {
      foreach (var battle in Battles)
      {
        Console.WriteLine($"{this.Name} " +
          $"{(battle.Opponent.IsDead ? "fought and killed" : "was killed by ")}" +
          $"{battle.Opponent.Name}");
      }
    }
  }
}
