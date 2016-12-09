using System.Text;
using System.Linq;

namespace Solutions.Models.Day9
{
  public class Decompression
  {
    public long DecompressInput(string[] inputLines, bool part2)
    {
      long outputLength = 0;

      foreach(var input in inputLines)
      {
        outputLength += ParseInput(input, part2).Length;
      }

      return outputLength;
    }

    public string ParseInput(string input, bool part2)
    {
      var output = new StringBuilder();
  	  
      for(var idx = 0; idx < input.Length; idx++)
      {
        if(input[idx] == '(')
        {
          var sub = input.Substring(idx, input.IndexOf(')', idx) - idx);
          
          var split = sub.Split('x').Select(x => x.Trim(new [] { '(', ')' })).ToArray();
          
          var charsToRepeat = int.Parse(split[0]);
          var amountToRepeat = int.Parse(split[1]);

          var repeat = input.Substring(input.IndexOf(')', idx) + 1, charsToRepeat);

          if(repeat.StartsWith("(") && part2) //We've got ourselves another marker.
          {
            repeat = ParseInput(repeat, part2);
          }

          for(var idx2 = 0; idx2 < int.Parse(split[1]); idx2++)
          {
            output.Append(repeat);
          }

          idx = input.IndexOf(')', idx) +  charsToRepeat;
        }
        else
        {
          output.Append(input[idx]);
        }
      }

      return output.ToString();
    }
  }
}