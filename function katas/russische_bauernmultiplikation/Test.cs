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
			var resultat = Mult (a, b);
			Assert.AreEqual (erwartet, resultat);
		}

		[Test]
		public void Test_Halbieren() {
			var h = Halbieren (9);
			Assert.That (h, Is.EqualTo (new[]{9, 4, 2, 1}));
		}

		[Test]
		public void Test_Verdoppeln() {
			var v = Verdoppeln (3, 4);
			Assert.That (v, Is.EqualTo (new[]{3, 6, 12, 24}));
		}


		int Mult(int a, int b) {
			var h = Halbieren (a).ToArray();
			var v = Verdoppeln (b, h.Length);
			var indizes = Gerade_Zahlen_finden (h);
			v = Streichen (v, indizes);
			return v.Sum ();
		}


		IEnumerable<int> Halbieren(int i) {
			while (i >= 1) {
				yield return i;
				i = i / 2;
			}
		}

		IEnumerable<int> Verdoppeln(int i, int n) {
			while (n > 0) {
				yield return i;
				i *= 2;
				n--;
			}
		}

		IEnumerable<int> Gerade_Zahlen_finden(IEnumerable<int> zahlen) {
			return null;
		}

		IEnumerable<int> Streichen(IEnumerable<int> zahlen, IEnumerable<int> indizes) {
			return null;
		}
	}
}

