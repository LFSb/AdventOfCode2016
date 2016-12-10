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
using Solutions.Models.Day7;
using Solutions.Models.Day8;
using Solutions.Models.Day9;
using Solutions.Models.Day10;

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

    private const string Input3 = "./Input/Input3.txt";

    private const string Input4 = "./Input/Input4.txt";

    private const string TestInput4 = "aaaaa-bbb-z-y-x-123[abxyz]";

    private const string TestInput5 = "abc";

    private const string ActualInput5 = "ffykfhsq";

    private static int[] ShortcutIndexes = new []{
      515840,
      844745,
      2968550,
      4034943,
      5108969,
      5257971,
      5830668,
      5833677,
      6497076,
      6681564,
      8793263,
      8962195,
      10715437,
      10999728,
      11399249,
      12046531,
      12105075,
      14775057,
      15502588,
      15872452,
      16105326,
      18804482,
      18830862,
      19388652,
      19474413,
      20787586,
      21302616,
      23462555,
      23551279,
      23853737,
      23867827,
      24090051,
      26246522,
      26383109};

    private const string TestInput6 = @"eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar";

    private const string ActualInput6 = "./Input/Input6.txt";

    private const string ActualInput7 = "./Input/Input7.txt";

    private static string[] TestInput7 = new []{"abba[mnop]qrst",
  "abcd[bddb]xyyx",
  "aaaa[qwer]tyui",
  "ioxxoj[asdfgh]zxcvbn"};

    private const string ActualInput8 = "./Input/Input8.txt";

    private static string[] TestInput8 = new []{
      "rect 3x2",
      "rotate column x=1 by 1",
      "rotate row y=0 by 4",
      "rotate column x=1 by 1",
    };

    private static string[] TestInput9 = new []{
      "ADVENT",
      "A(1x5)BC",
      "(3x3)XYZ",
      "A(2x2)BCD(2x2)EFG",
      "(6x1)(1x3)A",
      "X(8x2)(3x3)ABCY",
    };

    private const string ActualInput9 = "./Input/Input9.txt";

    private const string ActualInput10 = "./Input/Input10.txt";  

    private static string[] TestInput10 = new []{"value 5 goes to bot 2",
"bot 2 gives low to bot 1 and high to bot 0",
"value 3 goes to bot 1",
"bot 1 gives low to output 1 and high to bot 0",
"bot 0 gives low to output 2 and high to output 0",
"value 2 goes to bot 2"};

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
        string.Format("Day 1 p1: Destination is at X: {0} Y: {1} Amount of blocks away: {2}", player.X, player.Y, player.AmountOfBlocksAwayFromStart()),
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

    public static string Day5()
    {
      System.Console.WriteLine("Beginning to crack passwords..");

      var passwordBuilder = new StringBuilder();

      var linePos = 0;

      foreach(var shortcutIndex in ShortcutIndexes)
      {
        if(passwordBuilder.Length == 8)
        {
          break;
        }

        var inputBytes = System.Text.Encoding.ASCII.GetBytes(string.Format("{0}{1}", ActualInput5, shortcutIndex));

        using(var md5 = System.Security.Cryptography.MD5.Create())
        {
          var hashBytes = md5.ComputeHash(inputBytes);

          var hex = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

          if(hex.StartsWith("00000"))
          {
            var character = hex[5];
            passwordBuilder.Append(character);
            System.Console.Write(character);
            Console.SetCursorPosition(++linePos, Console.CursorTop);
          }
        }
      }
      
      Console.WriteLine();

      var slightlyBetterPasswordBuilder = new char[8];
      
      var charactersFound = 0;

      foreach(var shortcutIndex in ShortcutIndexes)
      {
        if(charactersFound == 8)
        {
          break;
        }

        var inputBytes = System.Text.Encoding.ASCII.GetBytes(string.Format("{0}{1}", ActualInput5, shortcutIndex));

        using(var md5 = System.Security.Cryptography.MD5.Create())
        {
          var hashBytes = md5.ComputeHash(inputBytes);

          var hex = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

          if(hex.StartsWith("00000"))
          {
            int position;

            if(int.TryParse(hex[5].ToString(), out position))
            {
              if(position < 8)
              {
                if(slightlyBetterPasswordBuilder[position] == '\0')
                {
                  slightlyBetterPasswordBuilder[position] = hex[6];
                  charactersFound++;
                  Console.SetCursorPosition(position, Console.CursorTop);
                  System.Console.Write(hex[6]);
                }                
              }
            }            
          }
        }
      }
      
      Console.WriteLine();

      return string.Concat(string.Format("Day 5 p1: {0}", passwordBuilder.ToString()), Environment.NewLine, string.Format("Day 5 p2: {0}",string.Join("", slightlyBetterPasswordBuilder)));
    }

    public static string Day6()
    {
      var positionFrequencies = new Dictionary<int, Dictionary<char, int>>();

      foreach(var line in File.ReadAllText(ActualInput6).Split(new []{ Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
      {
        for(var idx = 0; idx < line.Length; idx++)
        {
          if(!positionFrequencies.ContainsKey(idx))
          {
            positionFrequencies.Add(idx, new Dictionary<char, int>());
            positionFrequencies[idx].Add(line[idx], 1);
          }
          else
          {
            if(positionFrequencies[idx].Select(x => x.Key).Contains(line[idx]))
            {
              positionFrequencies[idx][line[idx]]++;
            }
            else
            {
              positionFrequencies[idx].Add(line[idx], 1);
            }
          }

        }
      }

      var sb1 = new StringBuilder();
      var sb2 = new StringBuilder();

      foreach(var freq in positionFrequencies)
      {
        sb1.Append(freq.Value.OrderByDescending(x => x.Value).First().Key);
      }

      foreach(var freq in positionFrequencies)
      {
        sb2.Append(freq.Value.OrderBy(x => x.Value).First().Key);
      }

      return string.Concat(
        string.Format("Day 6 p1: {0}", sb1.ToString()), 
        Environment.NewLine, 
        string.Format("Day 6 p2: {0}", sb2.ToString())
      );
    }

    public static string Day7()
    {         
      var input = File.ReadAllLines(ActualInput7);
      var p1 = 0;
      var p2 = 0;

      foreach(var line in input)
      {
        var split = line.Split(new []{'[', ']'});

        var ipv7s = new List<string>();
        var hyperNet = new List<string>();

        for(var idx = 0; idx < split.Length; idx++)
        {
          if(idx % 2 != 0)
          {
            //If the index is even, it is a hypernet.
            hyperNet.Add(split[idx]);
          }
          else
          {
            //If it's odd, it's not.
            ipv7s.Add(split[idx]);
          }
        }

        //P1

        if(ipv7s.Any(x => PalindromeHelper.ContainsFourLetterPalindrome(x)))
        {
          if(!hyperNet.Any(net => PalindromeHelper.ContainsFourLetterPalindrome(net)))
          {
            p1++;
          }
        }

        //P2

        var hyperNetAbas = hyperNet.SelectMany(x => PalindromeHelper.ABACheck(x));
        
        bool isSsl = false;

        foreach(var ipv7 in ipv7s)
        {
          foreach(var abaCheck in PalindromeHelper.ABACheck(ipv7))
          {
            var bab = string.Join("",new []{ abaCheck[1], abaCheck[0], abaCheck[1] });

            if(hyperNetAbas.Contains(bab))
            {
              isSsl = true;
            }
          }
        }

        if(isSsl)
        {
          p2++;
        }
      }
      
      return string.Concat(string.Format("Day7 p1: {0} ips are TLS supported.", p1), Environment.NewLine, string.Format("Day7 p2: {0} ips are SSL supported", p2));
    }

    public static string Day8()
    {
      var screen = new Screen();

      foreach(var line in File.ReadLines(ActualInput8))
      {
        screen.ParseInput(line);
      }
      
      screen.DrawScreen();

      return string.Format("Day8 p1: {0} pixels on", screen.ReturnPixelsOn());
    }

    public static string Day9()
    {
      var dec = new Decompression();

      var output1 = dec.DecompressInput(File.ReadAllLines(ActualInput9), false);

      var output2 = dec.DecompressInput(File.ReadAllLines(ActualInput9), true);

      return string.Concat(string.Format("Day 9 p1 {0}", output1), Environment.NewLine, string.Format("Day 9 p2 {0}", output2));
    }

    public static string Day10()
    {
      var bots = new List<Bot>();

      var lines = File.ReadLines(ActualInput10);

      var linesCompleted = new Dictionary<string, bool>();

      //First, create the first batch of bots by checking the lines in which said bots retrieve something from the input bin.
      foreach(var line in lines)
      {
        if(line.StartsWith("value"))
        {
          var split = line.Split(' '); var value = int.Parse(split[1]); var botNumber = int.Parse(split[5]);

          var bot = bots.FirstOrDefault(x => x.Id == botNumber);

          if(bot == null)
          {
            bots.Add(new Bot
            {
              Id = botNumber,
              Chips = new List<Chip>
              {
                new Chip
                {
                  Value = value
                }
              }
            });
          }
          else
          {
            bot.Chips.Add(
              new Chip
              {
                Value = value
              });
          }
        }
        else
        {
          linesCompleted.Add(line, false); 
        }
      }

      var output = new Dictionary<int, List<Chip>>();

      while(!linesCompleted.All(x => x.Value))
      {
        foreach(var line in linesCompleted.Where(x => !x.Value).Select(x => x.Key).ToArray())
        {
          if(line.StartsWith("bot"))
          {
            var split = line.Split(' ');

            var currentBot = bots.FirstOrDefault(x => x.Id == int.Parse(split[1]));

            if(currentBot == null)
            {
              currentBot = new Bot
              {
                Id = int.Parse(split[1])
              };

              bots.Add(currentBot);
            }

            linesCompleted[line] = currentBot.ParseCommand(split.Skip(3).ToArray(), ref bots, ref output); 
          }
        }
      }

      var datBot = bots.FirstOrDefault(x => x.datbot);
      var output0 = output[0];
      var output1 = output[1];
      var output2 = output[2];

      return string.Concat(string.Format("Day 10 p1: {0}", datBot == null ? "not found!" : datBot.Id.ToString()), Environment.NewLine, string.Format("Day 10 p2: {0}", output0.First().Value * output1.First().Value * output2.First().Value));
    }
  }
}