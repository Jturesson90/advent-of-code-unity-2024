using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode_2024
{
    public static class Day06
    {
        private static string[,] ParseGrid(string input)
        {
            string[] rows = input.Split('\n');
            int rowCount = rows.Length;
            int colCount = rows[0].Length;
            // Create the 2D array
            string[,] grid = new string[rowCount, colCount];

            rows
                .SelectMany((row, i) => row.Select((c, j) => (i, j, c.ToString())))
                .ToList()
                .ForEach(x => grid[x.i, x.j] = x.Item3);
            return grid;
        }

        public static string PuzzleA(string input)
        {
            string[,] grid = ParseGrid(input);

            var visitedPositions = new HashSet<(int Col, int Row)>();
            var startPosition = GetStartPosition(grid);
            var currentPosition = startPosition;
            while (IsInside(grid, currentPosition.Col, currentPosition.Row))
            {
                visitedPositions.Add((currentPosition.Col, currentPosition.Row));

                (int Col, int Row) nextPosition = (currentPosition.Col + currentPosition.Direction.dx,
                    currentPosition.Row + currentPosition.Direction.dy);
                if (!IsInside(grid, nextPosition.Item1, nextPosition.Item2))
                {
                    break;
                }

                string aa = grid[nextPosition.Row, nextPosition.Col];
                if (string.Equals("#", aa))
                {
                    currentPosition.Direction = TurnRight(currentPosition.Direction);
                }

                currentPosition.Col += currentPosition.Direction.dx;
                currentPosition.Row += currentPosition.Direction.dy;
            }


            //Solve puzzle A!
            return visitedPositions.Count.ToString();
        }

        private static (int dx, int dy) TurnRight((int dx, int dy) currentDirection)
        {
            if (currentDirection == Directions.Up)
            {
                return Directions.Right;
            }

            if (currentDirection == Directions.Right)
            {
                return Directions.Down;
            }

            if (currentDirection == Directions.Down)
            {
                return Directions.Left;
            }

            if (currentDirection == Directions.Left)
            {
                return Directions.Up;
            }

            throw new Exception();
        }

        private static bool IsInside(string[,] grid, int col, int row)
        {
            return row >= 0 && row < grid.GetLength(0) && col >= 0 && col < grid.GetLength(1);
        }

        private static (int Col, int Row, (int dx, int dy) Direction) GetStartPosition(string[,] grid)
        {
            const string up = "^";
            const string left = "<";
            const string right = ">";
            const string down = "v";
            for (int col = 0; col < grid.GetLength(0); col++)
            for (int row = 0; row < grid.GetLength(1); row++)
            {
                string s = grid[row, col];
                if (s == up)
                {
                    return (col, row, (Directions.Up));
                }

                if (s == left)
                {
                    return (col, row, (Directions.Left));
                }

                if (s == down)
                {
                    return (col, row, (Directions.Down));
                }

                if (s == right)
                {
                    return (col, row, (Directions.Right));
                }
            }

            throw new Exception();
        }

        public static string PuzzleB(string input)
        {
            //Solve puzzle B!
            string[,] grid = ParseGrid(input);

            var visitedPositions = new HashSet<(int Col, int Row)>();
            var startPosition = GetStartPosition(grid);
            var currentPosition = startPosition;
            while (IsInside(grid, currentPosition.Col, currentPosition.Row))
            {
                visitedPositions.Add((currentPosition.Col, currentPosition.Row));

                (int Col, int Row) nextPosition = (currentPosition.Col + currentPosition.Direction.dx,
                    currentPosition.Row + currentPosition.Direction.dy);
                if (!IsInside(grid, nextPosition.Item1, nextPosition.Item2))
                {
                    break;
                }

                string aa = grid[nextPosition.Row, nextPosition.Col];
                if (string.Equals("#", aa))
                {
                    currentPosition.Direction = TurnRight(currentPosition.Direction);
                }

                currentPosition.Col += currentPosition.Direction.dx;
                currentPosition.Row += currentPosition.Direction.dy;
            }

            //   visitedPositions.Remove((startPosition.Col, startPosition.Row));
            int result = 0;


            foreach (var blockedPosition in visitedPositions)
            {
                string originalCell = grid[blockedPosition.Row, blockedPosition.Col];
                grid[blockedPosition.Row, blockedPosition.Col] = "#";
                bool isInfinite = IsInfinite(grid, startPosition);
                grid[blockedPosition.Row, blockedPosition.Col] = originalCell;
                if (isInfinite)
                {
                    result++;
                }
            }

            return result.ToString();
        }

        private static bool IsInfinite(string[,] grid, (int Col, int Row, (int dx, int dy) Direction ) startPosition)
        {
            var visitedPositions = new HashSet<(int Col, int Row, int Dx, int Dy)>();
            var currentPosition = startPosition;
            while (true)
            {
                if (!IsInside(grid, currentPosition.Col, currentPosition.Row))
                {
                    return false;
                }

                if (!visitedPositions.Add((currentPosition.Col, currentPosition.Row,
                        currentPosition.Direction.dx, currentPosition.Direction.dy)))
                {
                    return true;
                }

                (int Col, int Row) nextPosition = (currentPosition.Col + currentPosition.Direction.dx,
                    currentPosition.Row + currentPosition.Direction.dy);

                if (!IsInside(grid, nextPosition.Col, nextPosition.Row))
                {
                    return false;
                }

                string aa = grid[nextPosition.Row, nextPosition.Col];
                if (string.Equals("#", aa))
                {
                    currentPosition.Direction = TurnRight(currentPosition.Direction);
                }
                else
                {
                    currentPosition.Col += currentPosition.Direction.dx;
                    currentPosition.Row += currentPosition.Direction.dy;
                }
            }
        }

        private static class Directions
        {
            public static readonly (int dx, int dy) Right = (1, 0);
            public static readonly (int dx, int dy) Left = (-1, 0);
            public static readonly (int dx, int dy) Up = (0, -1);
            public static readonly (int dx, int dy) Down = (0, 1);
        }
    }
}