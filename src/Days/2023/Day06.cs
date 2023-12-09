using CSharpStarterPack.PuzzleInputs;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharpStarterPack.Days_2023
{
    public static class Day06
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(6, 2023);

        public static int PuzzleA()
        {
            string pattern = @"\d+";
            MatchCollection timeMatches = Regex.Matches(Input[0], pattern);
            MatchCollection distanceMatches = Regex.Matches(Input[1], pattern);

            var times = timeMatches
                            .Cast<Match>()
                            .Select(match => int.Parse(match.Value))
                            .ToList();

            var matches = distanceMatches
                            .Cast<Match>()
                            .Select(match => int.Parse(match.Value))
                            .ToList();

            var resultati = 1;

            for (int i = 0; i < times.Count; i++)
            {
                var valueToBeBroken = matches[i];

                var sumOfRecordBreaker = 0;
                for (int j = 1; j < times[i]; j++)
                {
                    var testNumber = times[i] - j;

                    var result = testNumber * j;

                    if (result > valueToBeBroken)
                    {
                        sumOfRecordBreaker++;
                    }

                }
                resultati *= sumOfRecordBreaker;
            }
            return resultati;
        }
        public static int PuzzleB()
        {
            string pattern = @"\d+";
            MatchCollection timeMatches = Regex.Matches(Input[0], pattern);
            MatchCollection distanceMatches = Regex.Matches(Input[1], pattern);

            var time = string.Concat(timeMatches);
            var distance = string.Concat(distanceMatches);

            var timeParsed = double.Parse(time);
            var distanceParsed = double.Parse(distance);

            var sumOfRecordBreaker = 0;

            for (int i = 1; i < timeParsed; i++)
            {
                //var valueToBeBroken = testi2;

                var testNumber = timeParsed - i;

                var result = testNumber * i;

                if (result > distanceParsed)
                {
                    sumOfRecordBreaker++;
                }
            }

            return sumOfRecordBreaker;
        }
    }
}