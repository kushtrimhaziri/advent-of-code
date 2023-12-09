using CSharpStarterPack.PuzzleInputs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpStarterPack.Days_2022
{
    public static class Day04
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(4, 2022);

        public static int PuzzleA()
        {
            var sum = 0;

            var firstPairs = new List<KeyValuePair<int, int>>();
            var secondPairs = new List<KeyValuePair<int, int>>();

            foreach (var item in Input)
            {
                var splittedPairs = item.Split(',');

                var firstPair = splittedPairs[0].Split('-').ToList();
                var secondPair = splittedPairs[1].Split('-').ToList();

                firstPairs.Add(new KeyValuePair<int, int>(Int32.Parse(firstPair[0]), Int32.Parse(firstPair[1])));
                secondPairs.Add(new KeyValuePair<int, int>(Int32.Parse(secondPair[0]), Int32.Parse(secondPair[1])));
            }

            for (int i = 0; i < firstPairs.Count; i++)
            {
                if ((firstPairs[i].Key <= secondPairs[i].Key && firstPairs[i].Value >= secondPairs[i].Value) ||
                    (secondPairs[i].Key <= firstPairs[i].Key && secondPairs[i].Value >= firstPairs[i].Value))
                {
                    sum++;
                }
            }
            return sum;
        }
        public static int PuzzleB()
        {
            var sum = 0;

            var firstPairs = new List<KeyValuePair<int, int>>();
            var secondPairs = new List<KeyValuePair<int, int>>();

            foreach (var item in Input)
            {
                var splittedPairs = item.Split(',');

                var firstPair = splittedPairs[0].Split('-').ToList();
                var secondPair = splittedPairs[1].Split('-').ToList();

                firstPairs.Add(new KeyValuePair<int, int>(Int32.Parse(firstPair[0]), Int32.Parse(firstPair[1])));
                secondPairs.Add(new KeyValuePair<int, int>(Int32.Parse(secondPair[0]), Int32.Parse(secondPair[1])));
            }

            for (int i = 0; i < firstPairs.Count; i++)
            {
                if ((firstPairs[i].Key >= secondPairs[i].Key && firstPairs[i].Key <= secondPairs[i].Value) ||
                (secondPairs[i].Key >= firstPairs[i].Key && secondPairs[i].Key <= firstPairs[i].Value))
                {
                    sum++;
                }
            }
            return sum;
        }
    }
}