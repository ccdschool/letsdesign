using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	public interface IConsolePortal {
		void Tabelle_anzeigen (IEnumerable<string> tabellenzeilen);
		void Menü_anzeigen();

		event Action ErsteSeiteCmd;
		event Action LetzteSeiteCmd;
		event Action NächsteSeiteCmd;
		event Action VorherigeSeiteCmd;
	}


	class ConsolePortal : IConsolePortal {
		public void Tabelle_anzeigen(IEnumerable<string> tabellenzeilen) {
			foreach (var tz in tabellenzeilen)
				Console.WriteLine (tz);
		}


		public void Menü_anzeigen() {
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
				case 'n':
					NächsteSeiteCmd ();
					break;
				case 'v':
					VorherigeSeiteCmd ();
					break;
				}
			}
		}


		public event Action ErsteSeiteCmd;
		public event Action LetzteSeiteCmd;
		public event Action NächsteSeiteCmd;
		public event Action VorherigeSeiteCmd;
	}
}
