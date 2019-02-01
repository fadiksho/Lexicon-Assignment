using System;

namespace Assignment_2_Golf
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Golf Game!");
      Console.WriteLine("Choose The Studiom Size: ");
      double studiomSiz = double.Parse(Console.ReadLine());
      // Intialize The Game
      var golfGame = new GolfGame(studiomSiz, maxSwingCount: 10);
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

        // Move The Ball To New Location
        golfGame.Swing(angle, velocity);

        golfGame.PrintGameStatus();

        // Keep Playing Untill Losing Or Winning
        if (golfGame.GameResult != GameResult.Playing)
        {
          Console.WriteLine(golfGame.GameStatusText);
          Console.WriteLine("To Play Again Press P To Exit Any Thing Else.");
          var userInput = Console.ReadLine();
          // To Restart The Game If True
          if (String.Compare("p", userInput, true) == 0)
          {
            Console.Clear();
            Console.WriteLine("Choose The Studiom Size: ");
            studiomSiz = double.Parse(Console.ReadLine());
            golfGame = new GolfGame(studiomSiz, maxSwingCount: 10);
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
