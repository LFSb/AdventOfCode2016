using System.Collections.Generic;

namespace Solutions.Models.Day7
{
    public static class PalindromeHelper
    {
        public static bool ContainsFourLetterPalindrome(string input)
        {
            for(var idx = 0; idx < input.Length - 3; idx++)
            {
                if(input[idx] == input[idx + 3] && input[idx + 1] == input[idx + 2] && input[idx] != input[idx + 1])
                {
                    return true;
                }
            }

            return false;
        }

        public static string[] ABACheck(string input)
        {
            var abaCollection = new List<string>();

            for(var idx = 0; idx < input.Length - 2; idx++)
            {
                if(input[idx] == input[idx + 2] && input[idx + 1] != input[idx])
                {
                    abaCollection.Add(string.Join("", new []{ input[idx], input[idx + 1], input[idx + 2] }));
                }
            }

            return abaCollection.ToArray();
        }

        public static bool IsAba(string input1, string input2)
        {
            if(input1.Length != input2.Length)
            {
                return false;
            }

            return true;

        }
    }
}
