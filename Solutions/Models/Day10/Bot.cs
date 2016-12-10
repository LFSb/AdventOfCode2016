using System; 
using System.Linq; 
using System.Collections.Generic; 

namespace Solutions.Models.Day10 
{
  public class Bot
  {
    public int Id { get; set; }

    public bool datbot { get; set; }

    public List<Chip> Chips { get; set; } = new List<Chip>(); 

    public bool ParseCommand(string[] split, ref List <Bot> otherBots, ref Dictionary <int, List<Chip>> output) 
    {
      var highOrLow = split[0]; 

      var botOrOutput = split[2]; 

      var botOrOutputNumber = int.Parse(split[3]); 

      var chipToAdd = default(Chip); 

      if (botOrOutput == "bot") 
      {
        var otherBot = otherBots.FirstOrDefault(x => x.Id == botOrOutputNumber); 

        if (otherBot == null) 
        {
          otherBot = new Bot 
          {
            Id = botOrOutputNumber
          };

          otherBots.Add(otherBot); 
        }

        if(this.Chips.Count() == 2)
        {
          if(this.Chips.Select(x => x.Value).Contains(61) && this.Chips.Select(x => x.Value).Contains(17))
          {
            datbot = true;
          }

          chipToAdd = DetermineChip(highOrLow);
          
          if(split.Count() > 4)
          {
            var result = ParseCommand(split.Skip(5).ToArray(), ref otherBots, ref output);
            otherBot.Chips.Add(chipToAdd); 
            this.Chips.Remove(chipToAdd);
            return result;
          }
          else
          {
            otherBot.Chips.Add(chipToAdd); 
            this.Chips.Remove(chipToAdd);

            return true;
          }
        }
        else
        {
          return false;
        }        
      }
      else 
      {
        if(this.Chips.Select(x => x.Value).Contains(61) && this.Chips.Select(x => x.Value).Contains(17))
        {
          datbot = true;
        }

        if (!output.ContainsKey(botOrOutputNumber))
        {
          output.Add(botOrOutputNumber, new List<Chip>()); 
        }

        if(this.Chips.Count() == 2)
        {
          chipToAdd = DetermineChip(highOrLow);
          
          if(split.Count() > 4)
          {
              var result = ParseCommand(split.Skip(5).ToArray(), ref otherBots, ref output);
              output[botOrOutputNumber].Add(chipToAdd); 
              this.Chips.Remove(chipToAdd); 
              return result;
          }
          else
          {
            output[botOrOutputNumber].Add(chipToAdd); 
            this.Chips.Remove(chipToAdd);
            return true;
          }
        }
        else
        {
          return false;
        } 
      }
    }

    public Chip DetermineChip(string input)
    {
      var chipToAdd = default(Chip);

      switch (input) 
      {
        case "low": 
        {
          chipToAdd = this.Chips.OrderBy(x => x.Value).First();
        } break; 
        case "high": 
        {
          chipToAdd = this.Chips.OrderByDescending(x => x.Value).First();
        } break; 
        default: 
        {
          throw new Exception("Ya done goofed."); 
        }
      }

      return chipToAdd;
    }
  }
}