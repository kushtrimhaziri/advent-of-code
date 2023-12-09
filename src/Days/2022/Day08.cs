using CSharpStarterPack.PuzzleInputs;
using System.Linq;

namespace CSharpStarterPack.Days_2022
{
    public static class Day08
    {
        public static string[] Input = PuzzleInput.GetInputAsArray(8, 2022);

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
            int max = 0;

            for (int i = 0; i < Input.Count(); i++)
            {
                for (int j = 0; j < Input[i].Count(); j++)
                {
                    if (TreeIsEdge(i, j, Input))
                    {
                        continue;
                    }

                    var scenicScoreOfTree = TreeScenicScore(i, j, Input);

                    if (scenicScoreOfTree > max)
                    {
                        max = scenicScoreOfTree;
                    }

                }

            }
            return max;
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


        private static int TreeScenicScore(int line, int position, string[] Input)
        {
            int top = 0, bottom = 0, right = 0, left = 0;

            for (int i = line - 1; i >= 0; i--)
            {
                if (int.Parse(Input[line][position].ToString()) <= int.Parse(Input[i][position].ToString()))
                {
                    top++;
                    break;
                }
                top++;
            }

            for (int i = position - 1; i >= 0; i--)
            {
                if (int.Parse(Input[line][position].ToString()) <= int.Parse(Input[line][i].ToString()))
                {
                    left++;
                    break;
                }
                left++;
            }

            for (int i = position + 1; i < Input[line].Length; i++)
            {
                if (int.Parse(Input[line][position].ToString()) <= int.Parse(Input[line][i].ToString()))
                {
                    right++;
                    break;
                }
                right++;
            }

            for (int i = line + 1; i < Input.Length; i++)
            {
                if (int.Parse(Input[line][position].ToString()) <= int.Parse(Input[i][position].ToString()))
                {
                    bottom++;
                    break;
                }
                bottom++;
            }


            return top * bottom * right * left;
        }
    }
}