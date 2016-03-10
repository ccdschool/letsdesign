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

		public CsvSeite Letzte_Seite_ermitteln(CsvCache cache) {
			var überspringen = cache.AnzahlDatenzeilen / SEITENLÄNGE * SEITENLÄNGE;
			if (cache.AnzahlDatenzeilen <= SEITENLÄNGE)	überspringen = 0;

			return new CsvSeite{ 
				Überschriftenzeile = cache.Überschriftenzeile,
				Datenzeilen = cache.Datenzeilen.Skip(überspringen)
			};
		}
	}

}
