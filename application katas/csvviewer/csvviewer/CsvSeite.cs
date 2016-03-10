using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	class CsvSeite {
		public string Überschriftenzeile;
		public IEnumerable<string> Datenzeilen;

		public IEnumerable<string> Zeilen {
			get { 
				return new[]{ Überschriftenzeile }.Concat (Datenzeilen);
			}
		}
	}
}
