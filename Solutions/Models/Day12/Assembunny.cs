using System.Collections.Generic;

namespace Solutions.Models.Day12
{
  public class Assembunny
  {
    public Dictionary<char, int> Registers { get; set; } = new Dictionary<char, int>();

    public Assembunny(bool part2)
    {
      if(part2)
      {
        Registers.Add('a', 0);
        Registers.Add('b', 0);
        Registers.Add('c', 1);
        Registers.Add('d', 0);
      }
      else
      {
        Registers.Add('a', 0);
        Registers.Add('b', 0);
        Registers.Add('c', 0);
        Registers.Add('d', 0);
      }
    }

    //This method will return its offset.
    public int ParseInput(string input)
    {
      var split = input.Split(' ');

      switch(split[0]) //Instruction
      {
        case "cpy":
        {
          if(char.IsLetter(split[1][0]))
          {
            Registers[split[2][0]] = Registers[split[1][0]];
          }
          else
          {
            Registers[split[2][0]] = int.Parse(split[1]);
          }          
          return 1;
        } 
        case "inc":
        {
          Registers[split[1][0]]++;
          return 1;
        } 
        case "dec":
        {
          Registers[split[1][0]]--;
          return 1;
        } 
        case "jnz":
        {
          if(!Registers.ContainsKey(split[1][0]))
          {
            if(int.Parse(split[1]) == 0)
            {
              return 1;
            }
            else
            {
              return int.Parse(split[2]);
            }            
          }

          return Registers[split[1][0]] == 0 ? 1 : int.Parse(split[2]);
        }
        default:
        {
          return 1;
        }
      }
    }

    public void PrintRegisters()
    {
      foreach(var register in Registers)
      {
        System.Console.WriteLine("Register '{0}' has value {1}", register.Key, register.Value);
      }
    }
  }
}