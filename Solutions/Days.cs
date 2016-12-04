using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Solutions.Models.Day1;
using Solutions.Models.Day2;
using Solutions.Models.Day3;
using Solutions.Models.Day4;

namespace Solutions
{
  public static class Days
  {
    private const string Input1 = @"L4, L1, R4, R1, R1, L3, R5, L5, L2, L3, R2, R1, L4, R5, R4, L2, R1, R3, L5, R1, L3, L2, R5, L4, L5, R1, R2, L1, R5, L3, R2, R2, L1, R5, R2, L1, L1, R2, L1, R1, L2, L2, R4, R3, R2, L3, L188, L3, R2, R54, R1, R1, L2, L4, L3, L2, R3, L1, L1, R3, R5, L1, R5, L1, L1, R2, R4, R4, L5, L4, L1, R2, R4, R5, L2, L3, R5, L5, R1, R5, L2, R4, L2, L1, R4, R3, R4, L4, R3, L4, R78, R2, L3, R188, R2, R3, L2, R2, R3, R1, R5, R1, L1, L1, R4, R2, R1, R5, L1, R4, L4, R2, R5, L2, L5, R4, L3, L2, R1, R1, L5, L4, R1, L5, L1, L5, L1, L4, L3, L5, R4, R5, R2, L5, R5, R5, R4, R2, L1, L2, R3, R5, R5, R5, L2, L1, R4, R3, R1, L4, L2, L3, R2, L3, L5, L2, L2, L1, L2, R5, L2, L2, L3, L1, R1, L4, R2, L4, R3, R5, R3, R4, R1, R5, L3, L5, L5, L3, L2, L1, R3, L4, R3, R2, L1, R3, R1, L2, R4, L3, L3, L3, L1, L2";

    private const string Input2 = @"LURLDDLDULRURDUDLRULRDLLRURDUDRLLRLRURDRULDLRLRRDDULUDULURULLURLURRRLLDURURLLUURDLLDUUDRRDLDLLRUUDURURRULURUURLDLLLUDDUUDRULLRUDURRLRLLDRRUDULLDUUUDLDLRLLRLULDLRLUDLRRULDDDURLUULRDLRULRDURDURUUUDDRRDRRUDULDUUULLLLURRDDUULDRDRLULRRRUUDUURDULDDRLDRDLLDDLRDLDULUDDLULUDRLULRRRRUUUDULULDLUDUUUUDURLUDRDLLDDRULUURDRRRDRLDLLURLULDULRUDRDDUDDLRLRRDUDDRULRULULRDDDDRDLLLRURDDDDRDRUDUDUUDRUDLDULRUULLRRLURRRRUUDRDLDUDDLUDRRURLRDDLUUDUDUUDRLUURURRURDRRRURULUUDUUDURUUURDDDURUDLRLLULRULRDURLLDDULLDULULDDDRUDDDUUDDUDDRRRURRUURRRRURUDRRDLRDUUULLRRRUDD
DLDUDULDLRDLUDDLLRLUUULLDURRUDLLDUDDRDRLRDDUUUURDULDULLRDRURDLULRUURRDLULUDRURDULLDRURUULLDLLUDRLUDRUDRURURUULRDLLDDDLRUDUDLUDURLDDLRRUUURDDDRLUDDDUDDLDUDDUUUUUULLRDRRUDRUDDDLLLDRDUULRLDURLLDURUDDLLURDDLULLDDDRLUDRDDLDLDLRLURRDURRRUDRRDUUDDRLLUDLDRLRDUDLDLRDRUDUUULULUDRRULUDRDRRLLDDRDDDLULURUURULLRRRRRDDRDDRRRDLRDURURRRDDULLUULRULURURDRRUDURDDUURDUURUURUULURUUDULURRDLRRUUDRLLDLDRRRULDRLLRLDUDULRRLDUDDUUURDUDLDDDUDL
RURDRUDUUUUULLLUULDULLLDRUULURLDULULRDDLRLLRURULLLLLLRULLURRDLULLUULRRDURRURLUDLULDLRRULRDLDULLDDRRDLLRURRDULULDRRDDULDURRRUUURUDDURULUUDURUULUDLUURRLDLRDDUUUUURULDRDUDDULULRDRUUURRRDRLURRLUUULRUDRRLUDRDLDUDDRDRRUULLLLDUUUULDULRRRLLRLRLRULDLRURRLRLDLRRDRDRLDRUDDDUUDRLLUUURLRLULURLDRRULRULUDRUUURRUDLDDRRDDURUUULLDDLLDDRUDDDUULUDRDDLULDDDDRULDDDDUUUURRLDUURULRDDRDLLLRRDDURUDRRLDUDULRULDDLDDLDUUUULDLLULUUDDULUUDLRDRUDLURDULUDDRDRDRDDURDLURLULRUURDUDULDDLDDRUULLRDRLRRUURRDDRDUDDLRRLLDRDLUUDRRDDDUUUDLRRLDDDUDRURRDDUULUDLLLRUDDRULRLLLRDLUDUUUUURLRRUDUDDDDLRLLULLUDRDURDDULULRDRDLUDDRLURRLRRULRL
LDUURLLULRUURRDLDRUULRDRDDDRULDLURDDRURULLRUURRLRRLDRURRDRLUDRUUUULLDRLURDRLRUDDRDDDUURRDRRURULLLDRDRDLDUURLDRUULLDRDDRRDRDUUDLURUDDLLUUDDULDDULRDDUUDDDLRLLLULLDLUDRRLDUUDRUUDUDUURULDRRLRRDLRLURDRURURRDURDURRUDLRURURUUDURURUDRURULLLLLUDRUDUDULRLLLRDRLLRLRLRRDULRUUULURLRRLDRRRDRULRUDUURRRRULDDLRULDRRRDLDRLUDLLUDDRURLURURRLRUDLRLLRDLLDRDDLDUDRDLDDRULDDULUDDLLDURDULLDURRURRULLDRLUURURLLUDDRLRRUUDULRRLLRUDRDUURLDDLLURRDLRUURLLDRDLRUULUDURRDULUULDDLUUUDDLRRDRDUDLRUULDDDLDDRUDDD
DRRDRRURURUDDDRULRUDLDLDULRLDURURUUURURLURURDDDDRULUDLDDRDDUDULRUUULRDUDULURLRULRDDLDUDLDLULRULDRRLUDLLLLURUDUDLLDLDRLRUUULRDDLUURDRRDLUDUDRULRRDDRRLDUDLLDLURLRDLRUUDLDULURDDUUDDLRDLUURLDLRLRDLLRUDRDUURDDLDDLURRDDRDRURULURRLRLDURLRRUUUDDUUDRDRULRDLURLDDDRURUDRULDURUUUUDULURUDDDDUURULULDRURRDRDURUUURURLLDRDLDLRDDULDRLLDUDUDDLRLLRLRUUDLUDDULRLDLLRLUUDLLLUUDULRDULDLRRLDDDDUDDRRRDDRDDUDRLLLDLLDLLRDLDRDLUDRRRLDDRLUDLRLDRUURUDURDLRDDULRLDUUUDRLLDRLDLLDLDRRRLLULLUDDDLRUDULDDDLDRRLLRDDLDUULRDLRRLRLLRUUULLRDUDLRURRRUULLULLLRRURLRDULLLRLDUUUDDRLRLUURRLUUUDURLRDURRDUDDUDDRDDRUD";

    private const string Input3 = "../../Input/Input3.txt";

    private const string Input4 = "../../Input/Input4.txt";

    private const string TestInput4 = "aaaaa-bbb-z-y-x-123[abxyz]";

    public static string Day1()
    {
      var input1Array = Input1.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

      var player = new Player();

      foreach (var instruction in input1Array)
      {
        var trimmed = instruction.Trim();

        player.HandleInput(trimmed[0], int.Parse(trimmed.Substring(1)));
      }

      return string.Concat(
        string.Format("Day1 p1: Destination is at X: {0} Y: {1} Amount of blocks away: {2}", player.X, player.Y, player.AmountOfBlocksAwayFromStart()),
        Environment.NewLine,
        string.Format("Day 1 p2: {0}", player.Message)
      );
    }

    public static string Day2()
    {
      var input2Array = Input2.Split(new[]
      {
       Environment.NewLine 
      }, StringSplitOptions.RemoveEmptyEntries);

      var keypad = new Keypad();
      var bsKeyPad = new BullShitKeyPad();
      var sb = new StringBuilder();
      var bssb = new StringBuilder();

      foreach (var line in input2Array)
      {
        sb.Append(keypad.ReturnButtonToPress(line));
        bssb.Append(bsKeyPad.ReturnButtonToPress(line));
      }

      return string.Concat(
        string.Format("Day2 p1: The code for the normal keypad is: {0}", sb),
        Environment.NewLine,
        string.Format("Day2 p2: The code for the bullshit keypad is: {0}", bssb));
    }

    public static string Day3()
    {
      var input3 = File.ReadLines(Input3);
      var triangle = new Triangle();

      var amountPossible = 0;

      foreach (var line in input3)
      {
        var splitInput = Regex.Split(line.Trim(), @"(\d+)[ ]+(\d+)[ ]+(\d+)");

        triangle.SetSides(
          int.Parse(splitInput[1].Trim()),
          int.Parse(splitInput[2].Trim()),
          int.Parse(splitInput[3].Trim())
        );

        if (triangle.IsPossible())
        {
          amountPossible++;
        }
      }

      var splitInput3 = input3.Select(x => Regex.Split(x.Trim(), @"(\d+)[ ]+(\d+)[ ]+(\d+)")).ToArray();

      var amountPossibleP2 = 0;

      for (var idx = 0; idx < splitInput3.Length; idx += 3)
      {
        if (idx + 2 >= splitInput3.Length)
        {
          continue;
        }

        for (var idx2 = 1; idx2 < 4; idx2++)
        {
          triangle.SetSides(
            int.Parse(splitInput3[idx][idx2]),
            int.Parse(splitInput3[idx + 1][idx2]),
            int.Parse(splitInput3[idx + 2][idx2])
          );

          if (triangle.IsPossible())
          {
            amountPossibleP2++;
          }
        }
      }

      return string.Concat(
        string.Format("Day 3 p1: The amount of possible triangles is : {0}", amountPossible),
        Environment.NewLine,
        string.Format("Day 3 p2: The amount of possible triangles is : {0}", amountPossibleP2)
      );
    }

    public static string Day4()
    {
      var result = new StringBuilder();

      var input4 = File.ReadLines(Input4);
      var room = new Room();

      var sumSector = 0;

      foreach (var line in input4)
      {
        var lastDashIndex = line.LastIndexOf('-');
        var firstBracketIndex = line.IndexOf('[');

        room.SetRoom(
          line.Substring(0, lastDashIndex),
          line.Substring(lastDashIndex + 1, firstBracketIndex - lastDashIndex - 1),
          line.Substring(firstBracketIndex)
        );

        if (room.IsReal())
        {
          sumSector += room.Sector;
          var name = room.DecryptRoomName();

          if (name.Contains("pole"))
          {
            result.AppendLine(string.Format("Day 4 p2: Sector ID: {0}, Decryption result: {1}", room.Sector, name));
          }
        }
      }

      result.AppendLine(string.Format("Day 4 p1: The sum of sector id's is: {0}", sumSector));

      return result.ToString();
    }
  }
}
