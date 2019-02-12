using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_3_ArenaFighter
{
  public class Character
  {
    static var rand = new Random();

    public string Name { get; private set; }
    public int Strength { get; private set; }
    public int Damage { get; private set; }
    public int Health { get; set; }
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
      
      this.Strength = rand.Next(4, 8);
      this.Damage = Strength / 2;
      this.Health = rand.Next(5, 10);
    }

    public Character(string name, int strength, int damage, int health)
    {
      this.Name = name;
      this.Strength = strength;
      this.Damage = damage;
      this.Health = health;
    }

    public int GetPlayerScore()
    {
      int score = 0;
      foreach (var battle in Battles)
      {
        // Reword with 2 for each battle the player join
        score += 2;
        if (battle.IsBattleEnd && battle.Opponent.Health <= 0)
        {
          // Reword with 3 for each battle the player win
          score += 3;
        }
      }
      return score;
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
      Console.WriteLine($"{this.Name} total score is {this.GetPlayerScore()}.");
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
