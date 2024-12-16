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
	public class Day09Tests
	{
		private string _input;

		[SetUp]
		public void Setup()
		{
			_input = Resources.Load<TextAsset>("AdventOfCode/2024/09").text;
		}

		[Test]
		public void PuzzleATests()
		{
			const string expectedResult = "6349606724455";
			string result = Day09.PuzzleA(_input);
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase("2333133121414131402","1928")]
		public void PuzzleATests(string input, string expectedResult)
		{
			string result = Day09.PuzzleA(input);
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void PuzzleBTests()
		{
			const string expectedResult = "";
			string result = Day09.PuzzleB(_input);
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase("2333133121414131402","2858")]
		public void PuzzleBTests(string input, string expectedResult)
		{
			string result = Day09.PuzzleB(input);
			Assert.AreEqual(expectedResult, result);
		}
	}
}
