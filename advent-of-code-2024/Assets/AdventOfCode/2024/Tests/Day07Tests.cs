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
    public class Day07Tests
    {
        private string _input;

        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2024/07").text;
        }

        [Test]
        public void PuzzleATests()
        {
            const string expectedResult = "66343330034722";
            string result = Day07.PuzzleA(_input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(
            "190: 10 19\n3267: 81 40 27\n83: 17 5\n156: 15 6\n7290: 6 8 6 15\n161011: 16 10 13\n192: 17 8 14\n21037: 9 7 18 13\n292: 11 6 16 20",
            "3749")]
        public void PuzzleATests(string input, string expectedResult)
        {
            string result = Day07.PuzzleA(input);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            const string expectedResult = "637696070419031";
            string result = Day07.PuzzleB(_input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(
            "190: 10 19\n3267: 81 40 27\n83: 17 5\n156: 15 6\n7290: 6 8 6 15\n161011: 16 10 13\n192: 17 8 14\n21037: 9 7 18 13\n292: 11 6 16 20",
            "11387")]
        public void PuzzleBTests(string input, string expectedResult)
        {
            string result = Day07.PuzzleB(input);
            Assert.AreEqual(expectedResult, result);
        }
    }
}