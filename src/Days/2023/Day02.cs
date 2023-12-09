using CSharpStarterPack.PuzzleInputs;
using System.Collections.Generic;
using System.Linq;

namespace CSharpStarterPack.Days_2023
{
    public static class Day02
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(2, 2023);

        public static int PuzzleA()
        {
            var listOfGames = new List<int>();
            foreach (var input in Input)
            {
                var testi = input.Split(':');

                var gameNumber = int.Parse(testi[0].Split(' ')[1]);

                var rounds = testi[1].Split(";");

                var isValid = true;
                foreach (var item in rounds)
                {
                    var sets = item.Split(",");

                    var Numbers = new Dictionary<string, int>
                            {
                                { "red", 12 },
                                { "green",  13 },
                                { "blue", 14 } };
                    foreach (var set in sets)
                    {
                        var numberAndColor = set.Trim().Split(" ");

                        Numbers[numberAndColor[1]] -= int.Parse(numberAndColor[0]);

                        if (Numbers[numberAndColor[1]] < 0) isValid = false;
                    }

                }

                if (isValid)
                {
                    listOfGames.Add(gameNumber);
                }
            }
            return listOfGames.Sum();
        }
        public static int PuzzleB()
        {
            var listOfGames = new List<int>();
            foreach (var input in Input)
            {
                var testi = input.Split(':');

                var gameNumber = int.Parse(testi[0].Split(' ')[1]);

                var rounds = testi[1].Split(";");


                var Numbers = new Dictionary<string, int>
                            {
                                { "red", 0 },
                                { "green",  0 },
                                { "blue", 0 } };

                var isValid = true;
                foreach (var item in rounds)
                {
                    var sets = item.Split(",");

                    foreach (var set in sets)
                    {
                        var numberAndColor = set.Trim().Split(" ");

                        if (int.Parse(numberAndColor[0]) > Numbers[numberAndColor[1]])
                        {
                            Numbers[numberAndColor[1]] = int.Parse(numberAndColor[0]);
                        }
                    }

                }

                var productOfGame = Numbers.Values.Aggregate(1, (acc, val) => acc * val);
                listOfGames.Add(productOfGame);
            }
            return listOfGames.Sum();
        }
    }
}