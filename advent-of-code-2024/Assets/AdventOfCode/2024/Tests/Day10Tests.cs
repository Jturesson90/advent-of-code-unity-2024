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
	public class Day10Tests
	{
		private string _input;

		[SetUp]
		public void Setup()
		{
			_input = Resources.Load<TextAsset>("AdventOfCode/2024/10").text;
		}

		[Test]
		public void PuzzleATests()
		{
			const string expectedResult = "782";
			string result = Day10.PuzzleA(_input);
			Assert.AreEqual(expectedResult, result);
		}
		[TestCase("89010123\n78121874\n87430965\n96549874\n45678903\n32019012\n01329801\n10456732","36")]
		[TestCase("...0...\n...1...\n...2...\n6543456\n7.....7\n8.....8\n9.....9","2")]
		public void PuzzleATests(string input, string expectedResult)
		{
			string result = Day10.PuzzleA(input);
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void PuzzleBTests()
		{
			const string expectedResult = "1694";
			string result = Day10.PuzzleB(_input);
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase(".....0.\n..4321.\n..5..2.\n..6543.\n..7..4.\n..8765.\n..9....","3")]
		public void PuzzleBTests(string input, string expectedResult)
		{
			string result = Day10.PuzzleB(input);
			Assert.AreEqual(expectedResult, result);
		}
	}
}
