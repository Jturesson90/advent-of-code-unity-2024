using AdventOfCode_2024;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2024Tests
{
    [TestFixture]
    public class Day02Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2024/02").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            const string expectedResult = "246";
            string result = Day02.PuzzleA(_input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("7 6 4 2 1\n1 2 7 8 9\n9 7 6 2 1\n1 3 2 4 5\n8 6 4 4 1\n1 3 6 7 9", "2")]
        public void PuzzleATests(string input, string expectedResult)
        {
            string result = Day02.PuzzleA(input);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            const string expectedResult = "318";
            string result = Day02.PuzzleB(_input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("7 6 4 2 1\n1 2 7 8 9\n9 7 6 2 1\n1 3 2 4 5\n8 6 4 4 1\n1 3 6 7 9", "4")]
        public void PuzzleBTests(string input, string expectedResult)
        {
            string result = Day02.PuzzleB(input);
            Assert.AreEqual(expectedResult, result);
        }
    }
}