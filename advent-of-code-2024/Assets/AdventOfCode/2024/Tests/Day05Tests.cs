using AdventOfCode_2024;
using NUnit.Framework;
using UnityEngine;

namespace AdventOfCode_2024Tests
{
    [TestFixture]
    public class Day05Tests
    {
        [SetUp]
        public void Setup()
        {
            _input = Resources.Load<TextAsset>("AdventOfCode/2024/05").text;
        }

        private string _input;

        [Test]
        public void PuzzleATests()
        {
            const string expectedResult = "6951";
            string result = Day05.PuzzleA(_input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(
            "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13\n\n75,47,61,53,29\n97,61,53,29,13\n75,29,13\n75,97,47,61,53\n61,13,29\n97,13,75,29,47",
            "143")]
        public void PuzzleATests(string input, string expectedResult)
        {
            string result = Day05.PuzzleA(input);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void PuzzleBTests()
        {
            const string expectedResult = "4121";
            string result = Day05.PuzzleB(_input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(
            "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13\n\n75,47,61,53,29\n97,61,53,29,13\n75,29,13\n75,97,47,61,53\n61,13,29\n97,13,75,29,47",
            "123")]
        public void PuzzleBTests(string input, string expectedResult)
        {
            string result = Day05.PuzzleB(input);
            Assert.AreEqual(expectedResult, result);
        }
    }
}