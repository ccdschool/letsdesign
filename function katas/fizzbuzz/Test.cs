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
			var resultate = FizzBuzz (1, 5);
			Assert.That (resultate, Is.EqualTo (new[]{"1", "2", "Fizz", "4", "Buzz"}));
		}


		IEnumerable<string> FizzBuzz(int start, int ende) {
			for (var i = start; i <= ende; i++)
				yield return FizzBuzz (i);
		}


		string FizzBuzz(int i) {
			var klasse = Klassifizieren (i);
			return Übersetzen (klasse, i);
		}

		enum Klassen {
			Zahl,
			Fizz,
			Buzz,
			FizzBuzz
		}

		Klassen Klassifizieren(int i) {
			if (i % 3 == 0)	return Klassen.Fizz;
			if (i % 5 == 0)	return Klassen.Buzz;
			return Klassen.Zahl;
		}

		string Übersetzen(Klassen klasse, int i) {
			switch (klasse) {
			case Klassen.Fizz:
				return "Fizz";
			case Klassen.Buzz:
				return "Buzz";
			default:
				return i.ToString ();
			}
		}
	}
}

