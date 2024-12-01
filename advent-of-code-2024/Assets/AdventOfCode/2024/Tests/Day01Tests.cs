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
	public class Day01Tests
	{
		private string _input;

		[SetUp]
		public void Setup()
		{
			_input = Resources.Load<TextAsset>("AdventOfCode/2024/01").text;
		}

		[Test]
		public void PuzzleATests()
		{
			const string expectedResult = "1882714";
			string result = Day01.PuzzleA(_input);
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void PuzzleBTests()
		{
			const string expectedResult = "19437052";
			string result = Day01.PuzzleB(_input);
			Assert.AreEqual(expectedResult, result);
		}
		
	}
}
