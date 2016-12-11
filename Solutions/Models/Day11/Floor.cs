using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Solutions.Models.Day11
{
  public class Floor
  {
    public int FloorNumber { get; set; }

    public List<Generator> Generators { get; set;} = new List<Generator>();

    public List<MicroChip> MicroChips { get; set; } = new List<MicroChip>();

    public Elevator Elevator { get; set; }

    public void ConstructFloor(string input)
    {
      var split = input.Split(' ');

      if(ParseFloorNumber(split[1]))
      {
        foreach(var word in split.Skip(5))
        {
          var dashSplit = word.Split('-');
          
          if(dashSplit.Length > 1) //We've found a Microchip.
          {
            var type = (IsotopeType)Enum.Parse(typeof(IsotopeType), dashSplit[0]);

            MicroChips.Add(new MicroChip
            {
              IsotopeType = type
            });
          }
          else
          {
            //We've either found a generator, or this floor contains nothing of interest.
            IsotopeType type;

            if(Enum.TryParse<IsotopeType>(word, out type))
            {
              //We've found a generator.
              Generators.Add(
                new Generator
                {
                  IsotopeType = type
                }
              );
            }
          }
        }
      }
    }

    public void DrawFloor()
    {
      var sb = new StringBuilder();

      sb.Append(string.Format("F{0} {1} ", 
        FloorNumber, 
        Elevator != null ? "E" : ".")
      ); 

      for(var idx = 0; idx < 3; idx++)
      {
        if(MicroChips.Count() > idx)
        {
          sb.AppendFormat(" {0}M", char.ToUpper(MicroChips[idx].IsotopeType.ToString()[0]));
        }
        else if(Elevator != null && Elevator.MicroChips.Count() > idx)
        {
          sb.AppendFormat(" {0}M", char.ToUpper(Elevator.MicroChips[idx].IsotopeType.ToString()[0]));
        }
        else
        {
          sb.Append(" . ");
        }

        if(Generators.Count() > idx)
        {
          sb.AppendFormat(" {0}G", char.ToUpper(Generators[idx].IsotopeType.ToString()[0]));
        }
        else if(Elevator != null && Elevator.Generators.Count() > idx)
        {
          sb.AppendFormat(" {0}G", char.ToUpper(Elevator.Generators[idx].IsotopeType.ToString()[0]));
        }
        else
        {
          sb.Append(" . ");
        }
      }

      Console.WriteLine(sb.ToString());
    }

    private bool ParseFloorNumber(string input)
    {
      switch(input.ToLower())
      {
        case "first":
        {
          FloorNumber = 1;
        } break;
        case "second":
        {
          FloorNumber = 2;
        } break;
        case "third":
        {
          FloorNumber = 3;
        } break;
        case "fourth":
        {
          FloorNumber = 4;
        } break;
        default:
        {
          return false;
        }
      }

      return true;
    }
  }
}