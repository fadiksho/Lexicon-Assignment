using System;

namespace Assignment_2_Golf
{
  class Program
  {
    static void Main(string[] args)
    {
      // Max amount of swing that the user can take
      int maxSwingCount = 4;

      Console.WriteLine("Golf Game!");
      Console.WriteLine("Choose The Studiom Size: ");
      double studiomSiz = UserInput.GetDoubleValueFromUser();
      // Intialize The Game
      var golfGame = new GolfGame(studiomSiz, maxSwingCount);
      golfGame.PrintGameStatus();
      while (golfGame.GameResult == GameResult.Playing)
      {
        Console.Write("Enter The Angle In Degree: ");
        var angle = UserInput.GetDoubleValueFromUser();
        while (!UserInput.IsAngleDegreeValid(angle))
        {
          Console.WriteLine("The Angle Should Be Between 0 & 90");
          angle = UserInput.GetDoubleValueFromUser();
        }
        Console.Write("Enter The Velocity: ");
        var velocity = UserInput.GetDoubleValueFromUser();

        // Create new swing
        var swing = new Swing(angle, velocity);

        // Move The Ball To New Location
        golfGame.MoveBall(swing);

        golfGame.PrintGameStatus();

        // Keep Playing Untill Losing Or Winning
        if (golfGame.GameResult != GameResult.Playing)
        {
          Console.WriteLine(golfGame.GameStatusText + "\n");
          Console.WriteLine("To Play Again Press P To Exit Press Any Thing Else.");
          var userInput = Console.ReadLine();
          // To Restart The Game If True
          if (String.Compare("p", userInput, true) == 0)
          {
            Console.Clear();
            Console.WriteLine("Choose The Studiom Size: ");
            studiomSiz = UserInput.GetDoubleValueFromUser();
            golfGame = new GolfGame(studiomSiz, maxSwingCount);
            golfGame.PrintGameStatus();
          }
          // To Exit
          else
          {
            Environment.Exit(0);
          }
        }
      }
    }
  }
}
