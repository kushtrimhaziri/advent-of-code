using CSharpStarterPack.PuzzleInputs;
using System.Collections.Generic;
using System.Linq;

namespace CSharpStarterPack.Days_2022
{
    public static class Day03
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(3, 2022);

        public static int PuzzleA()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int finalSum = 0;

            foreach (var item in Input)
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

            for (int i = 0; i < Input.Count(); i = i + 3)
            {
                var charactersOnBothParts = new List<char>();

                foreach (char character in Input[i])
                {
                    if (Input[i + 1].Contains(character) && Input[i + 2].Contains(character))
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