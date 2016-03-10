using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	class CsvCache {
		string[] csvzeilen;

		public CsvCache(IEnumerable<string> csvzeilen) {
			this.csvzeilen = csvzeilen.ToArray ();	
		}


		public string Überschriftenzeile => this.csvzeilen[0];

		public IEnumerable<string> Datenzeilen => this.csvzeilen.Skip(1);
	}
}
