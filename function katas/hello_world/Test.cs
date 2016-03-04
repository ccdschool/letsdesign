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
			var result = FizzBuzz (2);
			Assert.That (result, Is.EqualTo (new[]{"1", "2"}));
		}


		IEnumerable<string> FizzBuzz(int n) {
			return Enumerable.Range (1, n).Select (i => i.ToString ());
		}
	}
}

