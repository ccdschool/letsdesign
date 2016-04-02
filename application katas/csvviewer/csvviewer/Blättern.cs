using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	class Blättern {
		const int SEITENLÄNGE = 10;
		int seitenindex = 0;
		CsvCache cache;

		public Blättern(CsvCache cache) {
			this.cache = cache;
		}


		public CsvSeite Erste_Seite_ermitteln() {
			this.seitenindex = 0;
			return Seite_laden (0);
		}


		public CsvSeite Letzte_Seite_ermitteln() {
			this.seitenindex = this.cache.AnzahlDatenzeilen / SEITENLÄNGE;

			var überspringen = this.cache.AnzahlDatenzeilen / SEITENLÄNGE * SEITENLÄNGE;
			if (this.cache.AnzahlDatenzeilen <= SEITENLÄNGE)	überspringen = 0;

			return Seite_laden (überspringen);
		}


		public CsvSeite Nächste_Seite_ermitteln() {
			this.seitenindex += 1;

			if (this.seitenindex * SEITENLÄNGE >= this.cache.AnzahlDatenzeilen)
				return Letzte_Seite_ermitteln ();

			var überspringen = this.seitenindex * SEITENLÄNGE;
			return Seite_laden (überspringen);
		}


		public CsvSeite Vorherige_Seite_ermitteln() {
			this.seitenindex -= 1;
			if (this.seitenindex < 0)
				return Erste_Seite_ermitteln ();

			if (this.seitenindex * SEITENLÄNGE >= this.cache.AnzahlDatenzeilen)
				return Letzte_Seite_ermitteln ();

			var überspringen = this.seitenindex * SEITENLÄNGE;

			return Seite_laden (überspringen);
		}


		private CsvSeite Seite_laden(int überspringen) {
			return new CsvSeite{ 
				Überschriftenzeile = this.cache.Überschriftenzeile,
				Datenzeilen = this.cache.Datenzeilen.Skip(überspringen).Take(SEITENLÄNGE)
			};
		}
	}

}
