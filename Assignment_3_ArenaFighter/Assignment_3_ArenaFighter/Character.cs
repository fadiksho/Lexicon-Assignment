using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_3_ArenaFighter
{
  public class Character
  {
    public string Name { get; private set; }
    public int Strength { get; private set; }
    public int Damage { get; private set; }
    public int Health { get; set; }
    public int Score { get; set; }
    public bool IsDead
    {
      get
      {
        return Health <= 0;
      }
    }

    public List<Battle> Battles { get; set; }
      = new List<Battle>();

    public Character(string name)
    {
      this.Name = name;
      var rand = new Random();
      this.Strength = rand.Next(4, 8);
      this.Damage = Strength / 2;
      this.Health = rand.Next(5, 10);
    }

    public void PrintCharacterInfo()
    {
      Console.WriteLine($"Name: {this.Name}");
      Console.WriteLine($"Strength: {this.Strength}");
      Console.WriteLine($"Damage: {this.Damage}");
      Console.WriteLine($"Health: {(this.Health > 0 ? this.Health.ToString() : "Dead")}\n");
    }

    public void PrintCharacterScore()
    {
      Console.WriteLine($"{this.Name} total score is {this.Score}.");
    }

    public void PrintCharacterFinalStatistics()
    {
      Console.WriteLine("Final Statistics: \n");
      PrintCharacterInfo();
      foreach (var battle in Battles)
      {
        Console.WriteLine($"{this.Name} " +
          $"{(battle.Opponent.IsDead ? "fought and killed" : "was killed by")} " +
          $"{battle.Opponent.Name}");
      }
    }

    public static Character GetRandomCharacter()
    {
      var names = new string[]
      {
        "Robert De Niro", "Jack Nicholson", "Tom Hanks", "Marlon Brando", "Leonardo DiCaprio", "Humphrey Bogart", "Johnny Depp", "Al Pacino"
      };
      return new Character(names[new Random().Next(0, names.Length)]);
    }
  }
}
