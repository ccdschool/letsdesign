using System;
using System.Collections.Generic;
using System.Linq;

namespace csvviewer
{
	// Beispieldatenquelle: https://www.destatis.de/DE/ZahlenFakten/LaenderRegionen/Regionales/Gemeindeverzeichnis/Administrativ/AdministrativeUebersicht.html

	public interface ICliPortal {
		void Starten (string[] args);
		event Action<string, int> BeiKommandozeilenparameter;
	}

	class CliPortal : ICliPortal {
		const int STANDARDSEITENLÄNGE = 10;

		public void Starten(string[] args) {
			var seitenlänge = STANDARDSEITENLÄNGE;
			if (args.Length > 1) seitenlänge = int.Parse (args [1]);

			BeiKommandozeilenparameter (args [0], seitenlänge);
		}

		public event Action<string, int> BeiKommandozeilenparameter;
	}
}
