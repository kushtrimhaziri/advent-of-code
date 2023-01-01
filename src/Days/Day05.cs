using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpStarterPack.PuzzleInputs;


namespace CSharpStarterPack.Days
{
    public static class Day05
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(5);

        public static string PuzzleA()
        {
            var linesForStacks = new List<string>();
            var linesForMovement = new List<string>();

            var dicttOfStacks = new Dictionary<int, Stack<string>>();

            foreach (string line in Input)
            {
                if (line.StartsWith("move"))
                {
                    linesForMovement.Add(line);
                    continue;
                }
                linesForStacks.Add(line);
            }

            linesForStacks.Remove(linesForStacks.Last());

            var lastLine = linesForStacks.Last().Split("   ");

            for (int i = 0; i < lastLine.Length; i++)
            {
                var contentOfIthRow = linesForStacks.Select(x => string.Concat(
                                                                x.Skip(i * 4)
                                                                 .Take(3)))
                                                    .ToList();

                var IthStack = new Stack<string>();


                for (int j = contentOfIthRow.Count() - 2; j >= 0; j--)
                {
                    var stringConcat = string.Concat(contentOfIthRow[j]);

                    if (!string.IsNullOrWhiteSpace(stringConcat))
                    {
                        IthStack.Push(stringConcat);

                    }

                }

                dicttOfStacks.Add(i + 1, IthStack);
            }


            foreach (var item in linesForMovement)
            {
                int position1 = item.IndexOf("move ") + "move ".Length;
                int position2 = item.IndexOf(" from ");
                int positionOfLastFrom = item.IndexOf(" from ") + " from ".Length;
                int positionOfStartTo = item.IndexOf(" to ");
                int positionOfEndTo = item.IndexOf(" to ") + " to ".Length;

                string movementAmount = item.Substring(position1, position2 - position1);
                string fromStack = item.Substring(positionOfLastFrom, positionOfStartTo - positionOfLastFrom);
                string toStack = item.Substring(positionOfEndTo);

                int fromStackInt = Int32.Parse(fromStack);
                int toStackInt = Int32.Parse(toStack);

                for (int i = 0; i < Int32.Parse(movementAmount); i++)
                {
                    var poppedString = dicttOfStacks[fromStackInt].Pop();
                    dicttOfStacks[toStackInt].Push(poppedString);
                }

            }
            StringBuilder finalSolution = new StringBuilder();

            foreach (var stack in dicttOfStacks)
            {
                finalSolution.Append(stack.Value.Pop());
            }
            return finalSolution.ToString();
        }
        public static string PuzzleB()
        {
            var linesForStacks = new List<string>();
            var linesForMovement = new List<string>();

            var dicttOfStacks = new Dictionary<int, Stack<string>>();

            foreach (string line in Input)
            {
                if (line.StartsWith("move"))
                {
                    linesForMovement.Add(line);
                    continue;
                }
                linesForStacks.Add(line);
            }

            linesForStacks.Remove(linesForStacks.Last());

            var lastLine = linesForStacks.Last().Split("   ");

            for (int i = 0; i < lastLine.Length; i++)
            {
                var contentOfIthRow = linesForStacks.Select(x => string.Concat(
                                                                x.Skip(i * 4)
                                                                 .Take(3)))
                                                    .ToList();

                var IthStack = new Stack<string>();


                for (int j = contentOfIthRow.Count() - 2; j >= 0; j--)
                {
                    var stringConcat = string.Concat(contentOfIthRow[j]);

                    if (!string.IsNullOrWhiteSpace(stringConcat))
                    {
                        IthStack.Push(stringConcat);

                    }

                }

                dicttOfStacks.Add(i + 1, IthStack);
            }


            foreach (var item in linesForMovement)
            {
                int position1 = item.IndexOf("move ") + "move ".Length;
                int position2 = item.IndexOf(" from ");
                int positionOfLastFrom = item.IndexOf(" from ") + " from ".Length;
                int positionOfStartTo = item.IndexOf(" to ");
                int positionOfEndTo = item.IndexOf(" to ") + " to ".Length;

                string movementAmount = item.Substring(position1, position2 - position1);
                string fromStack = item.Substring(positionOfLastFrom, positionOfStartTo - positionOfLastFrom);
                string toStack = item.Substring(positionOfEndTo);

                int fromStackInt = Int32.Parse(fromStack);
                int toStackInt = Int32.Parse(toStack);

                var tempList = new List<string>();

                for (int i = 0; i < Int32.Parse(movementAmount); i++)
                {
                    var poppedString = dicttOfStacks[fromStackInt].Pop();
                    tempList.Add(poppedString);
                }
                tempList.Reverse();
                foreach (var poppedItem in tempList)
                {
                    dicttOfStacks[toStackInt].Push(poppedItem);
                }
            }
            StringBuilder finalSolution = new StringBuilder();

            foreach (var stack in dicttOfStacks)
            {
                finalSolution.Append(stack.Value.Pop());
            }
            return finalSolution.ToString();
        }
    }
}