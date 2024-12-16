using AdventOfCode_2024;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2024Tests
{
    [TestFixture]
    public class Day04Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2024/04").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            const string expectedResult = "2468";
            string result = Day04.PuzzleA(_input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("XMAS\nSAMX", "2")]
        [TestCase("XS\nMA\nAM\nSX", "2")]
        [TestCase("S.....S\n.A...A.\n..M.M..\n...X...\n..M.M..\n.A...A.\nS.....S", "4")]
        [TestCase("X.....X\n.M...M.\n..A.A..\n...S...\n..A.A..\n.M...M.\nX.....X", "4")]
        [TestCase(
            "MMMSXXMASM\nMSAMXMSMSA\nAMXSXMAAMM\nMSAMASMSMX\nXMASAMXAMM\nXXAMMXXAMA\nSMSMSASXSS\nSAXAMASAAA\nMAMMMXMMMM\nMXMXAXMASX",
            "18")]
        public void PuzzleATests(string input, string expectedResult)
        {
            string result = Day04.PuzzleA(input);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            const string expectedResult = "1864";
            string result = Day04.PuzzleB(_input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(
            "MMMSXXMASM\nMSAMXMSMSA\nAMXSXMAAMM\nMSAMASMSMX\nXMASAMXAMM\nXXAMMXXAMA\nSMSMSASXSS\nSAXAMASAAA\nMAMMMXMMMM\nMXMXAXMASX",
            "9")]
        public void PuzzleBTests(string input, string expectedResult)
        {
            string result = Day04.PuzzleB(input);
            Assert.AreEqual(expectedResult, result);
        }
    }
}