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


		int Mult(int a, int b) {
			var h = Halbieren (a);
			var v = Verdoppeln (b);
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

		IEnumerable<int> Verdoppeln(int i) {
			return null;	
		}

		IEnumerable<int> Gerade_Zahlen_finden(IEnumerable<int> zahlen) {
			return null;
		}

		IEnumerable<int> Streichen(IEnumerable<int> zahlen, IEnumerable<int> indizes) {
			return null;
		}
	}
}

