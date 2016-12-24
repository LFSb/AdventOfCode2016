using System.Collections.Generic;
using System;

namespace Solutions.Models.Day24
{
  public class Node
  {
    public string Name { get; set; }

    public int Distance { get; set; }

    public bool Visited { get; set; }

    public Tuple<int, int> Position { get; set; }

    public List<Node> Neighbors { get; set; } = new List<Node>();

    public int CalculateDistance(Node neighbor) //This will need to be figured out using a BFS. Let's go with the naive approach at first.
    {
      var distance = 0;

      distance += Math.Abs(neighbor.Position.Item1 - this.Position.Item1);

      distance += Math.Abs(neighbor.Position.Item2 - this.Position.Item2);

      return distance;
    }
  }
}