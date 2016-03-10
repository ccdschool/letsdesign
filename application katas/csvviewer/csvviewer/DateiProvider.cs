using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	class DateiProvider {
		public IEnumerable<string> Datei_laden(string dateiname) {
			return System.IO.File.ReadAllLines (dateiname);
		}
	} 
	
}
