using CSharpStarterPack.PuzzleInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using static CSharpStarterPack.Days_2022.RockPaperScissorsConsts;

namespace CSharpStarterPack.Days_2022
{
    public static class Day02
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(2, 2022);

        public static int PuzzleA()
        {
            var predefinedResults = RockPaperScissorsConsts.FillPredefindedResults();

            var finalScore = 0;

            foreach (var item in Input)
            {
                var splitLine = item.Split(' ');

                finalScore += predefinedResults.FirstOrDefault(x => x.Key == item).Value + (int)(PointsA)Enum.Parse(typeof(PointsA), splitLine[1]);
            }
            return finalScore;
        }

        public static int PuzzleB()
        {
            var predefinedResults = RockPaperScissorsConsts.FillPredefindedResults();


            var finalScore = 0;

            foreach (var item in Input)
            {
                var splitLine = item.Split(' ');

                var resultRequired = (int)(PointsB)Enum.Parse(typeof(PointsB), splitLine[1]);

                var requiredToPlayPair = predefinedResults.FirstOrDefault(x => x.Key.StartsWith(splitLine[0]) && x.Value == resultRequired).Key;

                var requiredInputToPlay = requiredToPlayPair.Split(' ').Last();

                var pointsForPlayingType = (int)(PointsA)Enum.Parse(typeof(PointsA), requiredInputToPlay);

                finalScore += resultRequired + pointsForPlayingType;

            }
            return finalScore;
        }
    }

    public static class RockPaperScissorsConsts
    {
        public static char ElveRock = 'A';
        public static char ElvePaper = 'B';
        public static char ElveScissors = 'C';

        public static char InputRock = 'X';
        public static char InputPaper = 'Y';
        public static char InputScissors = 'Z';


        public static int Win = 6;
        public static int Draw = 3;
        public static int Lose = 0;

        public static List<KeyValuePair<string, int>> FillPredefindedResults()
        {
            var predefinedResults = new List<KeyValuePair<string, int>>();

            predefinedResults.Add(new KeyValuePair<string, int>(ElveRock + " " + InputRock, Draw));
            predefinedResults.Add(new KeyValuePair<string, int>(ElvePaper + " " + InputRock, Lose));
            predefinedResults.Add(new KeyValuePair<string, int>(ElveScissors + " " + InputRock, Win));
            predefinedResults.Add(new KeyValuePair<string, int>(ElveRock + " " + InputPaper, Win));
            predefinedResults.Add(new KeyValuePair<string, int>(ElvePaper + " " + InputPaper, Draw));
            predefinedResults.Add(new KeyValuePair<string, int>(ElveScissors + " " + InputPaper, Lose));
            predefinedResults.Add(new KeyValuePair<string, int>(ElveRock + " " + InputScissors, Lose));
            predefinedResults.Add(new KeyValuePair<string, int>(ElvePaper + " " + InputScissors, Win));
            predefinedResults.Add(new KeyValuePair<string, int>(ElveScissors + " " + InputScissors, Draw));

            return predefinedResults;
        }

        public enum PointsA
        {
            X = 1, Y = 2, Z = 3
        }

        public enum PointsB
        {
            X = 0, Y = 3, Z = 6
        }
    }
}