using CSharpStarterPack.PuzzleInputs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpStarterPack.Days_2022
{
    public static class Day10
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(10, 2022);

        public static int PuzzleA()
        {
            var cycleCounter = 0;
            var X = 1;
            var cyclePeriod = 20;

            var dictionaryOfCyclePeriods = new Dictionary<int, int>();

            foreach (var item in Input)
            {
                if (item.Contains("noop"))
                {
                    cycleCounter++;
                    if (cycleCounter == cyclePeriod)
                    {
                        dictionaryOfCyclePeriods.Add(cycleCounter, X);
                        cyclePeriod = cyclePeriod + 40;
                    }
                }

                if (item.Contains("addx"))
                {
                    cycleCounter++;
                    if (cycleCounter == cyclePeriod)
                    {
                        dictionaryOfCyclePeriods.Add(cycleCounter, X);
                        cyclePeriod = cyclePeriod + 40;
                    }
                    cycleCounter++;
                    var splittedLine = item.Split(" ");
                    if (cycleCounter == cyclePeriod)
                    {
                        dictionaryOfCyclePeriods.Add(cycleCounter, X);
                        cyclePeriod = cyclePeriod + 40;
                    }
                    X = X + int.Parse(splittedLine[1]);
                }
            }

            var finalSum = 0;

            foreach (var item in dictionaryOfCyclePeriods)
            {
                finalSum = finalSum + (item.Key * item.Value);
            }

            return finalSum;
        }
        public static void PuzzleB()
        {

            var cycleCounter = 0;
            char[,] matrixOfCRT = new char[6, 40];
            var x = 0;
            var y = 0;
            var X = 1;
            var sprite = new char[] { '#','#','#','.','.','.','.','.','.','.','.','.','.'
                                     ,'.','.','.','.','.','.','.','.','.','.','.','.','.'
                                     ,'.','.','.','.','.','.','.','.','.','.','.','.','.','.' };


            foreach (var cycle in Input)
            {
                if (cycle.Contains("noop"))
                {
                    cycleCounter++;
                    matrixOfCRT[x, y] = sprite[y] == '#' ? '#' : ' ';
                    y++;
                    if (y == 40)
                    {
                        y = 0;
                        x++;
                    }
                }
                if (cycle.Contains("addx"))
                {
                    cycleCounter++;
                    matrixOfCRT[x, y] = sprite[y] == '#' ? '#' : ' ';
                    y++;
                    if (y == 40)
                    {
                        y = 0;
                        x++;
                    }
                    cycleCounter++;
                    matrixOfCRT[x, y] = sprite[y] == '#' ? '#' : ' ';
                    y++;
                    if (y == 40)
                    {
                        y = 0;
                        x++;
                    }

                    var splittedLine = cycle.Split(" ");
                    var shiftAmount = Int32.Parse(splittedLine[1]);

                    // too lazy to handle errors in a better way :)
                    try
                    {
                        sprite[X - 1] = '.';

                    }
                    catch (Exception) { }
                    try
                    {

                        sprite[X] = '.';
                    }
                    catch (Exception) { }
                    try
                    {
                        sprite[X + 1] = '.';

                    }
                    catch (Exception) { }

                    try
                    {

                        sprite[X + shiftAmount] = '#';
                    }
                    catch (Exception) { }
                    try
                    {
                        sprite[X + shiftAmount + 1] = '#';
                    }
                    catch (Exception) { }
                    try
                    {
                        sprite[X + shiftAmount - 1] = '#';
                    }
                    catch (Exception) { }

                    X = X + Int32.Parse(splittedLine[1]);

                }
            }

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 39; j++)
                {
                    Console.Write(matrixOfCRT[i, j]);
                }
            }
        }
    }
}