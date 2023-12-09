using CSharpStarterPack.PuzzleInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpStarterPack.Days_2023
{
    public static class Day01
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(1, 2023);

        public static Dictionary<string, int> Numbers = new Dictionary<string, int>
                            {
                                { "one", 1 },
                                { "two",  2 },
                                { "three", 3 },
                                { "four", 4 },
                                { "five", 5 },
                                { "six", 6 },
                                { "seven", 7 },
                                { "eight", 8 },
                                { "nine",9 },
                            };

        public static int PuzzleA()
        {
            var result = 0;
            foreach (var line in Input)
            {
                string numericPhone = new(line.Where(Char.IsDigit).ToArray());

                var number = $"{numericPhone.First()}{numericPhone.Last()}";
                result += Int32.Parse(number);

            }
            return result;
        }
        public static int PuzzleB()
        {
            var sum = 0;
            string testi = "";
            foreach (var line in Input)
            {
                if (line == "eightsixhnsbnine1twonevrs")
                {

                }

                var arrayOfInts = new List<int>();

                StringBuilder stringToBeChecked = new StringBuilder();

                foreach (var item in line)
                {
                    stringToBeChecked.Append(item);
                    if (Char.IsDigit(item))
                    {
                        arrayOfInts.Add((int)Char.GetNumericValue(item));
                        stringToBeChecked.Clear();
                        continue;
                    }

                    if (stringToBeChecked.Length < 3)
                    {
                        continue;
                    }

                    var numberObtained = ParseNumberString(stringToBeChecked);

                    if (numberObtained != null)
                    {
                        arrayOfInts.Add(Numbers[numberObtained]);
                    }

                    if (stringToBeChecked.Length > 5)
                    {
                        stringToBeChecked.Remove(0, 1);
                    }

                }
                string stringLine = string.Join("", arrayOfInts);

                testi += $"{stringLine}\n";
                sum += (arrayOfInts.First() * 10) + arrayOfInts.Last();
            }
            return sum;
        }

        private static string ParseNumberString(StringBuilder input)
        {
            StringBuilder testingStringBuilder = new StringBuilder(input.ToString());
            while (testingStringBuilder.Length >= 3)
            {
                if (Numbers.ContainsKey(testingStringBuilder.ToString()))
                {
                    return testingStringBuilder.ToString();
                }

                testingStringBuilder.Remove(0, 1);
            }
            return null;
        }
    }
}