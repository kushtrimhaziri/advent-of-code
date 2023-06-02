using CSharpStarterPack.PuzzleInputs;
using System.Linq;

namespace CSharpStarterPack.Days
{
    public static class Day08
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(8);

        public static int PuzzleA()
        {
            var counter = 0;

            for (int i = 0; i < Input.Count(); i++)
            {
                for (int j = 0; j < Input[i].Count(); j++)
                {
                    if (TreeIsEdge(i, j, Input))
                    {
                        counter++;
                        continue;
                    }

                    if (TreeIsVisible(i, j, Input))
                    {
                        counter++;
                        continue;
                    }

                }

            }
            return counter;
        }
        public static int PuzzleB()
        {
            return 0;
        }


        private static bool TreeIsEdge(int i, int j, string[] Input)
        {
            if (i == 0 || j == 0)
            {
                return true;
            }

            else if (i == Input.Count() - 1 || j == Input.Count() - 1)
            {
                return true;
            }

            else if (i == Input[i].Count() - 1 || j == Input[i].Count() - 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        private static bool TreeIsVisible(int line, int position, string[] Input)
        {
            bool isVisible = true;
            for (int i = line - 1; i >= 0; i--)
            {
                if (int.Parse(Input[line][position].ToString()) <= int.Parse(Input[i][position].ToString()))
                {
                    isVisible = false;
                    break;
                }
            }
            if (isVisible) return true;

            isVisible = true;
            for (int i = position - 1; i >= 0; i--)
            {
                if (int.Parse(Input[line][position].ToString()) <= int.Parse(Input[line][i].ToString()))
                {
                    isVisible = false;
                    break;
                }
            }
            if (isVisible) return true;

            isVisible = true;
            for (int i = position + 1; i < Input[line].Length; i++)
            {
                if (int.Parse(Input[line][position].ToString()) <= int.Parse(Input[line][i].ToString()))
                {
                    isVisible = false;
                    break;
                }
            }
            if (isVisible) return true;

            isVisible = true;
            for (int i = line + 1; i < Input.Length; i++)
            {
                if (int.Parse(Input[line][position].ToString()) <= int.Parse(Input[i][position].ToString()))
                {
                    isVisible = false;
                    break;
                }
            }
            if (isVisible) return true;


            return isVisible;
        }
    }
}