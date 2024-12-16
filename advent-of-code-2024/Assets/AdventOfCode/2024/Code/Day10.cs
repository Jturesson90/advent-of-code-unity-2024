using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdventOfCode_2024
{
    public static class Day10
    {
        private static string[,] GetMultiArray(string input)
        {
            // Split the input by lines
            string[] lines = input.Split('\n');

            // Determine the dimensions of the 2D array
            int rows = lines.Length;
            int cols = lines[0].Length; // Assumes all rows have the same length

            // Create a 2D array
            string[,] parsedInput = new string[rows, cols];

            // Fill the 2D array
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    parsedInput[i, j] = lines[i][j].ToString();
                }
            }

            return parsedInput;
        }

        public static string PuzzleA(string input)
        {
            string[,] parsedInput = GetMultiArray(input);
            Node[,] nodes = GetNodes(parsedInput);
            int result = 0;
            foreach (var node in nodes)
            {
                if (node.Height == 0)
                {
                    var childNode = new List<Node>();
                    node.FlattenConnectedNodes(childNode);
                    HashSet<(int Row, int Col)> aa = childNode.Where(a => a.Height == 9).Select(a => (a.Row, a.Col))
                        .ToHashSet();
                    result += aa.Count;
                }
            }

            return result.ToString();
        }

        public static string PuzzleB(string input)
        {
            string[,] parsedInput = GetMultiArray(input);
            Node[,] nodes = GetNodes(parsedInput);
            int result = 0;
            foreach (var node in nodes)
            {
                if (node.Height == 0)
                {
                    var childNode = new List<Node>();
                    node.FlattenConnectedNodes(childNode);

                    result += childNode.Count(a => a.Height == 9);
                }
            }

            return result.ToString();
        }

        private static Node[,] GetNodes(string[,] parsedInput)
        {
            int rows = parsedInput.GetLength(0);
            int cols = parsedInput.GetLength(1);
            var nodes = new Node[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    nodes[row, col] = new Node(parsedInput[row, col], row, col);
                }
            }

            rows = nodes.GetLength(0);
            cols = nodes.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    nodes[row, col].ConnectNodes(nodes, row, col);
                }
            }

            return nodes;
        }

        public class Node
        {
            private readonly Vector2Int[] _directions =
            {
                new(1, 0),
                new(-1, 0),
                new(0, 1),
                new(0, -1)
            };

            public readonly List<Node> ConnectedFromNodes;

            public readonly List<Node> ConnectedNodes;

            public Node(string c, int row, int col)
            {
                TentativeDistance = int.MaxValue;
                Visited = false;
                PathNode = null;
                Row = row;
                Col = col;
                ConnectedNodes = new List<Node>();
                ConnectedFromNodes = new List<Node>();
                Height = c != "." ? int.Parse(c) : -4;

                Weight = 1; // PriorityList.IndexOf(c, StringComparison.Ordinal);
            }

            public int TentativeDistance { get; set; }
            public int Weight { get; private set; }
            public int Row { get; }
            public int Col { get; }
            public bool Visited { get; set; }
            public int Height { get; }
            public Node PathNode { get; set; }

            public void FlattenConnectedNodes(List<Node> nodes)
            {
                // Create a stack to hold nodes to process
                var stack = new Stack<Node>();
                stack.Push(this);

                // Process nodes iteratively
                while (stack.Count > 0)
                {
                    // Pop a node from the stack
                    var current = stack.Pop();

                    // Add the current node to the list
                    nodes.Add(current);

                    // Push all connected nodes to the stack
                    foreach (var connectedNode in current.ConnectedNodes)
                    {
                        stack.Push(connectedNode);
                    }
                }
            }

            private bool CanConnectToNode(Node node)
            {
                if (node.ConnectedNodes.Contains(node))
                {
                    throw new Exception("Already contains node");
                }

                if (node == this)
                {
                    throw new Exception("Why do you try to connect the node to itself?");
                }

                return node.Height - Height == 1;
            }

            private static bool IsInside(int col, int row, int cols, int rows)
            {
                return col >= 0 && row >= 0 && col < cols && row < rows;
            }

            public void ConnectNodes(Node[,] nodes, int row, int col)
            {
                int rows = nodes.GetLength(0);
                int cols = nodes.GetLength(1);

                foreach (var direction in _directions)
                {
                    int checkCol = direction.y + col;
                    int checkRow = direction.x + row;
                    if (!IsInside(checkCol, checkRow, cols, rows))
                    {
                        continue;
                    }

                    var node = nodes[checkRow, checkCol];
                    if (CanConnectToNode(node))
                    {
                        node.AddFromNode(this);
                        ConnectedNodes.Add(node);
                    }
                }
            }

            private void AddFromNode(Node node)
            {
                ConnectedFromNodes.Add(node);
            }
        }
    }
}