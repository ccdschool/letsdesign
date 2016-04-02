using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	class Blättern {
		const int SEITENLÄNGE = 10;
		int seitenindex = 0;


		public CsvSeite Erste_Seite_ermitteln(CsvCache cache) {
			this.seitenindex = 0;
			return Seite_laden (cache, 0);
		}

		public CsvSeite Letzte_Seite_ermitteln(CsvCache cache) {
			this.seitenindex = cache.AnzahlDatenzeilen / SEITENLÄNGE;

			var überspringen = cache.AnzahlDatenzeilen / SEITENLÄNGE * SEITENLÄNGE;
			if (cache.AnzahlDatenzeilen <= SEITENLÄNGE)	überspringen = 0;

			return Seite_laden (cache, überspringen);
		}

		public CsvSeite Nächste_Seite_ermitteln(CsvCache cache) {
			this.seitenindex += 1;

			if (this.seitenindex * SEITENLÄNGE >= cache.AnzahlDatenzeilen)
				return Letzte_Seite_ermitteln (cache);

			var überspringen = this.seitenindex * SEITENLÄNGE;
			return Seite_laden (cache, überspringen);
		}


		private CsvSeite Seite_laden(CsvCache cache, int überspringen) {
			return new CsvSeite{ 
				Überschriftenzeile = cache.Überschriftenzeile,
				Datenzeilen = cache.Datenzeilen.Skip(überspringen).Take(SEITENLÄNGE)
			};
		}
	}

}
