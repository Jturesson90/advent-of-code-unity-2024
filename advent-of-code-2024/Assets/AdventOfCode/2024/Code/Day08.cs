using System.Collections.Generic;

namespace AdventOfCode_2024
{
    public static class Day08
    {
        public static string PuzzleA(string input)
        {
            string[] rows = input.Split("\n");
            char[,] grid = new char[rows.Length, rows[0].Length];

            for (int i = 0; i < rows.Length; i++)
            {
                string col = rows[i];
                for (int j = 0; j < col.Length; j++)
                {
                    grid[i, j] = col[j];
                }
            }

            var frequencyByPosition = new Dictionary<char, List<Position>>();
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    char frequency = grid[row, col];
                    if (frequency != '.')
                    {
                        if (frequencyByPosition.ContainsKey(frequency))
                        {
                            frequencyByPosition[frequency].Add(new Position
                            {
                                Row = row,
                                Col = col
                            });
                        }
                        else
                        {
                            frequencyByPosition.Add(frequency, new List<Position>
                            {
                                new()
                                {
                                    Row = row,
                                    Col = col
                                }
                            });
                        }
                    }
                }
            }

            var pairs = new List<Pair>();
            foreach (KeyValuePair<char, List<Position>> VARIABLE in frequencyByPosition)
            {
                for (int i = 0; i < VARIABLE.Value.Count; i++)
                {
                    for (int j = i + 1; j < VARIABLE.Value.Count; j++)
                    {
                        pairs.Add(new Pair
                        {
                            First = VARIABLE.Value[i],
                            Second = VARIABLE.Value[j],
                            Frequency = VARIABLE.Key
                        });
                    }
                }
            }

            foreach (var pair in pairs)
            {
                var first = pair.First;
                var second = pair.Second;
                int x = first.Col - second.Col;
                int y = first.Row - second.Row;
                var third = new Position
                {
                    Col = first.Col + x,
                    Row = first.Row + y
                };
                var fourth = new Position
                {
                    Col = second.Col - x,
                    Row = second.Row - y
                };
                if (IsInsideGrid(grid, third.Row, third.Col))
                {
                    grid[third.Row, third.Col] = '#';
                }

                if (IsInsideGrid(grid, fourth.Row, fourth.Col))
                {
                    grid[fourth.Row, fourth.Col] = '#';
                }
            }

            int result = 0;
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] == '#')
                    {
                        result++;
                    }
                }
            }

            //Solve puzzle A!
            return result.ToString();
        }

        private static bool IsInsideGrid(char[,] grid, int row, int col)
        {
            return row >= 0 && row < grid.GetLength(0) && col >= 0 && col < grid.GetLength(1);
        }

        public static string PuzzleB(string input)
        {
            string[] rows = input.Split("\n");
            char[,] grid = new char[rows.Length, rows[0].Length];

            for (int i = 0; i < rows.Length; i++)
            {
                string col = rows[i];
                for (int j = 0; j < col.Length; j++)
                {
                    grid[i, j] = col[j];
                }
            }

            var frequencyByPosition = new Dictionary<char, List<Position>>();
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    char frequency = grid[row, col];
                    if (frequency != '.')
                    {
                        if (frequencyByPosition.ContainsKey(frequency))
                        {
                            frequencyByPosition[frequency].Add(new Position
                            {
                                Row = row,
                                Col = col
                            });
                        }
                        else
                        {
                            frequencyByPosition.Add(frequency, new List<Position>
                            {
                                new()
                                {
                                    Row = row,
                                    Col = col
                                }
                            });
                        }
                    }
                }
            }

            var pairs = new List<Pair>();
            foreach (KeyValuePair<char, List<Position>> VARIABLE in frequencyByPosition)
            {
                for (int i = 0; i < VARIABLE.Value.Count; i++)
                {
                    for (int j = i + 1; j < VARIABLE.Value.Count; j++)
                    {
                        pairs.Add(new Pair
                        {
                            First = VARIABLE.Value[i],
                            Second = VARIABLE.Value[j],
                            Frequency = VARIABLE.Key
                        });
                    }
                }
            }

            foreach (var pair in pairs)
            {
                var first = pair.First;
                var second = pair.Second;
                int x = first.Col - second.Col;
                int y = first.Row - second.Row;

                var third = new Position
                {
                    Col = first.Col + x,
                    Row = first.Row + y
                };
                while (IsInsideGrid(grid, third.Row, third.Col))
                {
                    grid[third.Row, third.Col] = '#';
                    third = new Position
                    {
                        Col = third.Col + x,
                        Row = third.Row + y
                    };
                }

                var fourth = new Position
                {
                    Col = second.Col - x,
                    Row = second.Row - y
                };

                while (IsInsideGrid(grid, fourth.Row, fourth.Col))
                {
                    grid[fourth.Row, fourth.Col] = '#';
                    fourth = new Position
                    {
                        Col = fourth.Col - x,
                        Row = fourth.Row - y
                    };
                }
            }

            int result = 0;
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] != '.')
                    {
                        result++;
                    }
                }
            }

            //Solve puzzle A!
            return result.ToString();
        }

        private struct Pair
        {
            public char Frequency;
            public Position First;
            public Position Second;
        }

        private struct Position
        {
            public int Row;
            public int Col;

            public static Position operator +(Position a, Position b)
            {
                return new Position { Row = a.Row + b.Row, Col = a.Col + b.Col };
            }

            // Overload the subtraction operator
            public static Position operator -(Position a, Position b)
            {
                return new Position { Row = a.Row - b.Row, Col = a.Col - b.Col };
            }
        }
    }
}