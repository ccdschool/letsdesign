using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	class ConsolePortal {
		public void Tabelle_anzeigen(IEnumerable<string> tabellenzeilen) {
			foreach (var tz in tabellenzeilen)
				Console.WriteLine (tz);
		}
	}
}
