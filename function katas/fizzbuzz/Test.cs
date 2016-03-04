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
			var resultate = FizzBuzz (1, 15);
			Assert.That (resultate, Is.EqualTo (new[]{"1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz",
													  "11", "Fizz", "Fizz", "14", "FizzBuzz"}));

			Assert.That (FizzBuzz (58, 58), Is.EqualTo(new[]{"Buzz"}));
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
			if (IsFizz(i) && IsBuzz(i)) return Klassen.FizzBuzz;
			if (IsFizz(i))	return Klassen.Fizz;
			if (IsBuzz(i))	return Klassen.Buzz;
			return Klassen.Zahl;
		}

		static bool IsFizz (int i) => i % 3 == 0 || i.ToString().IndexOf("3") >= 0;
		static bool IsBuzz (int i) => i % 5 == 0 || i.ToString().IndexOf("5") >= 0;


		string Übersetzen(Klassen klasse, int i) {
			switch (klasse) {
			case Klassen.Fizz:
				return "Fizz";
			case Klassen.Buzz:
				return "Buzz";
			case Klassen.FizzBuzz:
				return "FizzBuzz";
			default:
				return i.ToString ();
			}
		}
	}
}

