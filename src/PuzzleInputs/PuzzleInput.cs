using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpStarterPack.PuzzleInputs
{
    public static class PuzzleInput
    {
        public static string[] GetInputAsArray(int day, int year) => File.ReadAllLines($"Inputs/{year}/Day{day}.txt");
        public static string GetInputAsText(int day, int year) => string.Join("\n", (File.ReadAllLines($"Inputs/{year}/Day{day}.txt")));

        public static int[] GetInputAsIntArray(int day, int year) => GetInputAsArray(day, year).Select(int.Parse).ToArray();
        public static int[] GetIntCodeInputAsArray(int day, int year) => GetInputAsText(day, year).Split(',').Select(int.Parse).ToArray();
        public static long[] GetIntCodeInputAsArrayLong(int day, int year) => GetInputAsText(day, year).Split(',').Select(long.Parse).ToArray();
        public static string[][] GetInputAsMultiArray(int day, int year) => GetInputAsArray(day, year).Select((string row) => row.Split(',').ToArray()).ToArray();

        public static byte[] GetInputAsByteArray(int day, int year) => File.ReadAllText($"Inputs/{year}/Day{day}.txt").Select(x => (byte)(x - '0')).ToArray();
        public static int[] GetInputSingleRowAsIntArray(int day, int year)
        {
            var array = GetInputAsArray(day, year)[0];
            var chars = array.ToCharArray();
            var list = new List<int>();
            foreach (var c in chars)
            {
                list.Add(int.Parse(c.ToString()));
            }

            return list.ToArray();
        }

    }
}
