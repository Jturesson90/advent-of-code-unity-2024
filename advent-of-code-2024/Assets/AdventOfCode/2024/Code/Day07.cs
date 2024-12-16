using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2024
{
    public static class Day07
    {
        public static string PuzzleA(string input)
        {
            List<Calibration> calibrations = ParseCalibration(input);
            var result = new List<int>();
            int i = 0;
            var charsByLength = new Dictionary<int, List<char[]>>();
            char[] chars = { '*', '+' };
            foreach (var calibration in calibrations)
            {
                int len = calibration.Operators.Length - 1;
                List<char[]> operations = null;
                if (charsByLength.TryGetValue(len, out List<char[]> c))
                {
                    operations = c;
                }
                else
                {
                    operations = GenerateOperationCombinations(chars, len);
                    charsByLength.Add(len, operations);
                }

                foreach (char[] operation in operations)
                {
                    long value = EvaluateCombination(calibration.Operators, operation);

                    if (value == calibration.Value)
                    {
                        result.Add(i);
                        break;
                    }
                }

                i++;
            }

            return result.Sum(a => calibrations[a].Value).ToString();
        }

        private static long EvaluateCombination(IReadOnlyList<int> numbers, IReadOnlyList<char> operations)
        {
            long result = numbers[0];

            for (int i = 0; i < operations.Count; i++)
                if (operations[i] == '+')
                {
                    result += numbers[i + 1];
                }
                else if (operations[i] == '*')
                {
                    result *= numbers[i + 1];
                }
                else if (operations[i] == '|')
                {
                    result = long.Parse($"{result}{numbers[i + 1]}");
                }

            return result;
        }

        private static List<Calibration> ParseCalibration(string input)
        {
            string[] rows = input.Split("\n");
            var calibrations = new List<Calibration>();
            foreach (string row in rows)
            {
                string[] r = row.Split(": ");
                long left = long.Parse(r[0]);
                IEnumerable<int> right = r[1].Split(" ").Select(int.Parse);
                calibrations.Add(new Calibration(left, right.ToArray()));
            }

            return calibrations;
        }

        private static List<char[]> GenerateOperationCombinations(char[] values, int length)
        {
            int totalCombinations = (int)Math.Pow(values.Length, length);
            int[] indexes = new int[length];
            var result = new List<char[]>();
            for (int i = 0; i < totalCombinations; i++)
            {
                char[] newC = new char[length];
                for (int j = 0; j < length; j++) newC[j] = values[indexes[j]];

                result.Add(newC);
                for (int j = length - 1; j >= 0; j--)
                {
                    if (indexes[j] < values.Length - 1)
                    {
                        indexes[j]++;
                        break;
                    }

                    indexes[j] = 0;
                }
            }

            return result;
        }

        public static string PuzzleB(string input)
        {
            List<Calibration> calibrations = ParseCalibration(input);
            var result = new List<int>();
            int i = 0;
            var charsByLength = new Dictionary<int, List<char[]>>();
            char[] chars = { '*', '+', '|' };
            foreach (var calibration in calibrations)
            {
                int len = calibration.Operators.Length - 1;
                List<char[]> operations = null;
                if (charsByLength.TryGetValue(len, out List<char[]> c))
                {
                    operations = c;
                }
                else
                {
                    operations = GenerateOperationCombinations(chars, len);
                    charsByLength.Add(len, operations);
                }

                foreach (char[] operation in operations)
                {
                    long value = EvaluateCombination(calibration.Operators, operation);

                    if (value == calibration.Value)
                    {
                        result.Add(i);
                        break;
                    }
                }

                i++;
            }

            return result.Sum(a => calibrations[a].Value).ToString();
        }

        private struct Calibration
        {
            public readonly long Value;
            public readonly int[] Operators;

            public Calibration(long value, int[] operators)
            {
                Value = value;
                Operators = operators;
            }
        }
    }
}