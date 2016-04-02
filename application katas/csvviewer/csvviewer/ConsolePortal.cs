using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	class ConsolePortal {
		public void Öffnen(IEnumerable<string> tabellenzeilen) {
			Tabelle_anzeigen (tabellenzeilen);
			Menü_anzeigen ();
		}
			
		public void Tabelle_anzeigen(IEnumerable<string> tabellenzeilen) {
			foreach (var tz in tabellenzeilen)
				Console.WriteLine (tz);
		}


		void Menü_anzeigen() {
			while (true) {
				Console.Write ("Blättern zu E(rste, L(etzte, N(ächste, V(orherige Seite, eX(it: ");
				var cmd = Console.ReadKey ().KeyChar;
				Console.WriteLine ();

				switch (cmd) {
				case 'x':
					return;
				case 'e':
					ErsteSeiteCmd ();
					break;
				case 'l':
					LetzteSeiteCmd ();
					break;
				}
			}
		}


		public event Action ErsteSeiteCmd;
		public event Action LetzteSeiteCmd;
	}
}
