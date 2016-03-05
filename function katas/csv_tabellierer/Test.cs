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
	}


	class CSVTabellierer {
		public IEnumerable<string> Tabellieren(IEnumerable<string> csvzeilen) {
			var parser = new CSVParser ();
			var tab = new Tabellierer ();

			var datensätze = parser.Parsen (csvzeilen);
			return tab.Formatieren (datensätze);
		}
	}


	class Tabellierer {
		public IEnumerable<string> Formatieren(IEnumerable<Datensatz> datensätze) {
			throw new NotImplementedException ();
		}
	}


	class Datensatz {
		public string[] Werte;
	}
}

