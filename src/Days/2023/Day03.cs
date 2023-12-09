using CSharpStarterPack.PuzzleInputs;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpStarterPack.Days_2023
{
    public static class Day03
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(3, 2023);

        public static int PuzzleA()
        {
            HashSet<string> symbols = new();
            var listOfNumbers = new List<NumberProperties>();
            var numbersToSum = new List<int>();

            for (int i = 0; i < Input.Length; i++)
            {
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < Input[i].Length; j++)
                {
                    if (char.IsDigit(Input[i][j]))
                    {
                        sb.Append(Input[i][j]);

                        if (j == Input[i].Length - 1)
                        {
                            listOfNumbers.Add(new NumberProperties
                            {
                                Number = int.Parse(sb.ToString()),
                                X = i,
                                Y = j - sb.Length + 1
                            });
                        }
                    }
                    else
                    {
                        if (Input[i][j] != '.')
                        {
                            symbols.Add($"{i}-{j}");
                        }

                        if (sb.Length > 0 || (sb.Length > 0 && j == Input[i].Length - 1))
                        {
                            listOfNumbers.Add(new NumberProperties
                            {
                                Number = int.Parse(sb.ToString()),
                                X = i,
                                Y = j - sb.Length
                            });

                            sb.Clear();
                        }

                    }


                }
            }

            foreach (var numberToCheck in listOfNumbers)
            {
                if (numberToCheck.Number == 327)
                {

                }
                if (IsAdjacent(numberToCheck, symbols))
                {
                    numbersToSum.Add(numberToCheck.Number);
                }
            }

            string test = "";

            foreach (var item in numbersToSum)
            {
                test += $"{item}\n";
            }

            var num = numbersToSum.Sum();
            return num;
        }
        public static int PuzzleB()
        {
            HashSet<string> symbols = new();
            var listOfNumbers = new List<NumberProperties>();
            var numbersToSum = new List<int>();

            var numbersAsDictionary = new Dictionary<(int, int), int>();

            for (int i = 0; i < Input.Length; i++)
            {
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < Input[i].Length; j++)
                {
                    if (char.IsDigit(Input[i][j]))
                    {
                        sb.Append(Input[i][j]);

                        if (j == Input[i].Length - 1)
                        {
                            for (int start = j - sb.Length + 1; start < j + 1; start++)
                            {
                                numbersAsDictionary.Add((i, start), int.Parse(sb.ToString()));
                            }
                            listOfNumbers.Add(new NumberProperties
                            {
                                Number = int.Parse(sb.ToString()),
                                X = i,
                                Y = j - sb.Length + 1,
                                YEnd = j + 1

                            });
                        }
                    }
                    else
                    {
                        if (Input[i][j] == '*')
                        {
                            symbols.Add($"{i}-{j}");
                        }

                        if (sb.Length > 0 || (sb.Length > 0 && j == Input[i].Length - 1))
                        {
                            for (int start = j - sb.Length; start < j; start++)
                            {
                                numbersAsDictionary.Add((i, start), int.Parse(sb.ToString()));
                            }
                            listOfNumbers.Add(new NumberProperties
                            {
                                Number = int.Parse(sb.ToString()),
                                X = i,
                                Y = j - sb.Length,
                                YEnd = j - 1,
                            });

                            sb.Clear();
                        }

                    }


                }
            }

            string test = "";
            var sum = 0;
            foreach (var item in symbols)
            {
                var positions = item.Split("-");
                var i = int.Parse(positions[0]);
                var j = int.Parse(positions[1]);

                var numbersToBeMultiplied = new List<int>();

                if (numbersAsDictionary.ContainsKey((i, j - 1)))
                {
                    numbersToBeMultiplied.Add(numbersAsDictionary[(i, j - 1)]);
                }
                if (numbersAsDictionary.ContainsKey((i, j + 1)))
                {
                    numbersToBeMultiplied.Add(numbersAsDictionary[(i, j + 1)]);
                }

                var containsNumber1 = false;
                var containsNumber2 = false;
                for (int start = j - 1; start <= j + 1; start++)
                {
                    if (numbersAsDictionary.ContainsKey((i - 1, start)))
                    {
                        if (!containsNumber1)
                        {
                            numbersToBeMultiplied.Add(numbersAsDictionary[(i - 1, start)]);
                            containsNumber1 = true;
                        }
                    }
                    else
                    {
                        containsNumber1 = false;
                    }

                    if (numbersAsDictionary.ContainsKey((i + 1, start)))
                    {
                        if (!containsNumber2)
                        {
                            numbersToBeMultiplied.Add(numbersAsDictionary[(i + 1, start)]);
                            containsNumber2 = true;
                        }
                    }
                    else
                    {
                        containsNumber2 = false;
                    }
                }

                if (numbersToBeMultiplied.Count == 2)
                {
                    test += $"{numbersToBeMultiplied.First()}-{numbersToBeMultiplied.Last()}\n";
                    sum += numbersToBeMultiplied.First() * numbersToBeMultiplied.Last();
                }
                if (numbersToBeMultiplied.Count > 2)
                {
                }
            }

            return sum;
        }

        private static bool IsAdjacent(NumberProperties nr, HashSet<string> symbols)
        {

            var lengthOfNumber = nr.Number.ToString().Length;
            if (nr.X > 0)
            {
                var startinPointToCheck = nr.Y > 0 ? nr.Y - 1 : nr.Y;
                var endingPointToCheck = nr.Y + lengthOfNumber >= Input[1].Length ? nr.Y + lengthOfNumber - 1 : nr.Y + lengthOfNumber;

                for (var j = startinPointToCheck; j <= endingPointToCheck; j++)
                {
                    if (symbols.Contains($"{nr.X - 1}-{j}"))
                    {
                        return true;
                    }
                }
            }

            if (nr.X < Input.Length - 1)
            {
                var startinPointToCheck = nr.Y > 0 ? nr.Y - 1 : nr.Y;
                var endingPointToCheck = nr.Y + lengthOfNumber >= Input[1].Length ? nr.Y + lengthOfNumber - 1 : nr.Y + lengthOfNumber;

                for (var j = startinPointToCheck; j <= endingPointToCheck; j++)
                {
                    if (symbols.Contains($"{nr.X + 1}-{j}"))
                    {
                        return true;
                    }
                }
            }

            if (nr.Y > 0)
            {
                if (symbols.Contains($"{nr.X}-{nr.Y - 1}"))
                {
                    return true;
                }
            }

            if (nr.Y + lengthOfNumber < Input[1].Length)
            {
                if (symbols.Contains($"{nr.X}-{nr.Y + lengthOfNumber}"))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class NumberProperties
    {
        public int Number { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int? YEnd { get; set; }
    }
}