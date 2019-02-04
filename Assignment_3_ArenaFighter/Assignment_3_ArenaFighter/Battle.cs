using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_3_ArenaFighter
{
  public class Battle
  {
    public Character Player { get; private set; }
    public Character Opponent { get; private set; }
    public bool IsBattleEnd => (Player.IsDead || Opponent.IsDead);

    public List<Round> BattleRounds { get; set; } 
      = new List<Round>();

    public Battle(Character player, Character opponent)
    {
      this.Player = player;
      this.Player.Battles.Add(this);

      this.Opponent = opponent;
      this.Opponent.Battles.Add(this);
    }
  }
}
