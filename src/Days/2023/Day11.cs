using CSharpStarterPack.PuzzleInputs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpStarterPack.Days_2023
{
    public static class Day11
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(11, 2023);

        public static double PuzzleA()
        {
            var x = Input[0].Length;
            var y = Input.Length;
            var galaxies = new List<(int, int)>();

            var noGalaxiesVerticalLines = FillLines(x);
            var noGalaxiesHorizontalLines = FillLines(y);

            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    if (Input[i][j] == '#')
                    {
                        galaxies.Add((i, j));
                        noGalaxiesHorizontalLines.Remove(i);
                        noGalaxiesVerticalLines.Remove(j);
                    }
                }
            }

            var finalGalaxies = GetFinalGalaxiesCoordinates(galaxies, noGalaxiesVerticalLines, noGalaxiesHorizontalLines, 1, 0);

            return GetSumOfLengthsBetweenPoints(finalGalaxies);
        }
        public static double PuzzleB()
        {
            var x = Input[0].Length;
            var y = Input.Length;
            var galaxies = new List<(int, int)>();
            var noGalaxiesVerticalLines = FillLines(x);
            var noGalaxiesHorizontalLines = FillLines(y);

            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    if (Input[i][j] == '#')
                    {
                        galaxies.Add((i, j));
                        noGalaxiesHorizontalLines.Remove(i);
                        noGalaxiesVerticalLines.Remove(j);
                    }
                }
            }

            var finalGalaxies = GetFinalGalaxiesCoordinates(galaxies, noGalaxiesVerticalLines, noGalaxiesHorizontalLines, 1000000, 1);

            return GetSumOfLengthsBetweenPoints(finalGalaxies);
        }

        private static List<int> FillLines(int lastLine)
        {
            var lines = new List<int>();
            for (int i = 0; i < lastLine; i++)
            {
                lines.Add(i);
            }

            return lines;
        }

        private static List<(int, int)> GetFinalGalaxiesCoordinates(List<(int, int)> galaxies, List<int> noGalaxiesVerticalLines, List<int> noGalaxiesHorizontalLines, int incrementor, int nrOfReplacement)
        {
            var finalGalaxies = new List<(int, int)>();
            foreach (var item in galaxies)
            {
                var noVerticalLines = noGalaxiesVerticalLines.Where(x => x < item.Item2).Count();
                var noHorizontalLines = noGalaxiesHorizontalLines.Where(x => x < item.Item1).Count();

                finalGalaxies.Add((item.Item1 + (noHorizontalLines * incrementor) - (noHorizontalLines * nrOfReplacement), item.Item2 + (noVerticalLines * incrementor) - (noVerticalLines * nrOfReplacement)));
            }
            return finalGalaxies;
        }

        private static double GetSumOfLengthsBetweenPoints(List<(int, int)> galaxies)
        {
            double sum = 0;
            for (int i = 0; i < galaxies.Count - 1; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++)
                {
                    sum += Math.Abs(galaxies[i].Item1 - galaxies[j].Item1) +
                           Math.Abs(galaxies[i].Item2 - galaxies[j].Item2);
                }
            }

            return sum;
        }
    }
}