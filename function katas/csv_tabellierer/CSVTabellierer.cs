using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace csv_tabellierer
{

	public class CSVTabellierer {
		public IEnumerable<string> Tabellieren(IEnumerable<string> csvzeilen) {
			var parser = new CSVParser ();
			var tab = new Tabellierer ();

			var datensätze = parser.Parsen (csvzeilen);
			return tab.Formatieren (datensätze);
		}
	}
	
}
