using System.Text;

namespace Solutions.Models.Day15
{
  public class Disc
  {
    public int Positions { get; private set;}

    public int CurrentPosition { get; private set; }

    public Disc(string input)
    {
      var split = input.Split(' ');

      Positions = int.Parse(split[3]) - 1;

      CurrentPosition = int.Parse(split[11].Trim('.')) - 1;      
    }

    public void Tick()
    {
      if(CurrentPosition < Positions)
      {
        CurrentPosition++;
      }
      else
      {
        CurrentPosition = 0;
      }

      var positions = new StringBuilder();
      positions.Append(new string('#', Positions + 1));
      positions[CurrentPosition] = ' ';

      System.Console.WriteLine(positions.ToString());
    }
  }
}