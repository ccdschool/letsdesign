using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace russische_bauernmultiplikation
{
	[TestFixture ()]
	public class Test
	{
		[TestCase (2, 3, 6)]
		public void TestMult (int a, int b, int erwartet)
		{
			var resultat = RussischeBauernmultiplikation.Mult (a, b);
			Assert.AreEqual (erwartet, resultat);
		}

		[Test]
		public void Test_Halbieren() {
			var h = RussischeBauernmultiplikation.Halbieren (9);
			Assert.That (h, Is.EqualTo (new[]{9, 4, 2, 1}));
		}

		[Test]
		public void Test_Verdoppeln() {
			var v = RussischeBauernmultiplikation.Verdoppeln (3, 4);
			Assert.That (v, Is.EqualTo (new[]{3, 6, 12, 24}));
		}

		[Test]
		public void Test_Gerade_Zahlen_finden() {
			var indizes = RussischeBauernmultiplikation.Gerade_Zahlen_finden (new[]{ 1, 2, 3, 4, 6 });
			Assert.That (indizes, Is.EqualTo (new[]{1,3,4}));
		}


		[Test]
		public void Test_Streichen() {
		
		}
	}



	class RussischeBauernmultiplikation {
		public static int Mult(int a, int b) {
			var h = Halbieren (a).ToArray();
			var v = Verdoppeln (b, h.Length);
			var indizes = Gerade_Zahlen_finden (h);
			v = Streichen (v, indizes);
			return v.Sum ();
		}


		public static IEnumerable<int> Halbieren(int i) {
			while (i >= 1) {
				yield return i;
				i = i / 2;
			}
		}

		public static IEnumerable<int> Verdoppeln(int i, int n) {
			while (n > 0) {
				yield return i;
				i *= 2;
				n--;
			}
		}

		public static IEnumerable<int> Gerade_Zahlen_finden(IEnumerable<int> zahlen) {
			var i = 0;
			foreach (var z in zahlen) {
				if (z % 2 == 0)	yield return i;
				i++;
			}
		}

		public static IEnumerable<int> Streichen(IEnumerable<int> zahlen, IEnumerable<int> indizes) {
			return null;
		}
	}
}

