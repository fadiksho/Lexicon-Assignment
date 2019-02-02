using System;

namespace Assignment_2_Golf
{
  public class GolfGame
  {
    public GolfGame(double stadSize, int maxSwingCount)
    {
      this.StadSize = stadSize;
      this.CupLocation = stadSize / 2;
      this.MaxSwingCount = maxSwingCount;
      this.GameResult = GameResult.Playing;
    }

    public double BallLocation { get; set; }
    public double CupLocation { get; }
    public double StadSize { get; private set; }
    public double DistancBetweenBallAndCup
    {
      get
      {
        return Math.Abs(this.BallLocation - this.CupLocation);
      }
    }
    public int SwingCount { get; set; }
    public int MaxSwingCount { get; private set; }
    public GameResult GameResult { get; set; }
    public string GameStatusText { get; private set; }

    /// <summary>
    /// Move the ball towards the cup location
    /// </summary>
    /// <param name="swing">Instanc of Swing Class</param>
    public void MoveBall(Swing swing)
    {
      this.SwingCount += 1;
      // Check to which direction the ball should go
      if (this.BallLocation < this.CupLocation)
        BallLocation += swing.Distance;
      else
      {
        BallLocation = Math.Abs(BallLocation - swing.Distance);
      }

      // After moving the ball we check for win or failure condition
      UpdateStatus();
    }

    /// <summary>
    /// Check If The Game Ended & Set The "GameStatusText" Accordingly
    /// </summary>
    private void UpdateStatus()
    {
      // Win: hit the cup
      if (DistancBetweenBallAndCup == 0)
      {
        GameResult = GameResult.victory;
        GameStatusText = $"Congrats You Win!";
      }
      // Failure: reached the maximus amout of swings
      else if (SwingCount >= MaxSwingCount)
      {
        GameResult = GameResult.failure;
        GameStatusText = $"Game Over You LoSe After Exceeding All Your Swings!";
      }
      // Failure: ball exceeded the stadiom
      else if (BallLocation > StadSize)
      {
        GameResult = GameResult.failure;
        GameStatusText = $"Game Over You LoSe! The Ball Is Outside The Stadium!";
      }
    }
    
    public void PrintGameStatus()
    {
      Console.WriteLine($"Galf Ball Point: {this.BallLocation}");
      Console.WriteLine($"Distanc Between Ball & Cup: {this.DistancBetweenBallAndCup}.");
      Console.WriteLine($"Available Swing: {this.MaxSwingCount - this.SwingCount} of {this.MaxSwingCount}\n");
    }
  }
}

public enum GameResult
{
  Playing,
  victory,
  failure
}
