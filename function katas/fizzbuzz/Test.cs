using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fizzbuzz
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			var resultate = FizzBuzz (1, 2);
			Assert.That (resultate, Is.EqualTo (new[]{"1", "2"}));
		}


		IEnumerable<string> FizzBuzz(int start, int ende) {
			for (var i = start; i <= ende; i++)
				yield return i.ToString ();
		}
	}
}

