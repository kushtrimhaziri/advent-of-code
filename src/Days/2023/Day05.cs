using CSharpStarterPack.PuzzleInputs;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CSharpStarterPack.Days_2023
{
    public static class Day05
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(5, 2023);
        public static string InputFull = PuzzleInput.GetInputAsText(5, 2023);


        public static long PuzzleA()
        {

            string[] blocks = InputFull.Split(new[] { "\n\n" }, StringSplitOptions.None);

            var seeds = blocks[0].Split(':')[1].Trim().Split(' ').Select(x => long.Parse(x)).ToDictionary(x => x, x => new List<long> { x });

            for (int i = 1; i < blocks.Length; i++)
            {
                var blockLines = blocks[i].Split("\n").ToArray();

                foreach (var seed in seeds)
                {
                    long destination = seed.Value.Last();
                    for (int j = 1; j < blockLines.Length; j++)
                    {
                        var destination_source_range = blockLines[j].Split(' ').Select(x => long.Parse(x)).ToList();

                        var rangeOfSeed = FindRangeOfSeed(destination_source_range[1], destination_source_range[2]);

                        if (seed.Value.Last() >= rangeOfSeed.Min && seed.Value.Last() <= rangeOfSeed.Max)
                        {
                            destination = FindDestination(destination_source_range[0], destination_source_range[1], seed.Value.Last());

                        }
                    }

                    seed.Value.Add(destination);
                }
            }


            var min = seeds.Values.Select(x => x.Last()).Min();
            return min;
        }
        public static int PuzzleB()
        {
            string[] blocks = InputFull.Split(new[] { "\n\n" }, StringSplitOptions.None);

            //var seeds = blocks[0].Split(':')[1].Trim().Split(' ').Select(x => float.Parse(x)).ToDictionary(x => x, x => new List<float> { x });

            var BIGLIST = new List<RangeIncrementor>();


            var seeds = blocks[0].Split(':')[1].Trim().Split(' ').Select(x => long.Parse(x)).ToList();

            var dictionaryOfSeeds = new Dictionary<(long, long), long>();

            for (int i = 0; i < seeds.Count - 1; i += 2)
            {
                BIGLIST.Add(new RangeIncrementor { Start = seeds[i], End = seeds[i] + seeds[i + 1] - 1, Incrementor = 0 });
            }


            var changableList = new List<RangeIncrementor>();

            for (int i = 1; i < blocks.Length; i++)
            {
                var blockLines = blocks[i].Split("\n").ToArray();

                foreach (var listOfRanges in BIGLIST)
                {
                    var startPoint = listOfRanges.Start;
                    var endPoint = listOfRanges.End;

                    while (startPoint != endPoint)
                    {
                        for (int j = 1; j < blockLines.Length; j++)
                        {
                            var destination_source_range = blockLines[j].Split(' ').Select(x => long.Parse(x)).ToList();

                            var rangeOfSeed = FindRangeOfSeed(destination_source_range[1], destination_source_range[2]);

                            if (startPoint >= rangeOfSeed.Min && startPoint <= rangeOfSeed.Max)
                            {
                                if (rangeOfSeed.Max < listOfRanges.End && rangeOfSeed.Min > listOfRanges.Start)
                                {
                                    changableList.Add(new RangeIncrementor { Start = rangeOfSeed.Min, End = rangeOfSeed.Max, Incrementor = destination_source_range[0] - destination_source_range[1] });
                                    startPoint = rangeOfSeed.Max;
                                }
                                if (rangeOfSeed.Max < listOfRanges.End && rangeOfSeed.Min <= listOfRanges.Start)
                                {
                                    changableList.Add(new RangeIncrementor { Start = listOfRanges.Start, End = rangeOfSeed.Max, Incrementor = destination_source_range[0] - destination_source_range[1] });
                                    startPoint = rangeOfSeed.Max;
                                }
                                if (rangeOfSeed.Max > listOfRanges.End && rangeOfSeed.Min <= listOfRanges.Start)
                                {
                                    changableList.Add(new RangeIncrementor { Start = listOfRanges.Start, End = listOfRanges.End, Incrementor = destination_source_range[0] - destination_source_range[1] });
                                    startPoint = listOfRanges.End;
                                }
                                else
                                {
                                    changableList.Add(new RangeIncrementor { Start = startPoint, End = listOfRanges.End, Incrementor = destination_source_range[0] - destination_source_range[1] });
                                    startPoint = listOfRanges.End;

                                }

                            }
                        }

                    }

                }




                foreach (var dictionaryOfSeed in dictionaryOfSeeds)
                {
                    for (long t = dictionaryOfSeed.Key.Item1; t <= dictionaryOfSeed.Key.Item1 + dictionaryOfSeed.Key.Item2; t++)
                    {
                        for (int j = 1; j < blockLines.Length; j++)
                        {
                            var destination_source_range = blockLines[j].Split(' ').Select(x => long.Parse(x)).ToList();

                            var rangeOfSeed = FindRangeOfSeed(destination_source_range[1], destination_source_range[2]);

                            if (t >= rangeOfSeed.Min && t <= rangeOfSeed.Max)
                            {

                            }
                        }

                    }
                }
            }

            return 0;
        }


        private static (long Min, long Max) FindRangeOfSeed(long source, long range)
        {
            return (source, source + range - 1);
        }

        private static long FindDestination(long destination, long source, long seedNumber)
        {
            var numberToBeDecreased = source - destination;

            return seedNumber - numberToBeDecreased;
        }
    }

    public class RangeIncrementor
    {
        public long Start { get; set; }
        public long End { get; set; }
        public long Incrementor { get; set; }
    }
}