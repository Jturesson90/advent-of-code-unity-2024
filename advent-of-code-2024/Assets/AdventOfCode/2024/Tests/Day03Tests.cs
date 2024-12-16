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
	public class Day03Tests
	{
		private string _input;

		[SetUp]
		public void Setup()
		{
			_input = Resources.Load<TextAsset>("AdventOfCode/2024/03").text;
		}

		[Test]
		public void PuzzleATests()
		{
			const string expectedResult = "187833789";
			string result = Day03.PuzzleA(_input);
			Assert.AreEqual(expectedResult, result);
		}
		
		[Test]
		public void PuzzleBTests()
		{
			const string expectedResult = "94455185";
			string result = Day03.PuzzleB(_input);
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))","48")]
		public void PuzzleBTests(string input, string expectedResult)
		{
			string result = Day03.PuzzleB(input);
			Assert.AreEqual(expectedResult, result);
		}
	}
}
