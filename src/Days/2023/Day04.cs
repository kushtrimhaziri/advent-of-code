using CSharpStarterPack.PuzzleInputs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpStarterPack.Days_2023
{
    public static class Day04
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(4, 2023);

        public static int PuzzleA()
        {
            var sum = 0;
            foreach (var input in Input)
            {
                var inputSplitted = input.Split(':');

                var gameNumber = int.Parse(inputSplitted[0].Split(' ', System.StringSplitOptions.RemoveEmptyEntries)[1]);

                var winningNumbersAndTries = inputSplitted[1].Split("|");

                var winningNumbers = winningNumbersAndTries[0].Trim().Split(' ', System.StringSplitOptions.RemoveEmptyEntries).ToHashSet();

                var numberEntries = winningNumbersAndTries[1].Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

                var result = 0;
                foreach (var item in numberEntries)
                {
                    if (winningNumbers.Contains(item))
                    {
                        if (result == 0)
                        {
                            result = 1;
                        }
                        else
                        {
                            result *= 2;
                        }
                    }


                }

                sum += result;
            }

            return sum;
        }
        public static int PuzzleB()
        {
            var sum = 0;

            var instanceTracker = new Dictionary<int, int>();

            for (int i = 0; i < Input.Length; i++)
            {
                instanceTracker[i + 1] = 1;
            }


            foreach (var input in Input)
            {
                var inputSplitted = input.Split(':');


                var gameNumber = int.Parse(inputSplitted[0].Split(' ', System.StringSplitOptions.RemoveEmptyEntries)[1]);

                var winningNumbersAndTries = inputSplitted[1].Split("|");
                var winningNumbers = winningNumbersAndTries[0].Trim().Split(' ', System.StringSplitOptions.RemoveEmptyEntries).ToHashSet();
                var numberEntries = winningNumbersAndTries[1].Split(' ', System.StringSplitOptions.RemoveEmptyEntries);


                var result = 0;
                foreach (var item in numberEntries)
                {
                    if (winningNumbers.Contains(item))
                    {
                        result++;
                    }
                }

                for (int i = 0; i < instanceTracker[gameNumber]; i++)
                {
                    var gameNumberToBeIncremented = gameNumber;
                    var roundsToBeIncremented = result;
                    while (roundsToBeIncremented > 0)
                    {
                        instanceTracker[gameNumberToBeIncremented + 1]++;

                        gameNumberToBeIncremented++;
                        roundsToBeIncremented--;
                    }
                }

            }

            return instanceTracker.Values.Sum();
        }
    }
}