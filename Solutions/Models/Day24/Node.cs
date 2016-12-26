using System.Collections.Generic;
using System;

namespace Solutions.Models.Day24
{
  public class Node
  {
    public string Name { get; set; }

    public int Distance { get; set; }

    public int TotalDistance { get; set; }

    public bool Visited { get; set; }

    public Node Parent { get; set; }

    public List<Node> Path { get; set; } = new List<Node>();

    public Tuple<int, int> Position { get; set; }

    public List<Node> Neighbors { get; set; } = new List<Node>();

    //This will need to be figured out using a BFS. Let's go with the simple approach at first.
    public int CalculateDistance(Node neighbor, int?[][] grid) 
    {
      //return Math.Abs(neighbor.Position.Item1 - this.Position.Item1) + Math.Abs(neighbor.Position.Item2 - this.Position.Item2);

      var steps = 0;
      var queue = new Queue<BotState>();

      while(steps == 0)
      {
        queue.Enqueue(new BotState
        {
          Steps = 0,
          Position = this.Position
        });

        var currentState = queue.Dequeue();
        
        if(currentState.Position.Item1 == neighbor.Position.Item1 && currentState.Position.Item2 == neighbor.Position.Item2)
        {
          //System.Console.WriteLine("Found {0}!", neighbor.Name);
          steps = currentState.Steps;
        }
        else
        {
          var nextSteps = currentState.ReturnPossibleStates(grid);

          foreach(var step in nextSteps)
          {
            queue.Enqueue(new BotState
            {
              Steps = currentState.Steps + 1,
              Position = step
            });
          }
        }
      }

      return steps;
    }
  }
}