using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2_Golf
{
  public class GolfGame
  {
    public GolfGame(double stadSize, int maxSwingCount)
    {
      this.StadSize = stadSize;
      this.GolLocation = stadSize / 2;
      this.MaxSwingCount = maxSwingCount;
      this.GameResult = GameResult.Playing;
    }

    public double BallLocation { get; set; }
    public double GolLocation { get; }
    public double StadSize { get; private set; }
    public double DistancBetweenBallAndGol
    {
      get
      {
        return Math.Abs(this.BallLocation - this.GolLocation);
      }
    }
    public int SwingCount { get; set; }
    public int MaxSwingCount { get; private set; }
    public GameResult GameResult { get; set; }
    public string GameStatusText { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="angleInDegree"></param>
    /// <param name="vilocity"></param>
    public void Swing(double angleInDegree, double vilocity)
    {
      this.SwingCount += 1;
      // Calculate how far the ball should move
      var distanceToNewLocation = PhysicMethodHelper.CalculateDistance(angleInDegree, vilocity);
      // Set the new ball location
      this.MoveTheBallTowardGolLocation(distanceToNewLocation);
      // EveryTime Swing Happend Update The Game Variable
      // GameResult:     Playing | victory | failure
      // GameStatusText: Display User Progress Throw The Game
      UpdateStatus();
    }

    private void MoveTheBallTowardGolLocation(double value)
    {
      // Check to which direction the ball should go
      if (this.BallLocation < this.GolLocation)
        BallLocation += value;
      else
      {
        BallLocation = Math.Abs(BallLocation - value);
      }
    }

    /// <summary>
    /// Check If The Game Ended & Set The "GameStatusText" Accordingly
    /// </summary>
    private void UpdateStatus()
    {
      if (DistancBetweenBallAndGol == 0)
      {
        GameResult = GameResult.victory;
        GameStatusText = $"Congrats You Win!";
      }
      else if (SwingCount >= MaxSwingCount)
      {
        GameResult = GameResult.failure;
        GameStatusText = $"Game Over You LoSe After Exceeding All Your Swings!";
      }
      else if (BallLocation > StadSize)
      {
        GameResult = GameResult.failure;
        GameStatusText = $"Game Over You LoSe! The Ball Is Outside The Stadium!";
      }
    }

    public void PrintGameStatus()
    {
      Console.WriteLine($"Ball Location:   {this.BallLocation}.");
      Console.WriteLine($"Gol  Location:   {this.GolLocation}.");
      Console.WriteLine($"Distanc Between Ball & Gol  Location:   {this.DistancBetweenBallAndGol}.");
      Console.WriteLine($"Available Swing: {this.MaxSwingCount - this.SwingCount}. \n");
    }
  }
}

public enum GameResult
{
  Playing,
  victory,
  failure
}
