using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	class Blättern {
		const int SEITENLÄNGE = 10;

		public CsvSeite Erste_Seite_ermitteln(CsvCache cache) {
			return new CsvSeite{ 
				Überschriftenzeile = cache.Überschriftenzeile,
				Datenzeilen = cache.Datenzeilen.Take(SEITENLÄNGE)
			};
		}
	}

}
