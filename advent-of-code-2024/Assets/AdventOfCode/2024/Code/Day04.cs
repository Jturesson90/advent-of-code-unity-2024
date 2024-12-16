using System.Collections.Generic;
using UnityEngine;

namespace AdventOfCode_2024
{
    public static class Day04
    {
        public static string Puzzle2A(string input)
        {
            //Solve puzzle A!
            string[] rows = input.Split("\n");
            int columnLength = rows.Length;
            int result = 0;
            for (int col = 0; col < columnLength; col++)
            {
                string rowValue = rows[col];
                int rowLength = rowValue.Length;
                for (int row = 0; row < rowLength; row++)
                {
                    if (row < rowLength - 3)
                    {
                        string horizontal = $"{rowValue[row]}{rowValue[row + 1]}{rowValue[row + 2]}{rowValue[row + 3]}";
                        if (horizontal is "XMAS" or "SAMX")
                        {
                            result++;
                        }
                    }

                    if (row < rowLength - 3 && col < columnLength - 3)
                    {
                        string diagonalCheck =
                            $"{rowValue[row]}{rows[col + 1][row + 1]}{rows[col + 2][row + 2]}{rows[col + 3][row + 3]}";
                        if (diagonalCheck is "XMAS" or "SAMX")
                        {
                            result++;
                        }
                    }

                    if (col < columnLength - 3)
                    {
                        string verticalCheck =
                            $"{rows[col][row]}{rows[col + 1][row]}{rows[col + 2][row]}{rows[col + 3][row]}";
                        if (verticalCheck is "XMAS" or "SAMX")
                        {
                            result++;
                        }
                    }


                    if (col >= 3 && row >= 3)
                    {
                        string verticalBackCheck =
                            $"{rows[col][row]}{rows[col - 1][row - 1]}{rows[col - 2][row - 2]}{rows[col - 3][row - 3]}";
                        if (verticalBackCheck is "XMAS" or "SAMX")
                        {
                            result++;
                        }
                    }
                }
            }

            string iii = string.Join('\n', rows);
            Debug.Log(iii);
            return result.ToString();
        }

        public static string PuzzleA(string input)
        {
            //Solve puzzle B!
            string[] grid = input.Split("\n");
            string target = "XMAS";
            List<(int, int, string)> matches = FindOccurrences(grid, target);


            return matches.Count.ToString();
        }

        private static List<(int, int, string)> FindOccurrences(string[] grid, string target)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            var results = new List<(int, int, string)>();

            // Directions: (dx, dy) and direction name
            (int dx, int dy, string dir)[] directions =
            {
                (0, 1, "Horizontal Right"),
                (0, -1, "Horizontal Left"),
                (1, 0, "Vertical Down"),
                (-1, 0, "Vertical Up"),
                (1, 1, "Diagonal Down-Right"),
                (1, -1, "Diagonal Down-Left"),
                (-1, 1, "Diagonal Up-Right"),
                (-1, -1, "Diagonal Up-Left")
            };

            for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                foreach ((int dx, int dy, string dir) in directions)
                    if (Matches(grid, target, r, c, dx, dy))
                    {
                        results.Add((r, c, dir));
                    }

            return results;
        }

        private static bool Matches(string[] grid, string target, int startX, int startY, int dx, int dy)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int len = target.Length;

            for (int i = 0; i < len; i++)
            {
                int x = startX + i * dx;
                int y = startY + i * dy;
                if (x < 0 || y < 0 || x >= rows || y >= cols || grid[x][y] != target[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static string PuzzleB(string input)
        {
            //Solve puzzle B!
            int result = 0;
            string[] grid = input.Split("\n");
            int rows = grid.Length;
            int cols = grid[0].Length;
            (int dx, int dy, string dir)[] directions =
            {
                (1, 1, "Diagonal Down-Right"),
                (1, -1, "Diagonal Down-Left")
            };
            for (int row = 0; row < rows; row++)
            for (int col = 0; col < cols; col++)
                if (grid[row][col] == 'A')
                {
                    bool found = true;
                    for (int i = 0; i < directions.Length; i++)
                    {
                        var dir = directions[i];
                        int x = row + dir.dx;
                        int y = col + dir.dy;
                        if (x < 0 || y < 0 || x >= rows || y >= cols)
                        {
                            found = false;
                            break;
                        }

                        if (grid[x][y] == 'S')
                        {
                            int xn = row - dir.dx;
                            int yn = col - dir.dy;
                            if (xn < 0 || yn < 0 || xn >= rows || yn >= cols)
                            {
                                found = false;
                                break;
                            }

                            if (grid[xn][yn] != 'M')
                            {
                                found = false;
                                break;
                            }
                        }
                        else if (grid[x][y] == 'M')
                        {
                            int xn = row - dir.dx;
                            int yn = col - dir.dy;
                            if (xn < 0 || yn < 0 || xn >= rows || yn >= cols)
                            {
                                found = false;
                                break;
                            }

                            if (grid[xn][yn] != 'S')
                            {
                                found = false;
                                break;
                            }
                        }
                        else
                        {
                            found = false;
                            break;
                        }
                    }

                    if (found)
                    {
                        Debug.Log($"Found at {row}, {col}");
                        result++;
                    }
                }

            return result.ToString();
        }
    }
}