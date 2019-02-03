using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_3_ArenaFighter
{
  public class Battle
  {
    public Player Player { get; private set; }
    public Player Opponent { get; private set; }
    public bool IsBattleEnd => (Player.IsDead || Opponent.IsDead);

    public List<Round> BattleRounds { get; set; } 
      = new List<Round>();

    public Battle(Player player, Player opponent)
    {
      this.Player = player;
      this.Player.Battles.Add(this);
      // Add reword for joing the battle!
      this.Player.Score += 2;

      this.Opponent = opponent;
      this.Opponent.Battles.Add(this);
    }
  }
}
