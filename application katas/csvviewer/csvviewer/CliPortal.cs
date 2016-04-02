using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	class CliPortal {
		public void Starten(string[] args) {
			BeiDateiname (args [0]);
		}

		public event Action<string> BeiDateiname;
	}
}
