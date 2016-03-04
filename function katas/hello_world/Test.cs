using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace hello_world
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			var result = FizzBuzz (3);
			Assert.That (result, Is.EqualTo (new[]{"1", "2", "Fizz"}));
		}


		IEnumerable<string> FizzBuzz(int n) {
			return new[]{""};
		}
	}
}

