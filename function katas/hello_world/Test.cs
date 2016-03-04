using NUnit.Framework;
using System;

namespace hello_world
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			var result = "Hello, World!";
			Assert.AreEqual ("Hello, World!", result);
		}
	}
}

