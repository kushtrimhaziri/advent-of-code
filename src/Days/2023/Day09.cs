using CSharpStarterPack.PuzzleInputs;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharpStarterPack.Days_2023
{
    public static class Day09
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(9, 2023);

        public static int PuzzleA()
        {
            var sum = 0;
            foreach (var input in Input)
            {
                var numbersContainer = new List<List<int>>();

                string pattern = @"-?\d+";
                MatchCollection matches = Regex.Matches(input, pattern);

                var initialNumbers = matches
                            .Cast<Match>()
                            .Select(match => int.Parse(match.Value))
                            .ToList();

                // initialNumbers.Reverse() for part 2 solution
                numbersContainer.Add(initialNumbers);

                while (!numbersContainer.Last().All(x => x == 0))
                {
                    var listToBeAdded = new List<int>();
                    var momentalList = numbersContainer.Last();
                    for (int i = 0; i < momentalList.Count - 1; i++)
                    {
                        listToBeAdded.Add(momentalList[i + 1] - momentalList[i]);
                    }

                    numbersContainer.Add(listToBeAdded);
                }

                var valueToBeAdded = 0;

                for (int i = numbersContainer.Count - 2; i >= 0; i--)
                {
                    valueToBeAdded = numbersContainer[i].Last() + valueToBeAdded;
                }
                sum += valueToBeAdded;
            }
            return sum;
        }
        public static int PuzzleB()
        {
            var sum = 0;
            foreach (var input in Input)
            {
                var test = new List<List<int>>();

                string pattern = @"-?\d+";
                MatchCollection matches = Regex.Matches(input, pattern);

                var numbers = matches
                            .Cast<Match>()
                            .Select(match => int.Parse(match.Value))
                            .ToList();

                numbers.Reverse();
                test.Add(numbers);

                while (!test.Last().All(x => x == 0))
                {
                    var listToBeAdded = new List<int>();
                    var momentalList = test.Last();
                    for (int i = 0; i < momentalList.Count - 1; i++)
                    {
                        listToBeAdded.Add(momentalList[i + 1] - momentalList[i]);
                    }

                    test.Add(listToBeAdded);
                }

                var valueToBeAdded = 0;

                for (int i = test.Count - 2; i >= 0; i--)
                {
                    valueToBeAdded = test[i].Last() + valueToBeAdded;
                }
                sum += valueToBeAdded;
            }
            return sum;
        }
    }
}