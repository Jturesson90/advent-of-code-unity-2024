using System;
using System.Linq;

namespace AdventOfCode_2024
{
    public static class Day01
    {
        public static string PuzzleA(string input)
        {
            string[] rows = input.Split("\n");
            int[] first = new int[rows.Length];
            int[] second = new int[rows.Length];


            int i = 0;
            foreach (string row in rows)
            {
                int separatorIndex = row.IndexOf("   ", StringComparison.Ordinal);
                first[i] = int.Parse(row[..separatorIndex]);
                second[i] = int.Parse(row[(separatorIndex + 3)..]);
                i++;
            }

            Array.Sort(first);
            Array.Sort(second);

            int totalDistance = 0;
            for (int j = 0; j < rows.Length; j++) totalDistance += Math.Abs(first[j] - second[j]);

            return totalDistance.ToString();
        }

        public static string PuzzleB(string input)
        {
            string[] rows = input.Split("\n");
            int[] first = new int[rows.Length];
            int[] second = new int[rows.Length];
            int i = 0;
            foreach (string row in rows)
            {
                int separatorIndex = row.IndexOf("   ", StringComparison.Ordinal);
                first[i] = int.Parse(row[..separatorIndex]);
                second[i] = int.Parse(row[(separatorIndex + 3)..]);
                i++;
            }

            int count = first.Sum(variable => variable * second.Count(a => variable == a));

            return count.ToString();
        }
    }
}