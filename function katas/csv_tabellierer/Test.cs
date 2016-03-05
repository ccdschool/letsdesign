using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace csv_tabellierer
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void Akzeptanztest ()
		{
			var sut = new CSVTabellierer ();

			var tabelle = sut.Tabellieren(new[]{
				"Name;Strasse;Ort;Alter",
				"Peter Pan;Am Hang 5;12345 Einsam;42",
				"Maria Schmitz;Kölner Straße 45;50123 Köln;43",
				"Paul Meier;Münchener Weg 1;87654 München;65"
			});

			Assert.That (tabelle, Is.EqualTo(new[]{ 
				"Name         |Strasse         |Ort          |Alter|",
				"-------------+----------------+-------------+-----+",
				"Peter Pan    |Am Hang 5       |12345 Einsam |42   |",
				"Maria Schmitz|Kölner Straße 45|50123 Köln   |43   |",
				"Paul Meier   |Münchener Weg 1 |87654 München|65   |"
			}));
		}


		[Test]
		public void Test_Parsen() {
			var sut = new CSVParser ();

			var datensätze = sut.Parsen (new[]{ "a;b", "x;yz;123"});

			equalidator.Equalidator.AreEqual(datensätze, new[]{
				new Datensatz{Werte = new[]{"a", "b"}},
				new Datensatz{Werte = new[]{"x", "yz", "123"}}
			}, true);
		}



		[Test]
		public void Test_Untersteichung_einfügen() {
			var sut = new Tabellierer ();

			var tabellenzeilen = sut.Unterstreichung_einfügen (new[]{"1","a","b"}, "-");

			Assert.That (tabellenzeilen, Is.EqualTo(new[]{ 
				"1", "-", "a", "b"
			}));
		}

		[Test]
		public void Test_Unterstreichung_bauen() {
			var sut = new Tabellierer ();

			var unterstreichung = sut.Unterstreichung_bauen (new[]{ 1, 2, 3 });

			Assert.AreEqual ("-+--+---+", unterstreichung);
		}

		[Test]
		public void Test_Tabellenzeilen_bauen() {
			var sut = new Tabellierer ();

			var tabellenzeilen = sut.Tabellenzeilen_bauen (new[]{ 
				new Datensatz{Werte = new[]{"H", "H2", "H33"}},
				new Datensatz{Werte = new[]{"aa", "b", "ccc"}}
			}, new[]{ 
				2, 2, 3
			});

			Assert.That (tabellenzeilen, Is.EqualTo(new[]{
				"H |H2|H33|",
				"aa|b |ccc|"
			}));
		}
	}


	class Tabellierer {
		public IEnumerable<string> Formatieren(IEnumerable<Datensatz> datensätze) {
			var spaltenbreiten = Spaltenbreiten_bestimmen (datensätze);
			var tabellenzeilen = Tabellenzeilen_bauen (datensätze, spaltenbreiten);
			var unterstreichung = Unterstreichung_bauen (spaltenbreiten);
			return Unterstreichung_einfügen (tabellenzeilen, unterstreichung);
		}


		public int[] Spaltenbreiten_bestimmen(IEnumerable<Datensatz> datensätze) {
			throw new NotImplementedException ();
		}

		public IEnumerable<string> Tabellenzeilen_bauen(IEnumerable<Datensatz> datensätze, int[] spaltenbreiten) {
			return datensätze.Select (ds => {
				var werteAufgefüllt = ds.Werte.Select((w,i) => w.PadRight(spaltenbreiten[i]));
				return string.Join("|", werteAufgefüllt) + "|";
			});
		}

		public string Unterstreichung_bauen(int[] spaltenbreiten) {
			var spaltenUnterstriche = spaltenbreiten.Select (sb => "".PadLeft(sb, '-')); // "-", "--", "---"
			return string.Join("+", spaltenUnterstriche) + "+";
		}

		public IEnumerable<string> Unterstreichung_einfügen(IEnumerable<string> tabellenzeilen, string unterstreichung) {
			var tabListe = tabellenzeilen.ToList ();
			tabListe.Insert (1, unterstreichung);
			return tabListe;
		}

	}


	class Datensatz {
		public string[] Werte;
	}
}

