using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode_2024
{
    public static class Day03
    {
        public static string PuzzleA(string input)
        {
            const string pattern = @"mul\((\d+),(\d+)\)";
            int result = 0;
            var matches = Regex.Matches(input, pattern);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    int number1 = int.Parse(match.Groups[1].Value);
                    int number2 = int.Parse(match.Groups[2].Value);
                    result += number1 * number2;
                }
            }
            else
            {
                Console.WriteLine("No match found.");
            }

            return result.ToString();
        }

        public static string PuzzleB(string input, Day03Events events = null)
        {
            const string mulPattern = @"mul\((\d+),(\d+)\)";
            const string doPattern = @"do\(\)";
            const string dontPattern = @"don't\(\)";


            var regexMul = new Regex(mulPattern, RegexOptions.Compiled);
            var regexDo = new Regex(doPattern, RegexOptions.Compiled);
            var regexDont = new Regex(dontPattern, RegexOptions.Compiled);

            int result = 0;
            bool enabled = true;
            int currentIndex = 0;
            while (currentIndex < input.Length)
            {
                var mulMatch = regexMul.Match(input, currentIndex);
                var doMatch = regexDo.Match(input, currentIndex);
                var dontMatch = regexDont.Match(input, currentIndex);

                int nextMul = mulMatch.Success ? mulMatch.Index : int.MaxValue;
                int nextDo = doMatch.Success ? doMatch.Index : int.MaxValue;
                int nextDont = dontMatch.Success ? dontMatch.Index : int.MaxValue;

                if (nextMul == int.MaxValue && nextDo == int.MaxValue && nextDont == int.MaxValue)
                {
                    break;
                }

                if (nextMul < nextDo && nextMul < nextDont)
                {
                    if (enabled)
                    {
                        int a = int.Parse(mulMatch.Groups[1].Value);
                        int b = int.Parse(mulMatch.Groups[2].Value);
                        result += a * b;
                    }


                    events?.Entries.Add(new Day03Events.Day03Event(mulMatch.Index, mulMatch.Length, enabled,
                        result, Day03Events.EntryType.Mul));

                    currentIndex = mulMatch.Index + mulMatch.Length;
                }
                else if (nextDo < nextMul && nextDo < nextDont)
                {
                    enabled = true;
                    currentIndex = doMatch.Index + doMatch.Length;
                    events?.Entries.Add(new Day03Events.Day03Event(doMatch.Index, doMatch.Length, enabled,
                        result, Day03Events.EntryType.Do));
                }
                else if (nextDont < nextMul && nextDont < nextDo)
                {
                    enabled = false;
                    currentIndex = dontMatch.Index + dontMatch.Length;
                    events?.Entries.Add(new Day03Events.Day03Event(dontMatch.Index, dontMatch.Length, enabled,
                        result, Day03Events.EntryType.Dont));
                }
                else
                {
                    throw new InvalidOperationException(
                        $"Unexpected condition: mulIndex={nextMul}, doIndex={nextDo}, dontIndex={nextDont}");
                }
            }

            return result.ToString();
        }
    }

    public class Day03Events
    {
        public enum EntryType
        {
            Mul,
            Do,
            Dont
        }

        public List<Day03Event> Entries = new();

        public struct Day03Event
        {
            public readonly int StartIndex;
            public readonly int Length;
            public readonly bool Enabled;
            public readonly int Result;
            public readonly EntryType Type;

            public Day03Event(int startIndex, int length, bool enabled, int result, EntryType type)
            {
                StartIndex = startIndex;
                Length = length;
                Enabled = enabled;
                Result = result;
                Type = type;
            }

            public override string ToString()
            {
                return
                    $"StartIndex: {StartIndex}, Length: {Length}, Enabled: {Enabled}, Result: {Result}, Type: {Type}";
            }
        }
    }
}