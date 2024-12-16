using System.Collections.Generic;
using System.Text;

namespace AdventOfCode_2024
{
    public static class Day09
    {
        public static string PuzzleA(string input)
        {
            var s = new StringBuilder();
            int len = input.Length;
            int id = 0;
            for (int i = 0; i < len; i += 2)
            {
                int file = input[i] - '0';
                int freeSpace = i + 1 >= len ? 0 : input[i + 1] - '0';
                char c = (char)(id + '0');
                s.Append(c, file);
                s.Append('.', freeSpace);
                id++;
            }

            len = s.Length;
            int lastIndex = s.Length - 1;
            for (int i = 0; i < len; i++)
            {
                if (lastIndex <= i)
                {
                    break;
                }

                if (s[i] == '.')
                {
                    bool found = false;
                    while (!found && lastIndex > i)
                    {
                        if (s[lastIndex] != '.')
                        {
                            s[i] = s[lastIndex];
                            s[lastIndex] = '.';
                            found = true;
                        }

                        lastIndex--;
                    }
                }
            }


            return GetCheckSum(s).ToString();
        }

        private static long GetCheckSum(StringBuilder s)
        {
            long result = 0;
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                if (s[i] == '.')
                {
                    continue;
                }

                result += i * (s[i] - '0');
            }

            return result;
        }


        public static string PuzzleB(string input)
        {
            var s = new StringBuilder();
            int len = input.Length;
            int id = 0;
            var ccc = new List<(char C, int Index, int FileSize, int Id)>();
            var freeSpaceList = new List<(int Size, int index)>();
            for (int i = 0; i < len; i += 2)
            {
                int file = input[i] - '0';
                int freeSpace = i + 1 >= len ? 0 : input[i + 1] - '0';
                char c = (char)(id + '0');
                ccc.Add((c, s.Length, file, id));
                s.Append(c, file);
                freeSpaceList.Add((freeSpace, s.Length));
                s.Append('.', freeSpace);
                id++;
            }


            for (int i = ccc.Count - 1; i >= 0; i--)
            {
                (char c, int index, int fileSize, int id2) = ccc[i];
                for (int j = 0; j < freeSpaceList.Count; j++)
                    if (freeSpaceList[j].Size >= fileSize)
                    {
                        s.Replace('.', c, freeSpaceList[j].index, fileSize);
                        s.Replace(c, '.', index, fileSize);
                        ccc[i] = (c, freeSpaceList[j].index, fileSize, id2);
                        freeSpaceList[j] = (freeSpaceList[j].Size - fileSize, freeSpaceList[j].index + fileSize);
                        break;
                    }
            }


            return GetCheckSum(ccc).ToString();
        }

        private static long GetCheckSum(List<(char C, int Index, int FileSize, int Id)> a)
        {
            long checksum = 0L;
            foreach (var aa in a)
                for (int i = 0; i < aa.FileSize; i++)
                    checksum += aa.Id * (aa.Index + i);

            return checksum;
        }
    }
}