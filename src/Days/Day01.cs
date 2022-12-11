using CSharpStarterPack.PuzzleInputs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpStarterPack.Days
{
    public static class Day01
    {
        public static string PuzzleA(string inputText)
        {
            var lines = PuzzleInput.GetInputAsArray(1);
            var elvesWithCalories = new Dictionary<int, int>();

            var startElf = 1;
            var sumOfCalories = 0;

            foreach (var calorie in lines)
            {
                if (string.IsNullOrEmpty(calorie))
                {
                    elvesWithCalories.Add(startElf, sumOfCalories);
                    sumOfCalories = 0;
                    startElf++;
                    continue;
                }
                sumOfCalories += Int32.Parse(calorie);
            }

            return elvesWithCalories.Max(x => x.Value).ToString();
        }
        public static int PuzzleB()
        {
            var lines = PuzzleInput.GetInputAsArray(1);
            var elvesWithCalories = new Dictionary<int, int>();

            var startElf = 1;
            var sumOfCalories = 0;

            foreach (var calorie in lines)
            {
                if (string.IsNullOrEmpty(calorie))
                {
                    elvesWithCalories.Add(startElf, sumOfCalories);
                    sumOfCalories = 0;
                    startElf++;
                    continue;
                }
                sumOfCalories += Int32.Parse(calorie);
            }
            var threeElvesWithMostCalories = elvesWithCalories.OrderByDescending(x=>x.Value).Take(3).Sum(x=>x.Value);

            return threeElvesWithMostCalories;
        }
    }
}