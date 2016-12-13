using System;
using System.Collections;
using System.Collections.Generic;

namespace Solutions.Models.Day13
{
  public class Maze
  {
    public int[][] Grid { get; set;}

    public Maze(int seed, int mazeSizeY, int mazeSizeX)
    {
      Grid = new int[mazeSizeY][];

      for(var y = 0; y < Grid.Length; y++)
      {
        Grid[y] = new int[mazeSizeX];

        for(var x = 0; x < Grid[y].Length; x++)
        {
          int amountOf1s = 0;
          
          var bitArray = new BitArray(
            new int[]{
              seed + (x * x + 3 * x + 2 * x * y + y + y * y)
            }
          );
          
          foreach(bool bit in bitArray)
          {
            if(bit)
            {
              amountOf1s++;
            }
          }

          Grid[y][x] = amountOf1s;
        }
      }
    }

    public void PrintMaze(Tuple<int, int> currentPosition, List<Tuple<int, int>> coordinatesVisited)
    {
      for(var y = 0; y < Grid.Length; y++)
        {
          for(var x = 0; x < Grid[y].Length; x++)
          {
            if(y == currentPosition.Item1 && x == currentPosition.Item2 || coordinatesVisited.Contains(new Tuple<int, int>(y, x)))
            {
              System.Console.Write("O");
            }
            else
            {
              System.Console.Write(Grid[y][x] % 2 == 0 ? "." : "#");
            }          
          }

          System.Console.WriteLine();
        }
    }
  }
}