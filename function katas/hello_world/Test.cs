using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hello_world
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			var result = FizzBuzz (5);
			Assert.That (result, Is.EqualTo (new[]{"1", "2", "Fizz", "4", "Buzz"}));
		}


		IEnumerable<string> FizzBuzz(int n) {
			return Enumerable.Range (1, n).Select (i => {
				if (i % 3 == 0) return "Fizz";
				if (i % 5 == 0) return "Buzz";
				return i.ToString();
			});
		}
	}
}

