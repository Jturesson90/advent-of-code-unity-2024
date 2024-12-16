using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AdventOfCode_2024;

namespace AdventOfCode_2024Tests
{
    [TestFixture]
    public class Day06Tests
    {
        private string _input;

        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2024/06").text;
        }

        [Test]
        public void PuzzleATests()
        {
            const string expectedResult = "5564";
            string result = Day06.PuzzleA(_input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(
            "....#.....\n.........#\n..........\n..#.......\n.......#..\n..........\n.#..^.....\n........#.\n#.........\n......#...",
            "41")]
        public void PuzzleATests(string input, string expectedResult)
        {
            string result = Day06.PuzzleA(input);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            const string expectedResult = "";
            string result = Day06.PuzzleB(_input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(
            "....#.....\n.........#\n..........\n..#.......\n.......#..\n..........\n.#..^.....\n........#.\n#.........\n......#...",
            "6")]
        public void PuzzleBTests(string input, string expectedResult)
        {
            string result = Day06.PuzzleB(input);
            Assert.AreEqual(expectedResult, result);
        }
    }
}