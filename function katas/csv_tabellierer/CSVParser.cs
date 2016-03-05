using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace csv_tabellierer
{

	class CSVParser {
		public IEnumerable<Datensatz> Parsen(IEnumerable<string> csvzeilen) {
			return csvzeilen.Select (csv => {
				var werte = csv.Split(new[]{';'});
				return new Datensatz{Werte = werte};
			});
		}
	}
	
}
