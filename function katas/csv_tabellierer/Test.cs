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
	}
}