using CSharpStarterPack.PuzzleInputs;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace CSharpStarterPack.Days
{
    public static class Day03
    {
        public static int PuzzleA()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int finalSum = 0;
            var lines = PuzzleInput.GetInputAsArray(3);

            foreach (var item in lines)
            {
                var charactersOnBothParts = new List<char>();

                string firstHalf = item.Substring(0, item.Length / 2);
                string secondHalf = item.Substring(item.Length / 2);

                foreach (char character in firstHalf)
                {
                    if (secondHalf.Contains(character))
                    {
                        if (!charactersOnBothParts.Contains(character))
                        {
                            var indexOfLetter = alphabet.IndexOf(character) + 1;
                            finalSum += indexOfLetter;
                            charactersOnBothParts.Add(character);
                        }

                    }
                }
            }

            return finalSum;
        }
        public static int PuzzleB()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int finalSum = 0;
            var lines = PuzzleInput.GetInputAsArray(3);

            for (int i = 0; i < lines.Count(); i = i + 3)
            {
                var charactersOnBothParts = new List<char>();

                foreach (char character in lines[i])
                {
                    if (lines[i + 1].Contains(character) && lines[i + 2].Contains(character))
                    {
                        if (!charactersOnBothParts.Contains(character))
                        {
                            var indexOfLetter = alphabet.IndexOf(character) + 1;
                            finalSum += indexOfLetter;
                            charactersOnBothParts.Add(character);
                        }
                    }
                }
            }
            return finalSum;
        }
    }
}