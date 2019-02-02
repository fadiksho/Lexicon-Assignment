namespace Assignment_2_Golf
{
  public class Swing
  {
    public double Distance { get; private set; }

    public Swing(double angleInDegree, double vilocity)
    {
      Distance = PhysicMethodHelper.CalculateDistance(angleInDegree, vilocity);
    }
  }
}
