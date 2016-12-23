using System.Linq;
using System.Collections.Generic;

namespace Solutions.Models.Day12
{
  public class Assembunny
  {
    public Dictionary<char, int> Registers { get; set; } = new Dictionary<char, int>();

    public List<int?> Toggles = new List<int?>();

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

      var engagedToggle = Toggles.FirstOrDefault(x => x == 0);

      if(engagedToggle != null)
      {
        if(split[0] != "tgl")
        {
          if(split.Length == 2) //One argument Instruction
          {
            split[0] = split[0] == "inc" ? "dec" : "inc";
          }
          else if(split.Length == 3) //Two argument Instruction
          {
            split[0] = split[0] == "jnz" ? "cpy" : "jnz";
          }
        }       

        Toggles.Remove(engagedToggle);
      }

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
              if(char.IsLetter(split[2][0]))
              {
                return Registers[split[2][0]];
              }
              else
              {
                return int.Parse(split[2]);
              }              
            }            
          }

          return Registers[split[1][0]] == 0 ? 1 : int.Parse(split[2]);
        }
        case "tgl":
        {
          if(char.IsLetter(split[1][0]))
          {
            Toggles.Add(Registers[split[1][0]] + 1);
          }
          else
          {
            Toggles.Add(int.Parse(split[1]) + 1);
          }

          return 1;
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