using CSharpStarterPack.PuzzleInputs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpStarterPack.Days
{
    public static class Day06
    {
        public static string Input = PuzzleInput.GetInputAsText(6);

        public static int PuzzleA()
        {
            List<char> charsQueue = new List<char>();

            var tracker = 0;

            for (int i = 0; i < Input.Length; i++)
            {
                if (charsQueue.Contains(Input[i]))
                {
                    var indexOfChar = charsQueue.IndexOf(Input[i]);

                    for (int j = 0; j <= indexOfChar; j++)
                    {
                        charsQueue.RemoveAt(0);
                    }
                }

                charsQueue.Add(Input[i]);

                if (charsQueue.Count == 4)
                {
                    tracker = i + 1;
                    break;
                }
            }

            Console.WriteLine(tracker);
            return tracker;
        }
        public static int PuzzleB()
        {
            List<char> charsList = new List<char>();

            var tracker = 0;

            for (int i = 0; i < Input.Length; i++)
            {
                if (charsList.Contains(Input[i]))
                {
                    var indexOfChar = charsList.IndexOf(Input[i]);

                    for (int j = 0; j <= indexOfChar; j++)
                    {
                        charsList.RemoveAt(0);
                    }
                }

                charsList.Add(Input[i]);

                if (charsList.Count == 14)
                {
                    tracker = i + 1;
                    break;
                }
            }

            return tracker;
        }
    }
}