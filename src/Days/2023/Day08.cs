using CSharpStarterPack.PuzzleInputs;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSharpStarterPack.Days_2023
{
    public static class Day08
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(8, 2023);

        public static int PuzzleA()
        {
            var commands = Input[0];

            var dictionary = new Dictionary<string, (string, string)>();
            Regex regex = new Regex(@"\b[A-Z1-9]+\b");

            for (int i = 2; i < Input.Length; i++)
            {
                MatchCollection matches = regex.Matches(Input[i]);

                dictionary.Add(matches[0].Value, (matches[1].Value, matches[2].Value));
            }

            var valueTracker = "AAA";
            var stepCount = 0;
            var commandCount = 0;
            while (valueTracker != "ZZZ")
            {
                if (commandCount % commands.Length == 0) commandCount = 0;

                switch (commands[commandCount])
                {
                    case 'L':
                        valueTracker = dictionary[valueTracker].Item1;
                        break;
                    case 'R':
                        valueTracker = dictionary[valueTracker].Item2;
                        break;
                    default:
                        break;
                }

                stepCount++;
                commandCount++;
            }
            return stepCount;
        }
        public static int PuzzleB()
        {
            var commands = Input[0];

            var tt = Input[0].Length;
            var dictionary = new Dictionary<string, (string, string)>();
            var startingNodes = new List<string>();

            Regex regex = new Regex(@"\b[A-Z1-9]+\b");

            var testList = new List<List<string>>();
            for (int i = 2; i < Input.Length; i++)
            {
                MatchCollection matches = regex.Matches(Input[i]);

                if (matches[0].Value.EndsWith('A'))
                {
                    startingNodes.Add(matches[0].Value);
                }
                dictionary.Add(matches[0].Value, (matches[1].Value, matches[2].Value));
            }

            var solutions = new List<int>();

            for (int i = 0; i < startingNodes.Count; i++)
            {
                var valueTracker = startingNodes[i];
                var commandCount = 0;
                var stepCount = 0;
                var trackCount = 0;
                while (!valueTracker.EndsWith('Z'))
                {
                    if (commandCount % commands.Length == 0) commandCount = 0;

                    switch (commands[commandCount])
                    {
                        case 'L':
                            valueTracker = dictionary[valueTracker].Item1;
                            break;
                        case 'R':
                            valueTracker = dictionary[valueTracker].Item2;
                            break;
                        default:
                            break;
                    }

                    stepCount++;
                    trackCount++;
                    commandCount++;
                }
                solutions.Add(trackCount);
            }

            long result = 1;
            foreach (var item in solutions)
            {
                result *= item;
            }

            int lcm = FindLeastCommonMultiple(solutions);


            // the solution is lcm of solutions array
            // TODO: fix the formula of LCM
            return 0;
        }

        public static int FindLeastCommonMultiple(List<int> list)
        {
            int lcm = 1;

            foreach (int num in list)
            {
                lcm = GetLeastCommonMultiple(lcm, num);
            }

            return lcm;
        }

        public static int GetLeastCommonMultiple(int a, int b)
        {
            return Math.Abs(a * b) / GetGreatestCommonDivisor(a, b);
        }

        public static int GetGreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

    }
}