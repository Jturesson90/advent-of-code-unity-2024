using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2024
{
    public static class Day05
    {
        public static string PuzzleA(string input)
        {
            var pageByBefore = new Dictionary<int, HashSet<int>>();
            //Solve puzzle A!
            string[] splittedInput = input.Split("\n\n");
            string[] rules = splittedInput[0].Split('\n');
            foreach (string rule in rules)
            {
                string[] r = rule.Split('|');
                int before = int.Parse(r[0]);
                int after = int.Parse(r[1]);
                if (pageByBefore.ContainsKey(before))
                {
                    pageByBefore[before].Add(after);
                }
                else
                {
                    pageByBefore.Add(before, new HashSet<int>
                    {
                        after
                    });
                }
            }

            string[] pages = splittedInput[1].Split('\n');
            List<List<int>> p = pages.Select(page => page.Split(',').Select(int.Parse).ToList()).ToList();
            int result = 0;
            foreach (List<int> VARIABLE in p)
                if (IsInRightOrder(VARIABLE, pageByBefore))
                {
                    result += VARIABLE[VARIABLE.Count / 2];
                }


            return result.ToString();
        }

        private static bool IsInRightOrder(List<int> p, Dictionary<int, HashSet<int>> beforeLookup)
        {
            int len = p.Count;
            for (int i = 0; i < len; i++)
            {
                int first = p[i];
                for (int j = i + 1; j < len; j++)
                {
                    int second = p[j];
                    if (beforeLookup.ContainsKey(second) && beforeLookup[second].Contains(first))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static string PuzzleB(string input)
        {
            var pageByBefore = new Dictionary<int, HashSet<int>>();
            var pageByAfter = new Dictionary<int, HashSet<int>>();
            //Solve puzzle A!
            string[] splittedInput = input.Split("\n\n");
            string[] rules = splittedInput[0].Split('\n');
            foreach (string rule in rules)
            {
                string[] r = rule.Split('|');
                int before = int.Parse(r[0]);
                int after = int.Parse(r[1]);
                if (pageByBefore.ContainsKey(before))
                {
                    pageByBefore[before].Add(after);
                }
                else
                {
                    pageByBefore.Add(before, new HashSet<int>
                    {
                        after
                    });
                }
            }

            string[] pages = splittedInput[1].Split('\n');
            List<List<int>> p = pages.Select(page => page.Split(',').Select(int.Parse).ToList())
                .Where(aa => !IsInRightOrder(aa, pageByBefore)).ToList();
            int result = 0;
            foreach (List<int> pp in p)
            {
                pp.Sort(Comparison);

                result += pp[pp.Count / 2];

                int Comparison(int x, int y)
                {
                    if (pageByBefore.ContainsKey(x) && pageByBefore[x].Contains(y))
                    {
                        return 1;
                    }

                    if (pageByBefore.ContainsKey(y) && pageByBefore[y].Contains(x))
                    {
                        return -1;
                    }

                    return 0;
                }
            }


            return result.ToString();
        }
    }
}