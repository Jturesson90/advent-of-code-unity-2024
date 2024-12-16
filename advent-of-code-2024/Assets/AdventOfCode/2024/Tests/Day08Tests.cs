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
	public class Day08Tests
	{
		private string _input;

		[SetUp]
		public void Setup()
		{
			_input = Resources.Load<TextAsset>("AdventOfCode/2024/08").text;
		}

		[Test]
		public void PuzzleATests()
		{
			const string expectedResult = "359";
			string result = Day08.PuzzleA(_input);
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase("............\n........0...\n.....0......\n.......0....\n....0.......\n......A.....\n............\n............\n........A...\n.........A..\n............\n............","14")]
		public void PuzzleATests(string input, string expectedResult)
		{
			string result = Day08.PuzzleA(input);
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void PuzzleBTests()
		{
			const string expectedResult = "1293";
			string result = Day08.PuzzleB(_input);
			Assert.AreEqual(expectedResult, result);
		}
		[TestCase("............\n........0...\n.....0......\n.......0....\n....0.......\n......A.....\n............\n............\n........A...\n.........A..\n............\n............","34")]
		[TestCase("T.........\n...T......\n.T........\n..........\n..........\n..........\n..........\n..........\n..........\n..........","9")]
		public void PuzzleBTests(string input, string expectedResult)
		{
			string result = Day08.PuzzleB(input);
			Assert.AreEqual(expectedResult, result);
		}
		
	}
}
