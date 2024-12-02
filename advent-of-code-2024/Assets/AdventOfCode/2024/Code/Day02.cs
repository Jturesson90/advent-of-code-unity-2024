using System;
using System.Linq;

namespace AdventOfCode_2024
{
    public static class Day02
    {
        public static string PuzzleA(string input)
        {
            string[] reactors = input.Split("\n");
            int result = 0;
            for (int i = 0; i < reactors.Length; i++)
            {
                string reactor = reactors[i];
                string[] levels = reactor.Split(" ");

                bool isSafe = IsSafe(levels);

                if (isSafe)
                {
                    result++;
                }
            }

            return result.ToString();
        }

        private static bool IsSafe(string[] levels)
        {
            bool isIncreasing = int.Parse(levels[0]) < int.Parse(levels[1]);
            for (int i = 1; i < levels.Length; i++)
            {
                int last = int.Parse(levels[i - 1]);
                int current = int.Parse(levels[i]);
                int diff = Math.Abs(current - last);

                if ((isIncreasing && current < last) ||
                    (!isIncreasing && current > last) ||
                    diff < 1 || diff > 3)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsSafeAfterRemovingOneLevel(string[] levels)
        {
            for (int k = 0; k < levels.Length; k++)
            {
                string[] testLevels = levels.Where((_, index) => index != k).ToArray();
                if (IsSafe(testLevels))
                {
                    return true;
                }
            }

            return false;
        }

        public static string PuzzleB(string input)
        {
            string[] reactors = input.Split("\n");
            int result = 0;

            for (int i = 0; i < reactors.Length; i++)
            {
                string[] levels = reactors[i].Split(" ");
                if (IsSafe(levels) || IsSafeAfterRemovingOneLevel(levels))
                {
                    result++;
                }
            }

            return result.ToString();
        }
    }
}